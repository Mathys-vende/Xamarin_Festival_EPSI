using plz.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Collections;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Text;

namespace plz.Services
{


    public class ApiArtistes : IArtisteStore
    {
        private const string URL = "http://192.168.1.97:7016/api/Artistes";

        public async Task<bool> AddArtiste(Artiste artiste)
        {
            if (artiste.Id == 0)
            {
                string json = JsonConvert.SerializeObject(artiste);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL);
                HttpResponseMessage response = await client.PostAsync("", content);

                if(response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            else
            {
                string json = JsonConvert.SerializeObject(artiste);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(URL+"/"+artiste.Id);
                HttpResponseMessage response = await client.PutAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    return await Task.FromResult(true);
                }
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteArtiste(int id)
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

        public async Task<Artiste> GetArtiste(int id)
        {
            var artiste = new Artiste();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL + "/" + id);
            HttpResponseMessage response = await client.GetAsync("");
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                artiste = JsonConvert.DeserializeObject<Artiste>(content);  
            }
            return await Task.FromResult(artiste); 
        }
        public async Task<List<Artiste>> GetArtistes()
        {
            var artistes = new List<Artiste>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);
            try
            {
                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    string content = response.Content.ReadAsStringAsync().Result;
                    artistes = JsonConvert.DeserializeObject<List<Artiste>>(content);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return await Task.FromResult(artistes);
        }
    }
}
