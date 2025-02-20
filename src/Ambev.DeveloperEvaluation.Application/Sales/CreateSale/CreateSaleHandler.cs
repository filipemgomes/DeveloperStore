using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateSaleHandler(ISaleRepository saleRepository, IProductRepository productRepository, IBranchRepository branchRepository, IMapper mapper, IMediator mediator)
        {
            _saleRepository = saleRepository;
            _productRepository = productRepository;
            _branchRepository = branchRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSaleValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var branch = await _branchRepository.GetByIdAsync(request.BranchId, cancellationToken);
            if (branch == null)
                throw new ValidationException("Branch does not exist.");

            var productIds = request.SaleItems.Select(si => si.ProductId).ToList();
            var products = await _productRepository.GetMultipleByIdsAsync(productIds, cancellationToken) ?? new List<Product>();
            if (products.Count() != productIds.Count)
                throw new ValidationException("One or more products do not exist.");

            var saleItems = request.SaleItems.Select(item =>
            {
                var product = products.First(p => p.Id == item.ProductId);
                decimal discount = branch.AllowsDiscounts ? Sale.CalculateDiscount(item.Quantity) : 0;
                decimal totalPrice = item.Quantity * product.UnitPrice * (1 - discount);
                return new SaleItem(item.ProductId, product, item.Quantity, product.UnitPrice, discount, totalPrice);
            }).ToList();

            var sale = new Sale(request.SaleNumber, request.Customer, request.BranchId);
            sale.UpdateSaleItems(saleItems);
            await _saleRepository.AddAsync(sale, cancellationToken);

            await _mediator.Publish(new SaleCreatedEvent(sale.Id, sale.Customer), cancellationToken);

            return _mapper.Map<CreateSaleResult>(sale);
        }
    }
}
