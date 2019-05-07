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
    public class ProjectController : Controller
    {
        public async Task<ActionResult> Projects_Read([DataSourceRequest]DataSourceRequest request)
        {

            HttpClient client = new HttpClient();

            List<ProjectDto> projects = null;

            HttpResponseMessage response = await client.GetAsync($"https://uxexternalapi.azurewebsites.net/projects/");
            Console.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                projects = await response.Content.ReadAsAsync<List<ProjectDto>>();
            }

            var dsResult = projects.ToDataSourceResult(request);
            return Json(dsResult);
        }
        [AcceptVerbs("Post")]
        public async Task<ActionResult> Project_Create([DataSourceRequest] DataSourceRequest request, CreateProjectRequestDto projectData)
        {
            HttpClient client = new HttpClient();

            if (projectData != null && ModelState.IsValid)
            {
                HttpResponseMessage response = await client.PostAsJsonAsync(
                $"https://uxexternalapi.azurewebsites.net/projects/", projectData);
                response.EnsureSuccessStatusCode();

                // return URI of the created resource.

            }

            return Json(new[] { projectData }.ToDataSourceResult(request, ModelState));
        }
    }
}
