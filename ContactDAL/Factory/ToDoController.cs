using ContactDAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactDAL.Factory
{
    public class ToDoController : IBaseRepository<ToDo>
    {
        private readonly ContactContext _context = null;

        public ToDoController()
        {
            if (this._context == null)
            {
                this._context = new ContactContext();
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var dataToDelete = this._context.ToDos.FirstOrDefault(c => c.ToDoId == id);
                int result = 0;
                if (dataToDelete != null)
                {
                    this._context.Entry(dataToDelete).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    result = this._context.SaveChanges();
                }

                return result > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            this._context.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ToDo> GetAll()
        {
            try
            {
                return this._context.ToDos.AsEnumerable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ToDo GetEntity(int id)
        {
            try
            {
                return this._context.ToDos.FirstOrDefault(c => c.ToDoId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(ToDo entity)
        {
            try
            {
                this._context.ToDos.Add(entity);
                this._context.SaveChanges();
                return entity.ToDoId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(ToDo entity)
        {
            try
            {
                var partialData = this._context.ToDos.FirstOrDefault(c => c.ToDoId == entity.ToDoId);

                if (partialData == null)
                {
                    throw new Exception("Not Found..");
                }

                partialData.ContactId = entity.ContactId;
                partialData.Task = entity.Task;
                partialData.Description = entity.Description;
                partialData.IsCompleted = entity.IsCompleted;

                this._context.Entry(partialData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                int result = partialData.ToDoId;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
