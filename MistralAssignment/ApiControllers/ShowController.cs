using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistralAssignment.Filters;
using MistralAssignment.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModels;
using ViewModels.Requests;

namespace MistralAssignment.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowController : ControllerBase
    {
        private readonly IShowsService _service;

        public ShowController(IShowsService service)
        {
            _service = service;
        }

        [HttpGet]
        [RequestLimit("GetShows", NoOfRequest = 20, Seconds = 4)]
        public async Task<List<ShowVM>> Get([FromQuery] ShowSearchRequestVM searchParams)
        {
            return await _service.GetAsync(searchParams);
        }

        [HttpGet("{id}")]
        public async Task<ShowVM> GetById(long id)
        {
            return await _service.GetByIdAsync(id);
        }
    }
}
