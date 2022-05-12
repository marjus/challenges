using L1.Models;
using L1.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace L1.Controllers
{
    public class GrammarController : Controller
    {
        // GET: GrammarController
        public ActionResult Index()
        {
            var game = new GrammarGameVM();
            var grammar = new List<Grammar>();

            grammar.Add(new Grammar { Id = 1, Name = "Hamari", Image = "H", Description="" });
            grammar.Add(new Grammar { Id = 2, Name = "Bilur", Image = "B", Description = "" });
            grammar.Add(new Grammar { Id = 3, Name = "Flogfar", Image = "F", Description = "" });
            grammar.Add(new Grammar { Id = 4, Name = "Ostur", Image = "O", Description = "" });

            var chosenIndex = new Random().Next(0, 4);
            game.PresentedCard = grammar[chosenIndex];

            game.Cards = grammar;

            return View(game);
        }

        // GET: GrammarController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GrammarController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GrammarController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: GrammarController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GrammarController/Edit/5
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

        // GET: GrammarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GrammarController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
