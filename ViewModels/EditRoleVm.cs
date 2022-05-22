
using System.ComponentModel.DataAnnotations;

namespace cbsStudents.Models.Entities;
    public class EditRoleVm
    {
        public EditRoleVm()
        {
            Users = new List<string>();
        }
        public string Id { get; set; }

        [Required]
        public string RoleName { get; set; }
        public List<string> Users { get; set; }
    }