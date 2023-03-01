using CSC2037_Case1_SportsPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CSC2037_Case1_SportsPro.Controllers
{
    public class IncidentController : Controller
    {
        private SportsProContext context { get; set; }
        public IncidentController(SportsProContext ctx) => context = ctx;

        public IActionResult Index() => RedirectToAction("List");

        public IActionResult List()
        {
            List<Incident> incidents = context.Incidents
                .Include(i => i.Customer)
                .Include(i => i.Product)
                .OrderBy(i => i.DateOpened)
                .ToList();

            return View(incidents);
        }

        public void StoreDataInViewBag(string action)
        {
            ViewBag.Action = action;

            ViewBag.Customers = context.Customers
                .OrderBy(c => c.FirstName)
                .ToList();

            ViewBag.Products = context.Products
                .OrderBy(c => c.Name)
                .ToList();

            ViewBag.Technicians = context.Technicians
                .OrderBy(c => c.Name)
                .ToList();
        }

        [HttpGet]
        public IActionResult Add()
        {
            StoreDataInViewBag("Add");

            return View("AddEdit", new Incident());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            StoreDataInViewBag("Edit");

            var product = context.Incidents.Find(id);

            return View("AddEdit", product);
        }

        [HttpPost]
        public IActionResult Save(Incident incident)
        {
            if (ModelState.IsValid)
            {
                if (incident.IncidentID == 0)
                {
                    context.Incidents.Add(incident);
                }
                else
                {
                    context.Incidents.Update(incident);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                if (incident.IncidentID == 0)
                {
                    StoreDataInViewBag("Add");
                }
                else
                {
                    StoreDataInViewBag("Edit");
                }
                return View("AddEdit", incident);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var product = context.Incidents.Find(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Incident incident)
        {
            context.Incidents.Remove(incident);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}