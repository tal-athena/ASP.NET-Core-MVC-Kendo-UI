using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using SimpleTask.Models;
using Kendo.Mvc.Extensions;
using System.Net;
using System.Net.Http;

namespace SimpleTask.Controllers
{
    public class ClientController : Controller
    {
        public async Task<ActionResult> Clients_Read([DataSourceRequest]DataSourceRequest request)
        {

            HttpClient client = new HttpClient();

            List<ClientDto> clients = null;

            HttpResponseMessage response = await client.GetAsync($"https://uxexternalapi.azurewebsites.net/clients/");
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                clients = await response.Content.ReadAsAsync<List<ClientDto>>();
            }

            var dsResult = clients.ToDataSourceResult(request);
            return Json(dsResult);
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Client_Create([DataSourceRequest] DataSourceRequest request, CreateClientRequestDto clientData)
        {
            HttpClient client = new HttpClient();

            ClientDto createdClient = null;
            if (clientData != null && ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                $"https://uxexternalapi.azurewebsites.net/clients/", clientData);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                createdClient = await response.Content.ReadAsAsync<ClientDto>();
            }

            return Json(new[] { createdClient }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Client_Update([DataSourceRequest] DataSourceRequest request, ClientDto clientData)
        {
            ClientDto result = null;

            HttpClient client = new HttpClient();
            if (clientData != null && ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(
                $"https://uxexternalapi.azurewebsites.net/clients/{clientData.id}", clientData);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                result = await response.Content.ReadAsAsync<ClientDto>();
                //result.logoUrl = clientData.logoUrl;
            }

            return Json(new[] { result }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Client_Destroy([DataSourceRequest] DataSourceRequest request, ClientDto clientData)
        {
            HttpClient client = new HttpClient();

            if (clientData != null)
            {
                HttpResponseMessage response = await client.DeleteAsync(
               $"https://uxexternalapi.azurewebsites.net/clients/{clientData.id}");
            }

            return Json(new[] { clientData }.ToDataSourceResult(request, ModelState));
        }
    }
    
}
