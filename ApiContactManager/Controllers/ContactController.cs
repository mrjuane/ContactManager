using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactDAL.Model;
using ContactDAL.Factory;

namespace ApiContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IBaseRepository<Contact> _controller;

        public ContactController(IBaseRepository<Contact> controller)
        {
            this._controller = controller;
        }

        [HttpGet, Route("GetAll")]
        public async Task<List<Contact>> GetAll()
        {
            try
            {
                var entity = await Task.Run(() => _controller.GetAll().ToList());

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet, Route("GetContact")]
        public async Task<Contact> GetContact(int id) 
        {
            try
            {
                var entity = await Task.Run(() => _controller.GetEntity(id));

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost, Route("Insert")]
        public async Task<IActionResult> Insert(Contact entity)
        {
            try
            {
                var result = await Task.Run(() => _controller.Insert(entity));

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPut, Route("Update")]
        public async Task<IActionResult> Update(Contact entity)
        {
            try
            {
                if (entity.ConstactId == 0)
                {
                    return BadRequest();
                }

                var result = await Task.Run(() => _controller.Update(entity));

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete, Route("Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await Task.Run(() => _controller.Delete(id));

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
