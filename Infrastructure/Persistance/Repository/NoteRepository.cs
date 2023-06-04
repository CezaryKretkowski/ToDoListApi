using Domain.Entites;
using Domain.Interfaces;
using Infrastructure.Persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly ApiDBContext _dbContext;
        public NoteRepository(ApiDBContext context) {
            _dbContext = context;
        }
        public async Task<Note> Add(Note note)
        {
            try {
                var n = await _dbContext.Notes.AddAsync(note);
                await _dbContext.SaveChangesAsync();

                return n.Entity;
            }catch (Exception ex)
            {
                throw new Exception("Error while adding note" + ex.Message, ex);
            }
        }

        public async Task<Note> Delete(int id)
        {
            try {
                var n = await _dbContext.Notes.FindAsync(id);
                if (n != null)
                {
                    _dbContext.Notes.Remove(n);
                    await _dbContext.SaveChangesAsync();

                    return n;
                }
                else
                    return null;
            }
            catch(Exception e)
            {
                throw new Exception("Error while deliting note" + e.Message, e);
            }
        }

        public async Task<IEnumerable<Note>> GetAll()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<Note> GetById(int id)
        {
            try { 
                var note = await _dbContext.Notes.FindAsync(id);
                if (note != null)
                    return note;
                else
                    return null;

            } catch (Exception e) { 
                throw new Exception(e.Message, e);
            }
        }

        public async Task<Note> Update(Note note)
        {
            try
            {
                var n = _dbContext.Notes.Update(note);
                await _dbContext.SaveChangesAsync();

                return n.Entity;
            }
            catch (Exception ex)
            {
                throw new Exception("Error while updating note" + ex.Message, ex);
            }
        }
    }
}
