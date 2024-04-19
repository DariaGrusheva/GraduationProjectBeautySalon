using BeautySalon.Context;
using BeautySalon.Models.Feedback;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeautySalon.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly BsContext _context;
        public FeedbackController(BsContext context)
        {
            _context = context;
        }

        // GET: FeedbackController
        public async Task<ActionResult> Index()
        {
            List<Feedback> feedbacks = await _context.Feedbacks.OrderByDescending(f => f.DateFeedback)
                .ToListAsync();
            return View(feedbacks);
        }

        // POST: FeedbackController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string criticName, string feedback)
        {
            try
            {
                
                if(!String.IsNullOrEmpty(feedback))
                {
                    Feedback newFeedbak = new Feedback();
                    newFeedbak.FeedbackThis = feedback;
                    if(!String.IsNullOrEmpty(criticName))
                        newFeedbak.NameCritic = criticName;

                    _context.Feedbacks.Add(newFeedbak);
                    _context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FeedbackController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FeedbackController/Edit/5
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

        // GET: FeedbackController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FeedbackController/Delete/5
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
