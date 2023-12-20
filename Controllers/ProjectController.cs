using looool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace looool.Controllers
{
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private DataContext db;
        public ProjectController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Project> GetProject()
        {
            return db.Projects.ToList();
        }
        [HttpGet("{id}")]
        public Project GetProject(int id)
        {
            return db.Projects.Where(p => p.ProjectId == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveProject([FromBody] Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
        }
        [HttpPut]
        public void UpdateProject([FromBody] Project project)
        {
            db.Projects.Update(project);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteProject(long id)
        {
            db.Projects.Remove(db.Projects.Where(p => p.ProjectId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
