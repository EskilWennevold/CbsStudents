using cbsStudents.Models.Entities;
using Microsoft.AspNetCore.Identity;

public class Comment

{
    public int CommentId { get; set; }

    public string Url { get; set; }

    public int PostId { get; set; }
    public Post Post { get; set; }

    public string UserId {get; set;}

    public IdentityUser User {get; set;}
}