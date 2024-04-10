using ConsultaCEP.InterFace;
using ConsultaCEP.Service;

namespace consumoCEPAPI
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Digite o seu cep:");
            string cepData = Console.ReadLine();

            //out significa que iria usar essa variável dentro de um método
            
                ConsumoCepService service = new ConsumoCepService();
                CEP cep = await service.ConsultaCEP(cepData);

                if (cep.validacao)
                {
                    Console.WriteLine("##################");
                    Console.WriteLine("CEP: " + cep.cep);
                    Console.WriteLine("Logradouro: " + cep.logradouro);
                    Console.WriteLine("Complemento: " + cep.complemento);
                    Console.WriteLine("Bairro: " + cep.bairro);
                    Console.WriteLine("Localidade: " + cep.localidade);
                    Console.WriteLine("UF: " + cep.uf);
                    Console.WriteLine("DDD: " + cep.ddd);
                    Console.WriteLine("##################");
                }
                else
                {
                    cep.validacao = false;
                    Console.WriteLine($"CEP: {cep} não encontrado");
                }
        }
    }
}
