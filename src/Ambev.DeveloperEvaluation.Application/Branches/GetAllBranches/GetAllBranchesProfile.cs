using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Branches.GetAllBranches
{
    public class GetAllBranchesProfile : Profile
    {
        public GetAllBranchesProfile()
        {
            CreateMap<Branch, GetBranchResult>();
        }
    }
}
