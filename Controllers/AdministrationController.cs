using cbsStudents.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using CbsStudents.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace cbsStudents.Controllers;

[Authorize(Roles ="Admin")]
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

    // Returnere Create viewet
    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    // Opretter en rolle i databasen
    [HttpPost]
    public async Task<IActionResult> Create(CreateRoleVm roleVm)
    {
        if(ModelState.IsValid)
        {
            // Opretter tom identity role og sætter dens rolle navn til at være det der er i View Model
            IdentityRole identityRole = new IdentityRole
            {
                Name = roleVm.RoleName
            };
            // Gemmer resultatet i Databasen
            IdentityResult result = await _roleManager.CreateAsync(identityRole);
            if(result.Succeeded)
            {
                // Hvis operationen lykkes sendes vi videre
                return RedirectToAction("ListRoles", "Administration");
            }

            foreach(IdentityError error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }

        }
        return View(roleVm);
    }


    // Returnerer en liste af alle rollerne der er oprettet
    [HttpGet]
    public IActionResult ListRoles()
    {
        var roles = _roleManager.Roles;
        return View(roles);
    }



    // Vi har valgt en Rolle fra Listmodels viewet og den returnere det rolle objekt
    [HttpGet]
    public async Task<IActionResult> EditRole(string id)
    {
        // Finder rollen vha dens id
        var role = await _roleManager.FindByIdAsync(id);
        // Hvis den ikke kan finde rollen sendes vi tilbage til List Roles viewet
        if(role==null)
        {
            ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
            return View("ListRoles");
        }
        // Laver Identity Role variablerne i et View Model
        var model = new EditRoleVm
        {
            Id = role.Id,
            RoleName = role.Name
        };
        // Finder aller Users som er i valgte rolle og tilføjer dem til en liste i View Modellen 
        foreach (var user in _userManager.Users)
        {
            if(await _userManager.IsInRoleAsync(user, role.Name))
            {
                model.Users.Add(user.UserName);
            }
        }
        return View(model);
    }



    // Vi har ændret i rolle navnet i Edit Role Viewet
    [HttpPost]
    public async Task<IActionResult> EditRole(EditRoleVm model)
    {   
        // Finder Rollen via dens id
        var role = await _roleManager.FindByIdAsync(model.Id);

        if(role==null)
        {
            ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
            return View("ListRoles");
        } 
        else
        {
            // Her ændrer vi Rollens navn til det vi har specificeret i View Model og gemmer det bagefter
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



    // Her henter vi alle brugerne og den rolle vi har specificeret
    [HttpGet]
    public async Task<IActionResult> EditUsersInRole(string roleId)
    {
        ViewBag.roleId = roleId;
        // Henter rollen ud fra dens id
        var role = await _roleManager.FindByIdAsync(roleId);

        if(role == null)
        {
            ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found";
            return View("ListRoles");
        }

        // Laver en liste over vores Users men kun med de nødvendige informationer
        var model = new List<UserRoleVm>();

        // Henter alle brugere og hvis de er i en rolle sætter IsSelected til at være sandt ellers falsk
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





    // Her fjerner vi users fra roller og eller tilføjer dem
    [HttpPost]
    public async Task<IActionResult> EditUsersInRole(List<UserRoleVm> model, string roleId)
    {
        // Finder rollen ud fra dens id
        var role = await _roleManager.FindByIdAsync(roleId);

        if(role == null)
        {
            ViewBag.ErrorMessage = $"Role with id = {roleId} cannot be found";
            return View("ListRoles");
        }
        // Itererer igennem vores liste af users 
        for (int i = 0; i < model.Count; i++)
        {
            // Henter en user ud fra dens id
            var user = await _userManager.FindByIdAsync(model[i].UserId);
            IdentityResult result = null;
            // Hvis vi har valgt en user til at være i en rolle og han ikke allerede er i en så vil han blive tilføjet til rollen
            // Hvis afvælger en bruger og han er i en rolle vil han blive fjernet fra sin rolle 
            if(model[i].IsSelected && !(await _userManager.IsInRoleAsync(user, role.Name)))
            {
                result = await _userManager.AddToRoleAsync(user,role.Name);
            } else if(!model[i].IsSelected && await _userManager.IsInRoleAsync(user, role.Name)){
                result = await _userManager.RemoveFromRoleAsync(user,role.Name);
            } else {
                continue;
            }
            // Her tjekker vi om hvert user result er succeded og om loopet er færdig med at itererer
            // Hvis alle resultater er gået godt og loopet er færdig med at itererer så bliver vi redirected.
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