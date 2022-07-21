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

        [Authorize]
        [HttpGet]
        public IEnumerable<News> GetAllNews()   
        {

            return repo.GetAllNews();
        }

        [HttpGet("{id}", Name = "GetNewsById")]
        public ActionResult<News> GetNewsById(string id)
        {
            var result = repo.GetNewsById(id);
            if (result.NewsId != null)
                return result;
            else
                return NotFound();
        }


        [HttpPost]
        public ActionResult<News> AddNews([FromBody] News news)
        {
            repo.AddNews(news);
            //Return the data that is posted
            return CreatedAtRoute(nameof(GetNewsById), new { Id = news.NewsId }, news);
        }

        [HttpDelete("{id}")]
        public ActionResult<News> DeleteCommand(string id)
        {
            var objId = repo.GetNewsById(id);
            if (objId.NewsId == null)
                return NotFound();
            else
            {
                //repo.DeleteNews(objId);
                repo.DeleteNews(id);
            return NoContent();   // 204 status code
            }
        }


    }
}
    