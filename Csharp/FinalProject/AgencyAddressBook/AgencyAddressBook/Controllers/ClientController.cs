using AgencyAddressBook.App_Start;
using AgencyAddressBook.Models;
using PagedList;
using System;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AgencyAddressBook.Controllers
{
    [Authorize]
    public class ClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Parameters for sort, filter, search, and current page
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.Model = "Client";
            ViewBag.ShowSearch = true;
            ViewBag.Title = "Clients";

            ViewBag.RecordExistsModalTitle = "Does the broker exist?";
            ViewBag.RecordExistsModalLinkYes = "#";
            ViewBag.RecordExistsModalLinkNo = "#";

            ViewBag.RecordSearchModalTitle = "Search for an existing record to add a client";
            ViewBag.RecordSearchModalLink = "/broker";
            //Note: First controller is basd on URL path 
            // Setting ViewBag variables to be used on view
            // So that if last name is clicked it'll be descending otherwise not
            // Same for the Date
            ViewBag.CurrentSort = sortOrder;
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "last_name_desc" : "";
            ViewBag.FirstNameSortParm = sortOrder == "first_name" ? "first_name_decs" : "first_name";
            ViewBag.EmailSortParm = sortOrder == "email" ? "email_decs" : "email";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            // If not URL path is  null, as in the initial load of the page
            // the page will start on the first batch of records
            // else show the paginated number
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // Setting for search filter
            ViewBag.CurrentFilter = searchString;

            // Variable for all the records
            var query = db.Clients.AsQueryable();

            // Shows the keyword of last or first name 
            if (!String.IsNullOrEmpty(searchString))
            {
                string[] collection = searchString.Split(' ', ',');
                foreach (var item in collection)
                {
                    query = query.Where(b =>
                              b.LastName.Contains(item)
                              || b.FirstName.Contains(item)
                              || b.ClientId.ToString().Contains(item)
                              || b.Email.Contains(item)
                              || b.City.Contains(item)
                              || b.State.ToString().Contains(item));
                }

                var result = query.ToList();

                int count = result.Count();

                ViewBag.SearchCount = count;
            }


            // Sorting scenarios for descending, ascending 
            switch (sortOrder)
            {
                case "last_name_desc":
                    query = query.OrderByDescending(r => r.LastName);
                    break;
                case "first_name":
                    query = query.OrderBy(r => r.FirstName);
                    break;
                case "first_name_desc":
                    query = query.OrderByDescending(r => r.FirstName);
                    break;
                case "email":
                    query = query.OrderBy(r => r.Email);
                    break;
                case "email_desc":
                    query = query.OrderByDescending(r => r.Email);
                    break;
                  default:
                    query = query.OrderBy(r => r.LastName);
                    break;
            }
            // Initial pageZise and page number
            //int pageSize = 6; see Config class
            int pageNumber = (page ?? 1);
            var panelColor = "info";
            ViewBag.PanelColor = (ViewBag.PanelColor != "") ? panelColor : "default";
            //Search Notification
            if (ViewBag.SearchCount == 1)
            {
                this.AddNotification($"A match is found!", NotificationType.SUCCESS);
            }
            if (ViewBag.SearchCount > 1)
            {
                this.AddNotification($"There are {ViewBag.SearchCount} records found.", NotificationType.SUCCESS);
            }
            if (ViewBag.SearchCount == 0)
            {
                this.AddNotification($"No records found.", NotificationType.ERROR);
            }
            return View(query.ToPagedList(pageNumber, Config.pageSize));
        }

        // GET: Client/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Title = "Client Details";
            ViewBag.PanelColor = "info";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Client/Create
        public ActionResult Create(int? brokerId)
        {
            ViewBag.Title = "Create Client";
            ViewBag.PanelColor = "info";

            ViewBag.BrokerId = new SelectList(db.Brokers, "Id", "FullName");
            var client = new Client();
            client.BrokerId = (int)brokerId;
            return View(client);
        }

        // POST: Client/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client client)
        {
            ViewBag.Title = "Create Client";
            ViewBag.PanelColor = "info";

            if (ModelState.IsValid)
            {

                var broker = db.Brokers.Single(b => b.Id == client.BrokerId);


                if (client.Email != null && db.Clients.Any(p => p.Email.ToLower() == client.Email.ToLower() && p.BrokerId == client.BrokerId))
                {


                    ModelState.AddModelError("Email", $"Email exists already");
                    this.AddNotification($"The client's email <strong>{client.Email}</strong> exists already under this broker.", NotificationType.ERROR);
                }
                else if (client.PhoneNumber != null && db.Brokers.Any(p => p.FirstName.ToLower() == client.FirstName.ToLower() &&
                     p.LastName.ToLower() == client.LastName.ToLower() && p.PhoneNumber == client.PhoneNumber))
                {

                    this.AddNotification($"The client <strong>{client.FirstName} {client.LastName} with {client.PhoneNumber}</strong> exists already under this broker.", NotificationType.ERROR);
                }
                else if (db.Brokers.Any(p => p.FirstName.ToLower() == client.FirstName.ToLower() &&
                    p.LastName.ToLower() == client.LastName.ToLower()))
                {
                    this.AddNotification($"The client name <strong>{client.FirstName} {client.LastName}</strong> might be a duplicate under this broker. If it is, please delete it.", NotificationType.WARNING);
                    broker.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Create", "Client", new { BrokerId = client.BrokerId });
                }
                else
                {
                    broker.Clients.Add(client);
                    db.SaveChanges();
                    this.AddNotification($"A record for {client.FullName} is created.", NotificationType.SUCCESS);
                    return RedirectToAction("Details", "Client", new { id = client.ClientId });
                }

            }

            ViewBag.BrokerId = new SelectList(db.Brokers, "Id", "FullName", client.BrokerId);
            return View(client);
        }

        // GET: Client/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit Clients";
            ViewBag.PanelColor = "info";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.BrokerId = new SelectList(db.Brokers, "Id", "FullName", client.BrokerId);
            return View(client);
        }

        // POST: Client/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            ViewBag.Title = "Edit Clients";
            ViewBag.PanelColor = "info";



            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var clientToUpdate = db.Clients.Find(id);
            db.Entry(clientToUpdate).State = System.Data.Entity.EntityState.Modified;

            //var clientToUpdate = db.Clients.Include(i => i.Broker).Where(i => i.Id == id);
            if (TryUpdateModel(clientToUpdate, "", new string[] {
                "ClientId", "BrokerId", "FirstName", "LastName", "Address",
                "City", "State", "ZipCode", "PhoneNumber", "Email", "DateCreated" }))
            {
                try
                {
                    db.SaveChanges();
                    TempData["messageResult"] = $"Successfully made an update on {clientToUpdate.FullName}'s record.";
                    return RedirectToAction("Details", "Client", new { id = clientToUpdate.ClientId });
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem continues, see your system admin.");
                }
            }
            ViewBag.BrokerId = new SelectList(db.Brokers, "Id", "FullName", clientToUpdate.BrokerId);
            return View(clientToUpdate);
        }

        [Authorize]
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            ViewBag.Title = "Delete Client Record";
            ViewBag.PanelColor = "info";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, if the problem continues see your system admin.";
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete Client Record";
            ViewBag.PanelColor = "info";
            try
            {
                Client client = db.Clients.Find(id);
                db.Clients.Remove(client);
                db.SaveChanges();
                TempData["messageResult"] = $"Okay, I deleted {client.FullName}.";
                return RedirectToAction("Details", "Broker", new { id = client.BrokerId });
            }
            catch (DataException/* dex */)
            {

                //Log the error (uncomment dex)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
