using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebContactManager.Models;

namespace WebContactManager.Controllers
{
    public class ToDoController : Controller
    {
        private readonly HttpClient _client = null;
        public ToDoController(IHttpClientFactory clientFactory)
        {
            if (this._client ==null)
            {
                this._client = clientFactory.CreateClient("ToDo");
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<ToDo>> GetAllContacts()
        {
            try
            {
                List<ToDo> contactResult = new List<ToDo>();

                using (var response = await _client.GetAsync("GetAll"))
                {
                    var data = await response.Content.ReadAsStringAsync();

                    contactResult = JsonConvert.DeserializeObject<List<ToDo>>(data);
                }

                return contactResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<ToDo> GetContacts(int id)
        {
            try
            {
                var response = await _client.GetAsync("GetTodo?id=" + id);

                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<ToDo>(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> Insert(ToDo entity)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return string.Empty;
                }

                string result = string.Empty;

                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                using (var response = await _client.PostAsync("Insert", content))
                {
                    var data = await response.Content.ReadAsStringAsync();

                    result = data;
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> Update(ToDo entity)
        {
            try
            {
                string result = string.Empty;

                StringContent content = new StringContent(JsonConvert.SerializeObject(entity), Encoding.UTF8, "application/json");

                using (var response = await _client.PutAsync("Update", content))
                {
                    var data = await response.Content.ReadAsStringAsync();

                    result = data;
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            try
            {
                string result = string.Empty;

                using (var response = await _client.DeleteAsync("Delete?id=" + id))
                {
                    var data = await response.Content.ReadAsStringAsync();

                    result = data;
                }

                return result;
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

    }
}
