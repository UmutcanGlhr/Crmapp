using Entities.Dtos;
using KaraozKPS;

namespace crm_app.Models
{
    public class ServiceKPSPublic
    {
        public async Task<bool> OnGetService(Parametters parametters)
        {
            bool res = false;
            var client = new KPSPublicSoapClient(KPSPublicSoapClient.EndpointConfiguration.KPSPublicSoap);
            var response = await client.TCKimlikNoDogrulaAsync(parametters.TcKimlikNo,parametters.Ad,parametters.SoyAd,parametters.dogumyili);
            return res = response.Body.TCKimlikNoDogrulaResult;
        }
    }
}