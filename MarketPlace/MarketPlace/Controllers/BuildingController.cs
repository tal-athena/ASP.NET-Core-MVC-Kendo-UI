using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Models;
using Microsoft.AspNetCore.Mvc;


namespace MarketPlace.Controllers
{
    public class BuildingController : Controller
    {
        public JsonResult GetBuildings()
        {
            /*
            using (var northwind = GetContext())
            {
                return Json(northwind.buildings
                    .Select(c => new { id = c.id, CategoryName = c.CategoryName }).ToList());
            }
            */
            var buildings = new List<BuildingDto>();

            var building1 = new BuildingDto();
            building1.id = "0";
            building1.name = "building 1";
            buildings.Add(building1);

            var building2 = new BuildingDto();
            building2.id = "1";
            building2.name = "building 2";


            buildings.Add(building2);

            return Json(buildings);
        }

    }
}