using Microsoft.AspNetCore.Mvc;
using WebAPI.Dtos;
using WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly WebContext _webContext;   //先在全域宣告資料庫物件

        public TodoController(WebContext webContext)  //這邊是依賴注入使用我們剛設定好的資料庫物件的寫法
        {
            _webContext = webContext;
        }


        // GET: /api/todo?minOrder=3&maxOrder=4
        [HttpGet]
        public IEnumerable<TodoListSelectDto> Get(string name, bool? enable, DateTime? InsertTime, int minOrder, int maxOrder)
        {
            var result = _webContext.Todo
                        .Select(a => new TodoListSelectDto
                        {
                            Enable = a.Enable,
                            InsertEmployeeName = a.InsertEmployeeName,
                            InsertTime = a.InsertTime,
                            Name = a.Name,
                            Orders = a.Orders,
                            TodoId = a.TodoId,
                            UpdateEmployeeName = a.UpdateEmployeeName,
                            UpdateTime = a.UpdateTime
                        });

            if (!string.IsNullOrWhiteSpace(name))
            {
                result = result.Where(a => a.Name.Contains(name));
            }

            if (enable != null)
            {
                result = result.Where(a => a.Enable == enable);
            }

            if (InsertTime != null)
            {
                result = result.Where(a => a.InsertTime == InsertTime);
            }

            if (minOrder != null && maxOrder != null)
            {
                result = result.Where(a => a.Orders >= minOrder && a.Orders <= maxOrder);
            }
            return result;

        }
    }
}
