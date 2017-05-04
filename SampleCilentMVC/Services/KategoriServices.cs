using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using BO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SampleCilentMVC.Models;

namespace SampleCilentMVC.Services
{
    public class KategoriServices
    {
        private HttpClient client;
        public KategoriServices()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:50456/");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<Kategori>> GetAll()
        {
            List<Kategori> listKategori;
            var response = await client.GetAsync("api/Kategori");
            if (response.IsSuccessStatusCode)
            {
                listKategori = await response.Content.ReadAsAsync<List<Kategori>>();
                return listKategori;
            }
            else
            {
                return new List<Kategori>() { };
            }
        }

        public async Task<Kategori> GetById(string id)
        {
            Kategori kategori;
            var response = await client.GetAsync("api/Kategori/" + id);
            if (response.IsSuccessStatusCode)
            {
                kategori = await response.Content.ReadAsAsync<Kategori>();
                return kategori;
            }
            else
            {
                return new Kategori() { };
            }
        }

        public async Task Insert(Kategori obj)
        {
            var response = await client.PostAsJsonAsync("api/Kategori", obj);
            if(!response.IsSuccessStatusCode)
            {
                var strError = await response.Content.ReadAsStringAsync();
                var errResult = JsonConvert.DeserializeObject<ErrorResult>(strError);
                throw new Exception(errResult.Message);  
            }
        }

        public async Task Update(Kategori obj)
        {
            var response = await client.PutAsJsonAsync("api/Kategori", obj);
            if(!response.IsSuccessStatusCode)
            {
                var strError = await response.Content.ReadAsStringAsync();
                var errResult = JsonConvert.DeserializeObject<ErrorResult>(strError);
                throw new Exception(errResult.Message);
            }
        }

        public async Task Delete(string id)
        {
            var response = await client.DeleteAsync("api/Kategori/" + id);
            if(!response.IsSuccessStatusCode)
            {
                var strError = await response.Content.ReadAsStringAsync();
                var errResult = JsonConvert.DeserializeObject<ErrorResult>(strError);
                throw new Exception(errResult.Message);
            }
        }
    }
}