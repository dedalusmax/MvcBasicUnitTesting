using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        // simulate database with a static list
        private static List<Account> _accounts;

        public AccountController()
        {
            if (_accounts == null)
            {
                _accounts = new List<Account>
            {
                new Account { Id = 1, Name = "Tekući račun", Total = 1000.00M },
                new Account { Id = 2, Name = "Štedni račun", Total = 5000.00M },
                new Account { Id = 3, Name = "Devizni račun", Total = 3000.00M }
            };
            }
        }

        // GET: AccountController
        public ActionResult Index()
        {
            //var lista = new List<Account> { 
            //    new Account { Id = 1, Name = "Tekući račun", Total = 1000.00M },
            //};

            return View(_accounts);
        }

        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            var account = _accounts.SingleOrDefault(a => a.Id == id);

            return View(account);
        }

        // GET: AccountController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account model)
        {
            try
            {
                _accounts.Add(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var account = _accounts.SingleOrDefault(a => a.Id == id);

            return View(account);
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var account = _accounts.SingleOrDefault(a => a.Id == id);

            return View(account);
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Account model)
        {
            try
            {
                var account = _accounts.SingleOrDefault(a => a.Id == id);

                if (account != null)
                {
                    _accounts.Remove(account);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
