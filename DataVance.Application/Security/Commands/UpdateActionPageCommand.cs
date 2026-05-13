using DataVance.Application.Security.DTO;
using DataVance.Domain.Entities.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVance.Application.Security.Commands
{

    public record UpdateActionPageCommand : IRequest<bool>
    {
        public Guid PageId { get; init; }
        public List<PageActionDto> PageAction { get; init; } = new();
    }

}
