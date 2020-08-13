using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BlazorMiniApp.Shared.DTOs;
using BlazorMiniApp.Shared.Entities;
using BlazorMiniApp.Shared.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorMiniApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieAPIController : ControllerBase
    {
        private readonly IMovie movie;

        public MovieAPIController(IMovie movie)
        {
            this.movie = movie;
        }

        [HttpGet]
        [Route("find/{id}")]
        public async Task<IActionResult> Find(string id)
        {
            var result = await movie.Get(id);
            if (result.Title == null )
            {
                return BadRequest();
            }
            return Ok(result);
        }
        [HttpGet]
        [Route("delete/{id}/{rev}")]
        public async Task<IActionResult> Delete(string id, string rev)
        {
            var result = await movie.Delete(id, rev);
            return Ok(result);
        }
        [HttpPost]
        [Route("insert")]
        public async Task<IActionResult> Insert(Movie model)
        {
            var result = await movie.Insert(model);
            return Ok(result);
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> Update(MovieDto model)
        {
            var result = await movie.Update(model);
            return Ok(result);
        }
        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await movie.GetList();
            return Ok(result);
        }

    }
}
