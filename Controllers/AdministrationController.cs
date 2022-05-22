using cbsStudents.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CbsStudents.Data;
using Microsoft.AspNetCore.Identity;


namespace cbsStudents.Controllers;
public class AdministrationController : Controller
{
    private readonly CbsStudentsContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    public AdministrationController(RoleManager<IdentityRole> roleManager,CbsStudentsContext context,UserManager<IdentityUser> userManager)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _context = context;
    }
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleVm roleVm)
    {
        if(ModelState.IsValid)
        {
            IdentityRole identityRole = new IdentityRole
            {
                Name = roleVm.RoleName
            };
            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles", "Administration");
            }

            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

        }
        return View(roleVm);
    }
    [HttpGet]
    public IActionResult ListRoles()
    {
        var roles = _roleManager.Roles;
        return View(roles);
    }
    [HttpGet]
    public async Task<IActionResult> EditRole(string id)
    {
        var role = await _roleManager.FindByIdAsync(id);
        if(role==null)
        {
            ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
            return View("ListRoles");
        }
        var model = new EditRoleVm
        {
            Id = role.Id,
            RoleName = role.Name
        };

        foreach (var user in _userManager.Users)
        {
            if(await _userManager.IsInRoleAsync(user, role.Name))
            {
                model.Users.Add(user.UserName);
            }
        }
        return View(model);


    }
    [HttpPost]
    public async Task<IActionResult> EditRole(EditRoleVm model)
    {
        var role = await _roleManager.FindByIdAsync(model.Id);

        if(role==null)
        {
            ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
            return View("ListRoles");
        } 
        else
        {
            role.Name = model.RoleName;
            var result = await _roleManager.UpdateAsync(role);

            if(result.Succeeded)
            {
                return RedirectToAction("ListRoles");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }
        return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> EditUsersInRole(string roleId)
    {
        ViewBag.roleId = roleId;
        
        var role = await _roleManager.FindByIdAsync(roleId);

        if(role == null)
        {
            ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found";
            return View("ListRoles");
        }
        var model = new List<UserRoleVm>();

        foreach (var user in _userManager.Users)
        {
            var UserRoleVm = new UserRoleVm
            {
                UserId = user.Id,
                UserName = user.UserName
            };
            if (await _userManager.IsInRoleAsync(user, role.Name))
            {
                UserRoleVm.IsSelected = true;
            } else {
                UserRoleVm.IsSelected = false;
            }
            model.Add(UserRoleVm);
        }
        return View(model);

    }
    [HttpPost]
    public async Task<IActionResult> EditUsersInRole(List<UserRoleVm> model, string roleId)
    {
        var role = await _roleManager.FindByIdAsync(roleId);

        if(role == null)
        {
            ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found";
            return View("ListRoles");
        }
        for (int i = 0; i < model.Count; i++)
        {
            var user = await _userManager.FindByIdAsync(model[i].UserId);
            IdentityResult result = null;

            if(model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
            {
                result = await _userManager.AddToRoleAsync(user,role.Name);
            } else if(!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name)){
                result = await _userManager.RemoveFromRoleAsync(user,role.Name);
            } else {
                continue;
            }

            if (result.Succeeded)
            {
                if (i < (model.Count - 1))
                {
                    continue;
                } else
                {
                    return RedirectToAction("EditRole", new {Id = roleId});
                } 
            }










        }
        
        return RedirectToAction("EditRole", new {Id = roleId});

    }
    




}