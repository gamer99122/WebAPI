using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly WebContext _webContext;   //先在全域宣告資料庫物件

        public NewsController(WebContext webContext)  //這邊是依賴注入使用我們剛設定好的資料庫物件的寫法
        {
            _webContext = webContext;
        }




        // GET: api/<NewsController>
        [HttpGet]
        public IEnumerable<NewsDto> Get()
        {
            var result = from a in _webContext.News
                         select new NewsDto
                         {
                             NewsId = a.NewsId,
                             Title = a.Title,
                             Content = a.Content,
                             StartDateTime = a.StartDateTime,
                             EndDateTime =a.EndDateTime,
                             Click =a.Click
                         };


            return result;
        }

        // GET api/<NewsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<NewsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NewsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NewsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
