using cbsStudents.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;


public class Comment

{
    public int CommentId { get; set; }
    [MinLength(1)]
    public string Url { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public string UserId {get; set;}

    public IdentityUser User {get; set;}
}