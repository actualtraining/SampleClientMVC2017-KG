using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using RestSharp;

namespace ServicesBackend
{
    public class BarangServices
    {
        private RestClient client;

        public BarangServices()
        {
            client = new RestClient(Helper.GetUrl());
        }
        public async Task<IEnumerable<Barang>> GetAllBarangKategoriMap()
        {
            RestRequest request = new RestRequest("api/BarangWithKategoriMap", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            var response = await client.ExecuteTaskAsync<List<Barang>>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString() + " " + response.ErrorMessage);
            }
        }

        public async Task<string> Insert(Barang obj)
        {
            RestRequest request = new RestRequest("api/Barang", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddBody(obj);

            var response = await client.ExecuteTaskAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(response.StatusCode.ToString() + " " + response.ErrorMessage);
            }
            else
            {
                return "Data Barang " + obj.KodeBarang + " " + obj.NamaBarang + " " + "berhasil ditambah !";
            }
        }

    }
}
