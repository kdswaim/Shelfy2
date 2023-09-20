using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shelfy.Models.AuthorModels;
using Shelfy.Services.AuthorServices;

namespace Shelfy.MVC.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        public async Task<IActionResult>Index()
        {
            return View(await _authorService.GetAuthor());
        }

        public async Task<IActionResult> Details(int id)
      {
          var author = await _authorService.GetAuthor(id);
          if (author == null)
          {
              return NotFound();
          }
          return View(author);
      }

     public async Task<IActionResult> Create()
      {
            return View();
      }

      public async Task<IActionResult> CreateAuthor(AuthorCreate author)
      {
        if (!ModelState.IsValid) 
        {
            return View(ModelState);
        }
        if (await _authorService.CreateAuthor(author))
        return RedirectToAction(nameof(Index));
        else 
        {
            return View(ModelState);
        }
          
      }

[HttpGet]
[Route("Edit/{id}")]
      public async Task<IActionResult> Edit(int id)
      {
        var author = await _authorService.GetAuthor(id);
        var authorEdit = new AuthorEdit
        {
            AuthorId = author.AuthorId,
            Name = author.Name,
            Biography = author.Biography,
            Website = author.Website
        };
        return View(authorEdit);
      }

      [HttpPost]
      [Route("Edit/{id}")]
      [ValidateAntiForgeryToken]
      public async Task<IActionResult> Edit(int id, AuthorEdit model)
      {
            if(id!=model.AuthorId) return BadRequest("Invalid Id");
            if(!ModelState.IsValid) return BadRequest(ModelState);
            if(await _authorService.UpdateAuthor(model))
            return RedirectToAction(nameof(Index));
            else
            return View(model);
      }

[HttpGet]
[Route("Delete/{id}")]
      public async Task<IActionResult> Delete(int? id)
      {
        var author = await _authorService.GetAuthor(id.Value);
        return View(author);
      }

      [HttpPost]
      [Route("Delete/{id}")]
      public async Task<IActionResult> Delete(int id)
      {
        var isSuccessful = await _authorService.DeleteAuthor(id);
        if (isSuccessful)
        return RedirectToAction(nameof(Index));
        else
        return UnprocessableEntity();
      }

        }
    }
