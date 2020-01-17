using API.NaturalEventTracker.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace API.NaturalEventTracker.Application.Commands
{
    public class ListCategoryCommand : IRequest<IEnumerable<CategoryResponse>>
    {

    }
}
