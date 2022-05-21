using cbsStudents.Models.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cbsStudents.Models.Entities;
public class Event
{
    public int EventId { get; set; }

    [Display(Name = "Event Name")]
    [MinLength(3)]
    public string EventName { get; set; }

    [Display(Name ="Description")]
    [MinLength(10)]
    public string Text { get; set; }

    public string Location { get; set; }

    public List<EventComment> Comments { get; set; }

    public DateTime Date { get; set; }

    public PostStatus Status { get; set; }
    
    public string UserId {get; set;}

    public IdentityUser User{get; set;}

}