using cbsStudents.Models.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace cbsStudents.Models.Entities;
public class Event
{
    public int EventId { get; set; }

    [Display(Name = "Event Name")]
    public string EventName { get; set; }

    [Display(Name ="Description")]
    public string Text { get; set; }

    public string Location { get; set; }

    public DateTime Date { get; set; }

    public PostStatus Status { get; set; }

}