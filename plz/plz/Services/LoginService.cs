using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace plz.Services
{
    public class LoginService
    {
        private const string LoginWebServiceUrl = "http://localhost:7016/api/Admin/";

        public async Task<bool> checkLogin(string email, string password)
        {
            var httpClient = new HttpClient();

            var response = await httpClient.GetAsync(LoginWebServiceUrl + email + "/" + password);

            if(response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public async Task<bool> CheckLoginIfExists(string email, string password)
        {
            var check = await checkLogin(email, password);

            return check;
        }
    }
}
