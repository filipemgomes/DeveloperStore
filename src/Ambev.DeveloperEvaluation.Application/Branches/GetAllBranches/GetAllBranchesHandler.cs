using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetAllBranches
{
    public class GetAllBranchesHandler : IRequestHandler<GetAllBranchesQuery, GetAllBranchesResult>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public GetAllBranchesHandler(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }

        public async Task<GetAllBranchesResult> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            var branches = await _branchRepository.GetAllAsync(cancellationToken);
            var result = new GetAllBranchesResult
            {
                Branches = _mapper.Map<List<GetBranchResult>>(branches)
            };
            return result;
        }
    }
}