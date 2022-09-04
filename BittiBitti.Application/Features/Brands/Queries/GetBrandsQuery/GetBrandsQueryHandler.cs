using AutoMapper;
using BittiBitti.Application.Features.Brands.Dtos.Response;
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

namespace BittiBitti.Application.Features.Brands.Queries.GetBrandsQuery
{
    public class GetBrandsQuery : IRequest<EntityResponse<List<GetBrandsQueryResponse>>>
    {
        public class GetBrandsQueryHandler : IRequestHandler<GetBrandsQuery, EntityResponse<List<GetBrandsQueryResponse>>>
        {
            private readonly IMapper _mapper;
            private readonly IBrandRepository _brandRepository;
            public GetBrandsQueryHandler(IBrandRepository brandRepository, IMapper mapper)
            {
                _brandRepository=brandRepository;
                _mapper=mapper;
            }
            async Task<EntityResponse<List<GetBrandsQueryResponse>>> IRequestHandler<GetBrandsQuery, EntityResponse<List<GetBrandsQueryResponse>>>.Handle(GetBrandsQuery request, CancellationToken cancellationToken)
            {
                EntityResponse<List<GetBrandsQueryResponse>> entityResponse = new();
                IPaginate<Brand> categories = await _brandRepository.GetListAsync();
                List<GetBrandsQueryResponse> categoryResponse = _mapper.Map<List<GetBrandsQueryResponse>>(categories.Items);
                entityResponse.Success(categoryResponse);
                return entityResponse;
            }
        }

    }
}
