using looool.Models;
using Microsoft.AspNetCore.Mvc;

namespace looool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssignmentController : ControllerBase
    {
        private DataContext db;
        public AssignmentController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Assignment> GetTask()
        {
            return db.Assignments.ToList();
        }
        [HttpGet("{id}")]
        public Assignment GetAssignments(int id)
        {
            return db.Assignments.Where(p => p.TaskId == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveAssignment([FromBody] Assignment assignment)
        {
            if (assignment != null)
            {
                db.Assignments.Add(assignment);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public async Task<ActionResult<Assignment>> Put(Assignment assignment)
        {
            if (assignment == null)
            {
                return BadRequest();
            }
            if (!db.Assignments.Any(x => x.TaskId == assignment.TaskId))
            {
                return NotFound();
            }
            db.Update(assignment);
            await db.SaveChangesAsync();
            return Ok(assignment);
        }
        [HttpDelete("{id}")]
        public void DeleteAssignment(long id)
        {
            db.Assignments.Remove(db.Assignments.Where(p => p.TaskId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
