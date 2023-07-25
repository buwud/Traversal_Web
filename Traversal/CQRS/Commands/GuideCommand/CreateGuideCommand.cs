using MediatR;

namespace Traversal.CQRS.Commands.GuideCommand
{
    public class CreateGuideCommand:IRequest
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
