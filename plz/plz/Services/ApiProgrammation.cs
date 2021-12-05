using plz.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace plz.Services
{
    public class ApiProgrammation : IProgrammationStore<Programmation>
    {
        private const string URL = "http://localhost:7016/api/Programmations";
        public async Task<bool> AddProgrammation(Programmation programmation)
        {
            if (programmation.Id == 0)
            {
                string json = JsonConvert.SerializeObject(programmation);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(programmation);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL + "/" + programmation.Id);
                HttpResponseMessage response = await client.PutAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteProgrammation(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL + "/" + id);
            HttpResponseMessage response = await client.DeleteAsync("");

            if (response.IsSuccessStatusCode)
            {
                return await Task.FromResult(true);
            }
            else
            {
                return await Task.FromResult(false);
            }
        }

        public async Task<Programmation> GetProgrammation(int id)
        {
            var programmation = new Programmation();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL + "/" + id);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                programmation = JsonConvert.DeserializeObject<Programmation>(content);
            }
            return await Task.FromResult(programmation);
        }

        public async Task<List<Programmation>> GetProgrammations(bool forceRefresh = false)
        {
            var programmation = new List<Programmation>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            try
            {
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    programmation = JsonConvert.DeserializeObject<List<Programmation>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(programmation);
        }
    }
}
