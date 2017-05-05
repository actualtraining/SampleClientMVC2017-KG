using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BO;
using RestSharp;

namespace ServicesBackend
{
    public class AccountServices
    {
        private RestClient client;
        public AccountServices()
        {
            client = new RestClient(Helper.GetUrl());
        }
        public async Task<BearerToken> Login(string username, string password)
        {
            RestRequest request = new RestRequest("Token", Method.POST)
            {
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            request.AddParameter("grant_type", "password");
            request.AddParameter("username", username);
            request.AddParameter("password", password);
            //request.AddBody(string.Format("=&username={0}&password={1}",username,password));

            var response = await client.ExecuteTaskAsync<BearerToken>(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return response.Data;
            }
            else
            {
                throw new Exception(response.StatusCode.ToString() + " " + response.ErrorMessage);
            }
        }
    }
}
