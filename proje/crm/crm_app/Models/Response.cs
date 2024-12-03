using crm_app.Models;

namespace crm_app
{
    public class Response
    {
        public Parametters _parametters{get;set;}

        public Response(){
            _parametters = new Parametters();
        }
    }
}