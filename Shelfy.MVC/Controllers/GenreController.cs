using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelfy.Models.GenreModels;
using Shelfy.Services.GenreServices;

namespace Shelfy.MVC.Controllers
{
    public class GenreController : Controller
    {
        private IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IActionResult>Index()
        {
            return View(await _genreService.GetGenre());
        }

        public async Task<IActionResult>Details (int id)
        {
            var genre = await _genreService.GetGenre(id);
            if (genre == null)
            {
                return NotFound();
            }
            return View(genre);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult>CreateGenre (GenreCreate genre)
        {
            if (!ModelState.IsValid)
            {
                return View(ModelState);
            }
            if (await _genreService.CreateGenre(genre))
            return RedirectToAction(nameof(Index));
            else return View(ModelState);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var genre = await _genreService.GetGenre(id);
            var genreEdit = new GenreEdit
            {
                Id = genre.Id,
                GenreName = genre.GenreName
            };
            return View(genreEdit);
        }

        public async Task<IActionResult> GenreEdit(GenreEdit model)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(await _genreService.UpdateGenre(model))
            return RedirectToAction(nameof(Index));
            else return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var genre = await _genreService.GetGenre(id.Value);
            return View(genre);
        }

        public async Task<IActionResult> DeleteGenre(int Id)
        {
            var isSuccessful = await _genreService.DeleteGenre(Id);
            if (isSuccessful)
            return RedirectToAction(nameof(Index));
            else return UnprocessableEntity();
        }
    }
}