using Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface INoteRepository
    {
        Task<IEnumerable<Note>> GetAll();
        Task<Note> GetById(int id);
        Task<Note> Add(Note note);
        Task<Note> Update(Note note);
        Task<Note> Delete(int id);
    }
}
