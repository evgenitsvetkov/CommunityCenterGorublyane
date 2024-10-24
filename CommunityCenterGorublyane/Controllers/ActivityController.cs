using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.Activity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunityCenterGorublyane.Controllers
{
    public class ActivityController : BaseController
    {
        private readonly IActivityService activityService;

        public ActivityController(IActivityService _activityService)
        {
            activityService = _activityService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var model = new AllActivitiesQueryModel();
            
            return View(model);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details()
        {
            var model = new ActivityDetailsViewModel();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ActivityFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ActivityFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            int newActivityId = await activityService.CreateAsync(model);

            return RedirectToAction(nameof(Details), new { id = newActivityId });
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
