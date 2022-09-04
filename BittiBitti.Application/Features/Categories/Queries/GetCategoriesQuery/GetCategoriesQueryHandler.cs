using AutoMapper;
using BittiBitti.Application.Features.Categories.Dtos.Response;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using BittiBitti.Core.Persistence.Paging;
using BittiBitti.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BittiBitti.Application.Features.Categories.Queries.GetCategoriesQuery
{
    public class GetCatogoriesQuery : IRequest<EntityResponse<List<GetCategoriesQueryResponse>>>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetCatogoriesQuery, EntityResponse<List<GetCategoriesQueryResponse>>>
        {
            private readonly ICategoryRepository _categoryRepository;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
            {
                _categoryRepository=categoryRepository;
                _mapper=mapper;
            }
            async Task<EntityResponse<List<GetCategoriesQueryResponse>>> IRequestHandler<GetCatogoriesQuery, EntityResponse<List<GetCategoriesQueryResponse>>>.Handle(GetCatogoriesQuery request, CancellationToken cancellationToken)
            {
                EntityResponse<List<GetCategoriesQueryResponse>> entityResponse = new();
                IPaginate<Category> categories = await _categoryRepository.GetListAsync();
                List<GetCategoriesQueryResponse> categoryResponse = _mapper.Map<List<GetCategoriesQueryResponse>>(categories.Items);
                entityResponse.Success(categoryResponse);
                return entityResponse;
            }
        }

    }

}
