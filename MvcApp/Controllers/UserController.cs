using System.Threading.Tasks;
using Domain.DTOS;
using Domain.DTOS.UserDTO;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MvcApp.Controllers;

// [ApiController]
// [Route("api/[controller]")]
public class UserController(IUserService userService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(userService.GetAllUsersAsync());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDTO createUserDTO)
    {
        if (!ModelState.IsValid)
        {
            return View(createUserDTO);
        }

        await userService.CreateUserAsync(createUserDTO);
        return RedirectToAction("Index");

    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var user = await userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, UpdateUserDTO updateUserDTO)
    {
        if (!ModelState.IsValid)
        {
            return View(updateUserDTO);
        }

        await userService.UpdateUserAsync(id, updateUserDTO);
        return RedirectToAction("Index");
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await userService.DeleteUserAsync(id);
        return RedirectToAction("Index");
    }
}
