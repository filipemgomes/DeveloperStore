using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Branches.UpdateBranch
{
    public class UpdateBranchCommand : IRequest<UpdateBranchResult>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public bool AllowsDiscounts { get; set; }
    }
}
