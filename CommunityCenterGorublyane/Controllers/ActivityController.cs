using CommunityCenterGorublyane.Core.Constants;
using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Extensions;
using CommunityCenterGorublyane.Core.Models.Activity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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
        public async Task<IActionResult> All([FromQuery] AllActivitiesQueryModel query)
        {
            var model = await activityService.AllAsync(
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.ActivitiesPerPage);

            query.TotalActivitiesCount = model.TotalActivitiesCount;
            query.Activities = model.Activities;

            return View(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id, string information)
        {
            if (await activityService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await activityService.ActivityDetailsByIdAsync(id);

            if (information != model.GetInformation())
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new ActivityFormModel();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(ActivityFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            int newActivityId = await activityService.CreateAsync(model);

            TempData[MessageConstants.UserMessageSuccess] = "Вие добавихте дейност успешно";

            return RedirectToAction(nameof(Details), new { id = newActivityId, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await activityService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await activityService.GetActivityFormModelAsync(id);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ActivityFormModel model)
        {
            if (await activityService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await activityService.EditAsync(id, model);

            TempData[MessageConstants.UserMessageSuccess] = "Вие редактирахте дейност успешно";

            return RedirectToAction(nameof(Details), new { id, information = model.GetInformation() });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await activityService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var activity = await activityService.ActivityDetailsByIdAsync(id);

            var model = new ActivityDetailsViewModel()
            {
                Id = id,
                Title = activity.Title,
                Description = activity.Description,
                Contact = activity.Contact,
                ImageUrl = activity.ImageUrl,
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(ActivityDetailsViewModel model)
        {
            if (await activityService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await activityService.DeleteAsync(model.Id);

            TempData[MessageConstants.UserMessageSuccess] = "Вие изтрихте дейност успешно";

            return RedirectToAction(nameof(All));
        }

    } 
}
