using BittiBitti.Application.Features.Brands.Dtos.Response;
using BittiBitti.Application.Features.Brands.Queries.GetBrandsQuery;
using BittiBitti.Core.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BittiBitti.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            EntityResponse<List<GetBrandsQueryResponse>> responseModel =  await Mediator.Send(new GetBrandsQuery());
            return Ok(responseModel);
        }
    }
}
