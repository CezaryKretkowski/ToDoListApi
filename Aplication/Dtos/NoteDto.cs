using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entites;

namespace Aplication.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Context { get; set; } = string.Empty;

        static public NoteDto ToDto(Note n) { 
            return new NoteDto { 
                Id = n.Id,
                Context = n.Context 
            };
        }
        public Note ToEntity() {
            return new Note
            {
                Id = Id,
                Context = Context
            };
        }
    }
}
