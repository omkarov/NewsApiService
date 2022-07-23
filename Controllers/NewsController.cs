using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewApiService.Data;
using NewApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        INewsRepo repo;
        public NewsController(INewsRepo repository)
        {
            repo = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<News>> GetAllNewsAsync()   
        {
            var obj= await repo.GetAllNewsAsync();
            return obj;
        }

        [HttpGet("{id}", Name = "GetNewsByIdAsync")]
        public async Task<ActionResult<News>> GetNewsByIdAsync(string id)
        {
            var result = await repo.GetNewsByIdAsync(id);
            if (result.NewsId != null)
                return result;
            else
                return NotFound();
        }


        [HttpPost]
        public async Task<ActionResult<News>> AddNewsAsync([FromBody] News news)
        {
            await repo.AddNewsAsync(news);
            //Return the data that is posted
            var obj =  CreatedAtRoute(nameof(GetNewsByIdAsync), new { Id = news.NewsId }, news);
            return obj;

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<News>> DeleteCommandAsync(string id)
        {
            var objId = await repo.GetNewsByIdAsync(id);
            if (objId.NewsId == null)
                return NotFound();
            else
            {
                //repo.DeleteNews(objId);
                await repo.DeleteNewsAsync(id);
            return NoContent();   // 204 status code
            }
        }

        
    }
}
    