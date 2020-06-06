using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class NewsController : ControllerBase
    {
        
        public INewsRepository  _repository { get;  }


        public NewsController(INewsRepository repository)
        {

            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<News> GetNews([FromHeader]string isFake)
        {
            if (isFake == null)
            {
                return _repository.GetAllNews();
            }
            else if (isFake == "true")
            {
                return _repository.GetAllNews().Where(t => t.IsFake == true);
            }
            else
            {
                return _repository.GetAllNews().Where(t => t.IsFake == false);
            }

        }

        [HttpPost]
        public void CreateNews(News news)
        {
            _repository.CreateNews(news);
        }

        [HttpDelete("{id}")]
        public void DeleteNews(int id)
        {
            _repository.DeleteNews(id);
        }

        [HttpPut]
        public void ChangeNews(News news)
        {
            _repository.ChangeNews(news);
        }

        [HttpPatch("{id}")]
        public void ChangePartialNews(int id, News news)
        {
            _repository.ChangePartialNews(id, news);
        }

    }
}
