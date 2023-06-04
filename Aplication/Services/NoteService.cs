using Aplication.Dtos;
using Aplication.interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Services
{
    public class NoteService : INoteService
    {
        public readonly INoteRepository _repository;
        public NoteService(INoteRepository noteRepository) {
            _repository = noteRepository;
        }
        public async Task<NoteDto> Add(AddNoteDto noteDto)
        {
            var notes = noteDto.ToEntity();
            var returnNote = await _repository.Add(notes);
            if (returnNote != null)
            {
                return NoteDto.ToDto(returnNote);
            }
            else
                return null;
        }

        public async Task<NoteDto> Delete(int id)
        {
            var returnNote  =await _repository.Delete(id);
            return NoteDto.ToDto(returnNote);
        }

        public async Task<IEnumerable<NoteDto>> GetAll()
        {
            var list = await _repository.GetAll();
            return list.Select(n => NoteDto.ToDto(n));
        }

        public async Task<NoteDto> GetById(int id)
        {
            var note = await _repository.GetById(id);
            if (note != null)
            {
                return NoteDto.ToDto(note);
            }
            else
                return null;
        }

        public async Task<NoteDto> Update(NoteDto noteDto)
        {
            var notes = noteDto.ToEntity();
            var returnNote = await _repository.Update(notes);
            if (returnNote != null)
            {
                return NoteDto.ToDto(returnNote);
            }
            else
                return null;
        }
    }
}
