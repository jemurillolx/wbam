using wbam.mypages.Models.Communication;
using wbam.mypages.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Threading;
using wbam.mypages.Models;

namespace wbam.mypages
{
    public partial class dashboardBam : System.Web.UI.Page
    {
        protected static readonly ClientService clientService = new ClientService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //var pageAsyncTask = new PageAsyncTask(x => ClientsAsync(x, ""));
                var pageAsyncTask = new PageAsyncTask(x => ClientByIDAsync(x, "5f9c825b286d04b489edaf96"));

                this.RegisterAsyncTask(pageAsyncTask);
            }
        }

        protected async Task ClientsAsync(CancellationToken cancellationTokem, string dato)
        {
            var result = await clientService.GetAllClientsAsync(dato);
            if (result.HttpResponseStatusCode.Equals(HttpStatusCode.OK))
            {
                List<Clientbam> clientes = result.Value;
                int i = 1;
                foreach (Clientbam icl in clientes)
                {
                    string id = icl._id;

                    i++;
                }
                return;
            }
            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', '" + result.Message + "', 'error');", true);
        }

        protected async Task ClientByIDAsync(CancellationToken cancellationTokem, string _id)
        {
            var result = await clientService.GetByIdClientsAsync(_id);
            if (result.HttpResponseStatusCode.Equals(HttpStatusCode.OK))
            {
                List<Clientbam> clientes = result.Value;
                int i = 1;
                foreach (Clientbam icl in clientes)
                {
                    string id = icl._id;

                    i++;
                }
                return;
            }
            ScriptManager.RegisterStartupScript(this, typeof(string), "Mensaje", "swal('¡Advertencia!', '" + result.Message + "', 'error');", true);
        }


       
    }
}