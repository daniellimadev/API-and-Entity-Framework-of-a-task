using Microsoft.AspNetCore.Mvc;
using API_and_Entity_Framework_of_a_task.Context;
using API_and_Entity_Framework_of_a_task.Models;

namespace API_and_Entity_Framework_of_a_task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly OrganizerContext _context;

        public TaskController(OrganizerContext context)
        {
            _context = context;
        }
    
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // ALL: Search for the Id in the bank using EF
            var taskObtainedId = _context.Tasks.Find(id);
            if(taskObtainedId == null)
            {
                return NotFound();
            }

            return Ok(taskObtainedId);
            // ALL: Validate the return type. If the task cannot be found, return NotFound,
            // otherwise return OK with the task found
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            // ALL: Search for all tasks in the database using EF
            var tasksList = _context.Tasks.ToList();
            return Ok(tasksList);
        }

        [HttpGet("GetByTitle")]
        public IActionResult GetByTitle(string title)
        {
            // ALL: Search for tasks in the database using EF, which contains the title received by parameter
            // Tip: Use the ObterPorData endpoint as an example
            //var taskByTitle = _context.Tasks.Where(x => x. task.Title.Contains(title)).ToList();
            var taskByTitle = _context.Tasks.Where(x => x.Title.Contains(title)).ToList();

            return Ok(taskByTitle);
        }

        [HttpGet("GetByDate")]
        public IActionResult GetByDate(DateTime date)
        {
            var task = _context.Tasks.Where(x => x.Date.Date == date.Date);
            return Ok(task);
        }

        [HttpGet("GetByStatus")]
        public IActionResult GetByStatus(EnumStatusTask status)
        {
            // ALL: Search for tasks in the database using EF, which contains the status received by parameter
            // Tip: Use the ObterPorData endpoint as an example
            var task = _context.Tasks.Where(x => x.Status == status);
            return Ok(task);
        }

        [HttpPost]
        public IActionResult Create(Taske task)
        {
            if (task.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "The task date cannot be empty" });

            // ALL: Add the task received in EF and save changes
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult ToUpdate(int id, Taske task)
        {
            var taskBank = _context.Tasks.Find(id);

            if (taskBank == null)
                return NotFound();

            if (task.Date == DateTime.MinValue)
                return BadRequest(new { Erro = "Task date cannot be empty" });

            // ALL: Update the information in the taskBanco variable with the task received via parameter
            // ALL: Update the Bank task variable in EF and save changes
            taskBank.Title = task.Title;
            taskBank.Description = task.Description;
            taskBank.Date = task.Date;
            taskBank.Status = task.Status;

            _context.Tasks.Update(taskBank);
            
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var taskBank = _context.Tasks.Find(id);

            if (taskBank == null)
                return NotFound();

            // ALL: Remove the task found through EF and save changes
            _context.Tasks.Remove(taskBank);
            _context.SaveChanges();
            return NoContent();
        }
    }
}