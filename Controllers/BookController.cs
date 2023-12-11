using Microsoft.AspNetCore.Mvc;
using Sukuna.Business;
using Sukuna.Common.Resources.Book;
using Sukuna.Service.bookService;

namespace Sukuna.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/Sukuna")] // Permet de définir l'url de l'api 
public class BookController : Controller // Le controller est censé faire appel au Service pour ensuite renvoyer à l'utilisateur
{
    private readonly IBookService _bookService; // Attribut privé underscore alors que public Maj

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    } 

    [HttpPost]
    public IActionResult AddBook([FromBody] BookResource bookResource)
    {
        var result = _bookService.Add(bookResource);
            /// service.Create(bookResource);
        return Ok(result);
    }
    [HttpPost("update")]
    public IActionResult UpdateBook([FromBody] BookResource bookResource) // FromBody récuper la saisie utilisateur pour remplir les ressources 
    {
        var result = _bookService.Update(bookResource);
            ///service.Update(bookResource);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetBookId(int id) // Je recupere les données de la saie du get dans l'id 
    {
        return Ok(_bookService.Get(id));
            ///service.GetById(id));
    }
    [HttpGet]
    public IActionResult GetAllBook()
    {
        var result = _bookService.GetAll();
            ///service.GetAllBook();
        return Ok(result);
    }
    [HttpDelete]
    public IActionResult DeleteBook([FromBody] BookResource bookResource)
    {
        var result = _bookService.Delete(bookResource);
            ///service.Delete(bookResource);
        return Ok(result);
    }
}