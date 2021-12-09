using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebContactManager.Models;
using Newtonsoft.Json;
using System.Text;

namespace WebContactManager.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client = null;
        public ContactController(IHttpClientFactory clientfactory)
        {
            if (_client == null)
            {
                _client = clientfactory.CreateClient("Contact");
            }

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<List<Contact>> GetAllContacts()
        {
            try
            {
                List<Contact> contactResult = new List<Contact>();

                using (var response = await _client.GetAsync("GetAll"))
                {
                    var data = await response.Content.ReadAsStringAsync();

                    contactResult = JsonConvert.DeserializeObject<List<Contact>>(data);
                }

                return contactResult;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet]
        public async Task<Contact> GetContacts(int id)
        {
            try
            {
                var response = await _client.GetAsync("GetContact?id=" + id);

                var data = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<Contact>(data);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public async Task<string> Insert(Contact contact)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return string.Empty;
                }

                string result = string.Empty;

                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");

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
        public async Task<string> Update(Contact contact)
        {
            try
            {
                string result = string.Empty;

                StringContent content = new StringContent(JsonConvert.SerializeObject(contact), Encoding.UTF8, "application/json");

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
