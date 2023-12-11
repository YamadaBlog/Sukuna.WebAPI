using Microsoft.AspNetCore.Mvc;
using Sukuna.Business;
using Sukuna.Common.Resources.Role;
using Sukuna.Service.roleSerivce;

namespace Sukuna.WebAPI.Controllers;

[ApiController]
[Route("api/[controller]/Sukuna")] // Permet de définir l'url de l'api 
public class RoleController : Controller // Le controller est censé faire appel au Service pour ensuite renvoyer à l'utilisateur
{
    private readonly IRoleService _roleService;

    public RoleController(IRoleService roleService)
    {
        _roleService = roleService;
    }

    [HttpPost]
    public IActionResult AddRole([FromBody] RoleResource roleResource)
    {
        var result = _roleService.Add(roleResource);
            /// service.Create(roleResource);
        return Ok(result);
    }
    [HttpPost("update")]
    public IActionResult UpdateRole([FromBody] RoleResource roleResource) // FromBody récuper la saisie utilisateur pour remplir les ressources 
    {
        var result = _roleService.Update(roleResource);
        return Ok(result);
    }
    [HttpGet("{id}")]
    public IActionResult GetRoleRoleId(int id) // Je recupere les données de la saie du get dans l'id 
    {
        return Ok(_roleService.Get(id));
    }
    [HttpGet]
    public IActionResult GetAllRole()
    {
        var result = _roleService.GetAll();
        return Ok(result);
    }
    [HttpDelete]
    public IActionResult DeleteRole([FromBody] RoleResource roleResource)
    {
        var result = _roleService.Delete(roleResource);
        return Ok(result);
    }

}