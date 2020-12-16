using Microsoft.VisualStudio.TestTools.UnitTesting;
using pix_dynamic_payload_generator.net;
using pix_dynamic_payload_generator.net.Models;
using pix_dynamic_payload_generator.net.Requests;
using System.Threading.Tasks;

namespace pix_dynamic_payload_generator.net_test
{
    [TestClass]
    public class UnitTest1
    {
        public UnitTest1()
        {
            new Start(
                _baseUrl: "https://api-pix-h.gerencianet.com.br",
                _clientId: "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69",
                _clientSecret: "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e",
                _certificatePath: @".\certificado.p12"
                );
        }

        [TestMethod]
        public void Generate()
        {
            var authorize = new Authorize(
                _baseUrl: "https://api-pix-h.gerencianet.com.br/oauth/token",
                _clientId: "Client_Id_51d92e9836716a4ab9b3ec1d9d34f6644ac28d69",
                _clientSecret: "Client_Secret_0ab77acbf2bde2cc40a1162f596846fa75ff710e",
                _certificate: @".\certificado.p12"
                );

            var t = authorize.GetToken();
        }

        [TestMethod]
        public async Task GenerateCob()
        {
            var cob = new Cob
            {
                Calendario = new Calendario
                {
                    Expiracao = 3600
                },
                Devedor = new Devedor
                {
                    Cnpj = "12345678000195",
                    Nome = "Empresa de Servi�os SA",
                },
                Valor = new Valor
                {
                    Original = "37.00"
                },
                Chave = "alelima.sep@gmail.com",
                SolicitacaoPagador = "Servi�o realizado.",
                InfoAdicionais = new System.Collections.Generic.List<InfoAdicional>
                {
                    new InfoAdicional
                    {
                        Nome = "Campo 1",
                        Valor = "Informa��o Adicional1 do PSP-Recebedor"
                    },
                    new InfoAdicional
                    {
                        Nome = "Campo 2",
                        Valor = "Informa��o Adicional2 do PSP-Recebedor"
                    }
                }
            };


            var cobOperation = new CobRequest();

            var cb = await cobOperation.Create(System.Guid.NewGuid().ToString("N"), cob);
        }
    }
}