using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cbsStudents.Models.Entities;

public class Post
{
    public int PostId { get; set; }

    [Required(ErrorMessage = "Please fill out this field")]
    [MinLength(3)]
    public string Title { get; set; }


    [Required(ErrorMessage = "Please fill out this field")]
    [MinLength(10)]
    public string Text { get; set; }

    [Display(Name ="Last Edit")]
    [DataType(DataType.Date)]
    public DateTime Created { get; set; }

    public PostStatus Status { get; set; }

    public List<Comment> Comments { get; set; }

    public string UserId {get; set;}

    public IdentityUser User{get; set;}

}


