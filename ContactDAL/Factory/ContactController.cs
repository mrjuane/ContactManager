using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDAL.Model;

namespace ContactDAL.Factory
{
    public class ContactController : IBaseRepository<Contact>
    {
        #region comment

        private readonly ContactContext _context = null;

        public ContactController()
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
                var dataToDelete = this._context.Contacts.FirstOrDefault(c => c.ConstactId == id);
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

        public IEnumerable<Contact> GetAll()
        {
            try
            {
                return this._context.Contacts.AsEnumerable();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Contact GetEntity(int id)
        {
            try
            {
                return this._context.Contacts.FirstOrDefault(c => c.ConstactId == id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Insert(Contact entity)
        {
            try
            {
                this._context.Contacts.Add(entity);
                this._context.SaveChanges();
                return entity.ConstactId;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Update(Contact entity)
        {
            try
            {
                var partialData = this._context.Contacts.FirstOrDefault(c => c.ConstactId == entity.ConstactId);

                if (partialData == null)
                {
                    throw new Exception("Not Found..");
                }

                partialData.FirstName = entity.FirstName;
                partialData.LastName = entity.LastName;
                partialData.Address = entity.Address;
                partialData.Email = entity.Email;
                partialData.Phone = entity.Phone;
                partialData.Genre = entity.Genre;

                this._context.Entry(partialData).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                this._context.SaveChanges();

                int result = partialData.ConstactId;

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
