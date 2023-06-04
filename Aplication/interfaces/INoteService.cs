using Aplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.interfaces
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetAll();
        Task<NoteDto> GetById(int id);
        Task<NoteDto> Add(AddNoteDto noteDto);
        Task<NoteDto> Update(NoteDto noteDto);
        Task<NoteDto> Delete(int id);
    }
}
