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
        public IActionResult Get(Guid id)
        {
            var result = (from a in _webContext.News
                          where a.NewsId == id
                          select new NewsDto
                          {
                              Title = a.Title,
                              Content = a.Content,
                              NewsId = a.NewsId,
                              StartDateTime = a.StartDateTime,
                              EndDateTime = a.EndDateTime,
                              Click = a.Click
                          }).SingleOrDefault();

            if (result == null)
            {
                return NotFound(); // 回傳 404
            }

            return Ok(result); // 回傳 200 和資料內容
        }

        //https://localhost:7215/api/News/GetKeyWord
        //https://localhost:7215/api/News/GetKeyWord?content=%E5%B0%8F%E8%B1%AC&%20startDateTime%20=%202025-05-06
        [HttpGet("GetKeyWord")]
        public IEnumerable<NewsDto> GetKeyWord(string title, string content, DateTime? startDateTime)
        {
            var result = from a in _webContext.News
                         select new NewsDto
                         {
                             Title = a.Title,
                             Content = a.Content,
                             NewsId = a.NewsId,
                             StartDateTime = a.StartDateTime,
                             EndDateTime = a.EndDateTime,
                             Click = a.Click
                         };

            if (!string.IsNullOrWhiteSpace(title))
            {
                result = result.Where(a => a.Title == title);
            }

            if (!string.IsNullOrWhiteSpace(content))
            {
                result = result.Where(a => a.Content.Contains(content));
            }

            if (startDateTime != null)
            {
                result = result.Where(a => a.StartDateTime.Date == ((DateTime)startDateTime).Date);
            }

            return result;
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
