using BittiBitti.Application.Features.Categories.Dtos.Response;
using BittiBitti.Application.Features.Categories.Queries.GetCategoriesQuery;
using BittiBitti.Application.Services.Repositories;
using BittiBitti.Core.Models.Base;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BittiBitti.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : BaseController
    {


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            EntityResponse<List<GetCategoriesQueryResponse>> response =  await Mediator.Send(new GetCatogoriesQuery());
            return Ok(response);
        }
    }
}
