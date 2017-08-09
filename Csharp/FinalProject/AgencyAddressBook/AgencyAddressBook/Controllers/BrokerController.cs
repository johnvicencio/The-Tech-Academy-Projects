using AgencyAddressBook.App_Start;
using AgencyAddressBook.Models;
using PagedList;
using System;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AgencyAddressBook.Controllers
{
    [Authorize]
    public class BrokerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        // GET: Broker
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.Model = "Broker";
            ViewBag.ShowSearch = true;
            ViewBag.Title = "AAB Brokers";

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
            //var result = from b in db.Brokers select b;
            var query = db.Brokers.AsQueryable();

            // Shows the keyword of last or first name 
            if (!String.IsNullOrEmpty(searchString))
            {

                string[] collection = searchString.Split(' ', ',');
                foreach (var item in collection)
                {
                    query = query.Where(b =>
                              b.LastName.Contains(item)
                              || b.FirstName.Contains(item)
                              || b.Id.ToString().Contains(item)
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
                    query = query.OrderByDescending(b => b.LastName);
                    break;
                case "first_name":
                    query = query.OrderBy(b => b.FirstName);
                    break;
                case "first_name_desc":
                    query = query.OrderByDescending(b => b.FirstName);
                    break;
                case "email":
                    query = query.OrderBy(b => b.Email);
                    break;
                case "email_desc":
                    query = query.OrderByDescending(b => b.Email);
                    break;
                default:
                    query = query.OrderBy(b => b.LastName);
                    break;
            }
            // Initial pageZise and page number
            //int pageSize = 6; see Config class
            int pageNumber = (page ?? 1);
            var panelColor = "danger";
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

        // GET: Broker/Details/5
        public ActionResult Details(int? id)
        {
            ViewBag.Title = "AAB Broker Details";
            ViewBag.PanelColor = "danger";

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = db.Brokers.Find(id);

            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        // GET: Broker/Create
        public ActionResult Create()
        {
            ViewBag.Title = "Create AAB Broker";
            ViewBag.PanelColor = "danger";
            return View();
        }

        // POST: Broker/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[Bind(Include = "FirstName,LastName,Address,City,State,ZipCode,PhoneNumber,Email,DateCreated")] 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Broker broker)
        {
            ViewBag.Title = "Create AAB Broker";
            ViewBag.PanelColor = "danger";

            try
            {
                if (ModelState.IsValid)
                {

                    if (broker.Email != null && db.Brokers.Any(p => p.Email.ToLower() == broker.Email.ToLower()))
                    {
                        ModelState.AddModelError("Email", $"Email exists already");
                        this.AddNotification($"The email <strong>{broker.Email}</strong> exists already.", NotificationType.ERROR);
                    }
                    else if (broker.PhoneNumber != null && db.Brokers.Any(p => p.FirstName.ToLower() == broker.FirstName.ToLower() &&
                         p.LastName.ToLower() == broker.LastName.ToLower() && p.PhoneNumber == broker.PhoneNumber))
                    {
                        this.AddNotification($"The broker <strong>{broker.FirstName} {broker.LastName} with {broker.PhoneNumber}</strong> exists already.", NotificationType.ERROR);
                    }
                    else if (db.Brokers.Any(p => p.FirstName.ToLower() == broker.FirstName.ToLower() &&
                        p.LastName.ToLower() == broker.LastName.ToLower()))
                    {
                        this.AddNotification($"The broker name <strong>{broker.FirstName} {broker.LastName}</strong> might be a duplicate. If it is, please delete it.", NotificationType.WARNING);
                        db.Brokers.Add(broker);
                        db.SaveChanges();
                        return RedirectToAction("Index", "Broker");
                    }
                    else
                    {
                        db.Brokers.Add(broker);
                        db.SaveChanges();
                        this.AddNotification($"A record for {broker.FullName} is created.", NotificationType.SUCCESS);
                        return RedirectToAction("Details", "Broker", new { id = broker.Id });
                    }
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex)
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem continues see your system admin.");
            }
            return View(broker);
        }

        // GET: Broker/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Title = "Edit AAB Broker";
            ViewBag.PanelColor = "danger";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Broker broker = db.Brokers.Find(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        // POST: Broker/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? Id)
        {
            ViewBag.Title = "Edit AAB Broker";
            ViewBag.PanelColor = "danger";
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var brokerToUpdate = db.Brokers.Find(Id);
            if (TryUpdateModel(brokerToUpdate, "", new string[] {
                "FirstName", "LastName", "Address", "City",
                "State", "ZipCode", "PhoneNumber", "Email", "DateCreated" }))
            {
                try
                {
                    db.SaveChanges();
                    this.AddNotification($"A record for {brokerToUpdate.FullName} is update.", NotificationType.SUCCESS);

                    return RedirectToAction("Details", "Broker", new { id = brokerToUpdate.Id });
                }
                catch (DataException /* dex */)
                {

                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem continues see your system admin.");
                }

            }

            return View(brokerToUpdate);
        }

        // GET: Broker/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            ViewBag.Title = "Delete AAB Broker";
            ViewBag.PanelColor = "danger";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                this.AddNotification($"Delete failed. Try again, if the problem continues see your system admin.", NotificationType.ERROR);

            }
            Broker broker = db.Brokers.Find(id);
            if (broker == null)
            {
                return HttpNotFound();
            }
            return View(broker);
        }

        // POST: Broker/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            ViewBag.Title = "Delete AAB Broker";
            ViewBag.PanelColor = "danger";
            try
            {
                Broker broker = db.Brokers.Find(id);
                db.Brokers.Remove(broker);
                db.SaveChanges();
                this.AddNotification($"A record for {broker.FullName} is deleted.", NotificationType.SUCCESS);

            }
            catch (DataException/* dex */)
            {

                //Log the error (uncomment dex)
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

            return RedirectToAction("Index");
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
