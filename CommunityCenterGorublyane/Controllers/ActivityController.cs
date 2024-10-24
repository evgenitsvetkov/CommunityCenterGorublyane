using CommunityCenterGorublyane.Core.Models.Activity;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class ActivityController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllActivitiesQueryModel();
            
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new ActivityDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            var model = new ActivityFormModel();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, ActivityFormModel model)
        {
            return RedirectToAction(nameof(Details), new { id = "1" });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = new ActivityDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ActivityDetailsViewModel model)
        {
            return RedirectToAction(nameof(All));
        }

    } 
}
