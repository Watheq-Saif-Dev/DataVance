using DataVance.Application.Features.EventManagement.DTOs;
using MediatR;


namespace DataVance.Application.Features.EventManagement.Queries
{
    public record GetEventDashboardQuery : IRequest<EventManagementDto>;
}
