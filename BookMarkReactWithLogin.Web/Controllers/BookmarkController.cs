using BookMarkReactWithLogin.Data;
using BookMarkReactWithLogin.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookMarkReactWithLogin.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly string _connection;

        public BookmarkController(IConfiguration config)
        {
            _connection = config.GetConnectionString("ConStr");
        }

        [HttpPost("AddBookmark")]
        [Authorize]
        public void AddBookmark(AddBoomarkVM vm)
        {
            var repo = new BookmarksRepository(_connection);
            repo.AddBookmark(vm.UserId, vm.Bookmark);
        }

        [HttpGet("GetTop5")]
        public List<BookmarkCounter> GetTop5()
        {
            var repo = new BookmarksRepository(_connection);
            return repo.GetTop5();
        }
    }
}
