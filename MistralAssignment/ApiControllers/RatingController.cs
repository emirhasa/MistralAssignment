using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class RatingController : ControllerBase
    {
        private readonly IRatingsService _service;

        public RatingController(IRatingsService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task Insert(RatingInsertRequestVM insertRequest)
        {
            await _service.InsertAsync(insertRequest);
        }
    }
}
