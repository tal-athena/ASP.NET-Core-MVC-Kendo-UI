using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using MarketPlace.Models;
using Kendo.Mvc.Extensions;
using System.Net;
using System.Net.Http;
namespace MarketPlace.Controllers
{
    public class NetworkController : Controller
    {
        /*
        public async Task<ActionResult> Networks_Read([DataSourceRequest]DataSourceRequest request)
        {   
            HttpClient client = new HttpClient();

            List<NetworkDto> networks = null;

            HttpResponseMessage response = await client.GetAsync($"http://marketplaceapicore.azurewebsites.net/networks");
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                networks = await response.Content.ReadAsAsync<List<NetworkDto>>();
            }

            var dsResult = networks.ToDataSourceResult(request);
            return Json(dsResult);
        }
        */
        public ActionResult Networks_Read([DataSourceRequest]DataSourceRequest request, string building)
        {

            var poPoints = new List<PointDto>();
            var r = new PointDto();
            r.id = "asdf";
            r.name = "point";
            r.objectId = "obid";
            r.objectType = "dd";
            poPoints.Add(r);

            var deDevices = new List<DeviceDto>();
            var t = new DeviceDto();
            t.id = "asdf";
            t.ipAddress = "1.1.1.1";
            
            t.type = "woeig";
            t.deviceIdentifier = "iden";
            t.clientId = "clientId";
            t.buildingId = "deviceId";
            t.points = poPoints;
            deDevices.Add(t);

            var t1 = new DeviceDto();
            t1.id = "tegw";
            t1.ipAddress = "2.2.2.2";

            t1.type = "woeig";
            t1.deviceIdentifier = "iden";
            t1.clientId = "clientId";
            t1.buildingId = "deviceId";
            t1.points = poPoints;
            deDevices.Add(t1);

            var result = Enumerable.Range(0, 50).Where(i => building == null || (building != null && (i % 2).ToString() == building)).Select(i => new NetworkDto
            {
                id = i.ToString(),
                ipAddress = i.ToString(),
                type = (i + 1).ToString(),
                port = i,
                clientId = i.ToString(),
                buildingId = i.ToString(),
                devices = deDevices,                
            });

            var dsResult = result.ToDataSourceResult(request);
            return Json(dsResult);
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Network_Create([DataSourceRequest] DataSourceRequest request, NetworkDto networkData)
        {
            HttpClient client = new HttpClient();

            NetworkDto createdNetwork = null;
            if (networkData != null && ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                $"http://marketplaceapicore.azurewebsites.net/networks", networkData);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.
                createdNetwork = await response.Content.ReadAsAsync<NetworkDto>();
            }

            return Json(new[] { createdNetwork }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Client_Update([DataSourceRequest] DataSourceRequest request, NetworkDto networkData)
        {
            NetworkDto result = null;

            HttpClient client = new HttpClient();
            if (networkData != null && ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PutAsJsonAsync(
                $"http://marketplaceapicore.azurewebsites.net/networks/{networkData.id}", networkData);
                response.EnsureSuccessStatusCode();

                // Deserialize the updated product from the response body.
                result = await response.Content.ReadAsAsync<NetworkDto>();
                //result.logoUrl = clientData.logoUrl;
            }

            return Json(new[] { result }.ToDataSourceResult(request, ModelState));
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Client_Destroy([DataSourceRequest] DataSourceRequest request, NetworkDto networkData)
        {
            HttpClient client = new HttpClient();

            if (networkData != null)
            {
                HttpResponseMessage response = await client.DeleteAsync(
               $"http://marketplaceapicore.azurewebsites.net/networks/{networkData.id}");
            }

            return Json(new[] { networkData }.ToDataSourceResult(request, ModelState));
        }
    }
}
