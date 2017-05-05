using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using RestSharp;

namespace ServicesBackend
{
    public class KategoriServices
    {
        private RestClient client;
        public KategoriServices()
        {
            client = new RestClient(Helper.GetUrl());
        }

        public async Task<string> Insert(Kategori obj,string token)
        {
            RestRequest request = new RestRequest("api/Kategori", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Authorization", "Bearer "+token);

            request.AddBody(obj);
            var response = await client.ExecuteTaskAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString() + " " + response.ErrorMessage);
            }
            else
            {
                return "Data Kategori " + obj.NamaKategori + " berhasil ditambah !";
            }
        }
    }

}
