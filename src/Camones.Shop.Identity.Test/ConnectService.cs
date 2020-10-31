using IdentityModel.Client;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Camones.Shop.Identity.Test
{
    public static class ConnectService
    {
        public static async Task Get(string username, string password)
        {
            var httpClient = new HttpClient();

            var apiResponse = await httpClient.GetAsync("http://localhost:7001/api/Customers");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "invalid_access_token");

            if (apiResponse.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {                
                var identityServerResponse = await httpClient.RequestPasswordTokenAsync(new PasswordTokenRequest
                {
                    Address = "http://localhost:7000/connect/token",

                    ClientId = "camonesweb",
                    ClientSecret = "secret",
                    Scope = "camonesshop",

                    UserName = username,
                    Password = password
                });

                if (!identityServerResponse.IsError)
                {                    
                    Console.WriteLine(identityServerResponse.AccessToken);

                    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", identityServerResponse.AccessToken);
                    apiResponse = await httpClient.GetAsync("http://localhost:7001/api/Customers");

                    Console.WriteLine(await apiResponse.Content.ReadAsStringAsync());
                }
                else
                {
                    Console.WriteLine(identityServerResponse.ErrorDescription);
                }
            }
            else
            {               
                Console.WriteLine("El servicio no requiere proteccion");
            }
        }
    }
}