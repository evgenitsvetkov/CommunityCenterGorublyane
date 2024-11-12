using CommunityCenterGorublyane.Core.Constants;
using CommunityCenterGorublyane.Core.Contracts;
using CommunityCenterGorublyane.Core.Models.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CommunityCenterGorublyane.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INewsService newsService;

        public NewsController(INewsService _newsService)
        {
            newsService = _newsService;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All([FromQuery] AllNewsQueryModel query)
        {
            var model = await newsService.AllAsync(
                query.SearchTerm,
                query.Sorting,
                query.CurrentPage,
                query.NewsPerPage);

            query.TotalNewsCount = model.TotalNewsCount;
            query.News = model.News;
            query.Comments = await newsService.AllCommentsAsync();

            return View(query);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await newsService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            var model = await newsService.NewsDetailsByIdAsync(id);

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = new NewsFormModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(NewsFormModel model)
        {
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            int newNewsId = await newsService.CreateAsync(model);

            TempData[MessageConstants.UserMessageSuccess] = "Вие добавихте новина успешно";

            return RedirectToAction(nameof(Details), new { id = newNewsId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (await newsService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var model = await newsService.GetNewsFormModelAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewsFormModel model)
        {
            if (await newsService.ExistsAsync(id) == false)
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

            await newsService.EditAsync(id, model);

            TempData[MessageConstants.UserMessageSuccess] = "Вие редактирахте новина успешно";

            return RedirectToAction(nameof(Details), new { id });
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (await newsService.ExistsAsync(id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            var news = await newsService.NewsDetailsByIdAsync(id);

            var model = new NewsDetailsViewModel()
            {
                Id = id,
                Title = news.Title,
                Content = news.Content,
                Date = news.Date,
                ImageUrl = news.ImageUrl
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(NewsDetailsViewModel model)
        {
            if (await newsService.ExistsAsync(model.Id) == false)
            {
                return BadRequest();
            }

            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }

            await newsService.DeleteAsync(model.Id);

            TempData[MessageConstants.UserMessageSuccess] = "Вие изтрихте новина успешно";

            return RedirectToAction(nameof(All));
        }

    }
}
