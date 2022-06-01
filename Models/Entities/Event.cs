using cbsStudents.Models.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cbsStudents.Models.Entities;
public class Event
{
    public int EventId { get; set; }

    [Required]
    [Display(Name = "Event Name")]
    [MinLength(3)]
    public string EventName { get; set; }

    [Required]
    [Display(Name ="Description")]
    [MinLength(10)]
    public string Text { get; set; }

    [Required]
    public string Location { get; set; }

    public List<EventComment> Comments { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public PostStatus Status { get; set; }
    
    public string UserId {get; set;}

    public IdentityUser User{get; set;}

}