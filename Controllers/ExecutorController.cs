using looool.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace looool.Controllers
{
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
            db.Executors.Add(executor);
            db.SaveChanges();
        }
        [HttpPut]
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
