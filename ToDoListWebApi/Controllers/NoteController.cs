using Aplication.Dtos;
using Aplication.interfaces;
using Aplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace ToDoListWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController
    {
        private readonly INoteService _noteService;

        public NoteController(INoteService noteService) {
            _noteService = noteService;
        }

        [HttpPost]
        [Route("AddNote")]
        public async Task<IActionResult> AddTask(AddNoteDto noteDto)
        {

            var note = await _noteService.Add(noteDto);

            if (note != null)
            {
                return new OkObjectResult(note);
            }
            return new BadRequestObjectResult("error while adding task");
        }

        [HttpGet]
        [Route("GetAllNotes")]
        public async Task<IActionResult> GetAllNotes() {

            var notes = await _noteService.GetAll();
            return new OkObjectResult(notes);
        }
        [HttpGet]
        [Route("GetNoteByID")]
        public async Task<IActionResult> GetNoteByID(int id) {
            var n = await _noteService.GetById(id);
            if (n == null)
            {
                return new NotFoundResult();
            }
            else
            {
                return new OkObjectResult(n);
            }
        }
        [HttpPut]
        [Route("UpdateNote")]
        public async Task<IActionResult> UpdateNote(NoteDto note)
        {
            var retNote = await _noteService.Update(note);
            if (retNote != null)
            {
                return new OkObjectResult(retNote);
            }
            return new BadRequestObjectResult("Error while updating Note");
        }

        [HttpDelete]
        [Route("DeleteNote")]
        public async Task<IActionResult> DeleteNote(int id)
        {
            var note = await _noteService.Delete(id);
            if (note != null)
            {
                return new OkObjectResult(note);
            }
            return new BadRequestObjectResult("Error while deliting task");
        }

    }
}
