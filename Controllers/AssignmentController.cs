using looool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace looool.Controllers
{
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
            db.Assignments.Add(assignment);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateAssignment([FromBody] Assignment assignment)
        {
            db.Assignments.Update(assignment);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteAssignment(long id)
        {
            db.Assignments.Remove(db.Assignments.Where(p => p.TaskId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
