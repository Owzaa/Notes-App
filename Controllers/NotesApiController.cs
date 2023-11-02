using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Notes.Models;
using static Notes.Models.NotesModel;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Notes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesApiController : ControllerBase
    {

        private readonly NotesContext _context;

        public NotesApiController(NotesContext context)
        {
            _context = context;
        }




        // GET: api/Notes
        [HttpGet]
        public Task<ActionResult<IEnumerable<NotesModel>>> GetAsync()
        {
            return Task.FromResult((ActionResult<IEnumerable<NotesModel>>)_context.NotesModel);
        }
        // GET: api/Notes/5
        [HttpGet("{id}")]
        public Task<ActionResult<NotesModel>> GetNote(int id)
        {
            var note = _context.Notes;

            if (note == null)
            {
                return Task.FromResult<ActionResult<NotesModel>>(NotFound());
            }

            return Task.FromResult<ActionResult<NotesModel>> ((ActionResult<NotesModel>)note);
        }

        // POST api/<NotesApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<NotesApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<NotesApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
