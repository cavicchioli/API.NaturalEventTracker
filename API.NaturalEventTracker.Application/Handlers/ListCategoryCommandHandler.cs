using API.NaturalEventTracker.Application.Commands;
using API.NaturalEventTracker.Application.Responses;
using API.NaturalEventTracker.Domain.Interfaces;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.NaturalEventTracker.Application.Handlers
{
    public class ListCategoryCommandHandler : IRequestHandler<ListCategoryCommand, IEnumerable<CategoryResponse>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public ListCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;

        }
        public async Task<IEnumerable<CategoryResponse>> Handle(ListCategoryCommand request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<CategoryResponse>>(await _categoryRepository.GetAll());
        }
    }
}
