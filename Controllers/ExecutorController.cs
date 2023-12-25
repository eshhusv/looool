using looool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace looool.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExecutorController : ControllerBase
    {
        private DataContext db;
        public ExecutorController(DataContext ctx)
        {
            db = ctx;
        }
        [HttpGet]
        public IEnumerable<Executor> GetExecutor()
        {
            return db.Executors.ToList();
        }
        [HttpGet("{id}")]
        public Executor GetExecutor(int id)
        {
            return db.Executors.Where(p => p.ExecutorId == id).FirstOrDefault()!;
        }
        [HttpPost]
        public void SaveExecutor([FromBody] Executor executor)
        {
            if (executor != null)
            {
                db.Executors.Add(executor);
                db.SaveChanges();
            }
        }
        [HttpPut]
        public async Task<ActionResult<Executor>> Put(Executor executor)
        {
            if (executor == null)
            {
                return BadRequest();
            }
            if (!db.Executors.Any(x => x.ExecutorId == executor.ExecutorId))
            {
                return NotFound();
            }
            db.Update(executor);
            await db.SaveChangesAsync();
            return Ok(executor);
        }
        public void UpdateExecutor([FromBody] Executor executor)
        {
            db.Executors.Update(executor);
            db.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteExecutor(long id)
        {
            db.Executors.Remove(db.Executors.Where(p => p.ExecutorId == id).FirstOrDefault()!);
            db.SaveChanges();
        }
    }
}
