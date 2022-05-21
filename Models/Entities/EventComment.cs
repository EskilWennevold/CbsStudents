using cbsStudents.Models.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

public class EventComment

{
    public int EventCommentId { get; set; }
    [MinLength(1)]
    public string Text { get; set; }

    public int EventId { get; set; }
    public Event Event { get; set; }

    public string UserId {get; set;}

    public IdentityUser User {get; set;}
}