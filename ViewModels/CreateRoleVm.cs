using System.ComponentModel.DataAnnotations;

namespace cbsStudents.Models.Entities;

public class CreateRoleVm
{
    [Required]
    public string RoleName {get; set;}
}