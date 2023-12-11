using Microsoft.AspNetCore.Mvc;
using Sukuna.Business;
using Sukuna.Common.Resources.User;
using Sukuna.Service.userService;

namespace Sukuna.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/Sukuna")] // Permet de définir l'url de l'api 
public class UserController : Controller // Le controller est censé faire appel au Service pour ensuite renvoyer à l'utilisateur
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] UserResource userResource)
    {
        var result = _userService.Add(userResource);
            /// service.Create(userResource);
        return Ok(result);
    }
    [HttpPost("update")]
    public IActionResult UpdateUser([FromBody] UserResource userResource) // FromBody récuper la saisie utilisateur pour remplir les ressources 
    {
        var result = _userService.Update(userResource);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetUserId(int id) // Je recupere les données de la saie du get dans l'id 
    {
        return Ok(_userService.Get(id));
    }
    [HttpGet]
    public IActionResult GetAllUser()
    {
        var result = _userService.GetAll();
        return Ok(result);
    }
    [HttpDelete]
    public IActionResult DeleteUser([FromBody] UserResource userResource)
    {
        var result = _userService.Delete(userResource);
        return Ok(result);
    }
}