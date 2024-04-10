using ConsultaCEP.InterFace;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultaCEP.Service
{
    internal class ConsumoCepService
    {
        public async Task<CEP> ConsultaCEP(string id)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync($"https://viacep.com.br/ws/{id}/json");
            var jsonResponse = await response.Content.ReadAsStringAsync();
            var jsonConverte = JsonConvert.DeserializeObject<CEP>(jsonResponse);

            if (jsonConverte != null)
            {
                return jsonConverte;
            }
            else
            {
                return new CEP
                {
                    validacao = false
                };
            }
        }
    }
}
