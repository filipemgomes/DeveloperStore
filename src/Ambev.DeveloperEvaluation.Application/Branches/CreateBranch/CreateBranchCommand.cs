using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.CreateBranch
{
    public class CreateBranchCommand : IRequest<CreateBranchResult>
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public bool AllowsDiscounts { get; set; }
    }
}
