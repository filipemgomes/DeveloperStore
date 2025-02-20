using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IBranchRepository _branchRepository;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository, IBranchRepository branchRepository, IProductRepository productRepository, IMapper mapper)
    {
        _saleRepository = saleRepository;
        _branchRepository = branchRepository;
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
        
        if (sale == null) throw new ValidationException("Sale not found.");

        if (sale.Status == SaleStatusEnum.Cancelled)
            throw new ValidationException("Cannot modify a cancelled sale.");

        var branch = await _branchRepository.GetByIdAsync(request.BranchId, cancellationToken);
        
        if (branch == null) throw new ValidationException("Branch does not exist.");

        sale.UpdateSale(request.Customer, request.BranchId);

        var productIds = request.SaleItems.Select(si => si.ProductId).ToList();
        var products = await _productRepository.GetMultipleByIdsAsync(productIds, cancellationToken);

        if (products.Count() != productIds.Count)
            throw new ValidationException("One or more products do not exist.");
        
        var saleItems = request.SaleItems.Select(item =>
        {
            var product = products.First(p => p.Id == item.ProductId);

            
            decimal discount = Sale.CalculateDiscount(item.Quantity);
            decimal totalPrice = item.Quantity * product.UnitPrice * (1 - discount);
            return new SaleItem(item.ProductId, product, item.Quantity, product.UnitPrice, discount, totalPrice);
        }).ToList();

        sale.UpdateSaleItems(saleItems);
        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return _mapper.Map<UpdateSaleResult>(sale);
    }
}
