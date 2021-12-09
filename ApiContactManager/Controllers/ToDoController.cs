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
    public class ToDoController : ControllerBase
    {
        private readonly IBaseRepository<ToDo> _controller = null;
        public ToDoController(IBaseRepository<ToDo> controller)
        {
            if (this._controller == null)
            {
                this._controller = controller;
            }
        }

        [HttpGet, Route("GetAll")]
        public async Task<List<ToDo>> GetAll()
        {
            try
            {
                var entity = await Task.Run(() => this._controller.GetAll().ToList()); 
                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet, Route("GetTodo")]
        public async Task<ToDo> GetTodo(int id)
        {
            try
            {
                var entity = await Task.Run(() => this._controller.GetEntity(id));

                return entity;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost, Route("Insert")]
        public async Task<IActionResult> Insert(ToDo entity)
        {
            try
            {
                var result = await Task.Run(() => this._controller.Insert(entity));

                return Ok(result);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost, Route("Update")]
        public async Task<IActionResult> Update(ToDo entity)
        {
            try
            {
                if (entity.ToDoId == 0)
                {
                    return BadRequest();
                }

                var result = await Task.Run(() => this._controller.Update(entity));

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
                var entity = await Task.Run(() => this._controller.Delete(id));

                return Ok(entity);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
