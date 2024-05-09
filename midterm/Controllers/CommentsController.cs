using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using midterm.Models;

namespace midterm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ApplcationDBContext _context;

        public CommentsController(ApplcationDBContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<Post>> CreateComment(Comment comment)
        {
            var comments = new Comment
            {
                Content = comment.Content,
                PostId = comment.PostId,
            };

            _context.Comments.Add(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = comments.Id }, comments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> Get(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return comment;
        }

        [HttpGet]
        public async Task<ActionResult<List<Comment>>> GetCommentsForPost(int postId)
        {
            return await _context.Comments
                 .Where(c => c.PostId == postId)
                 .ToListAsync();
        }

    }
}