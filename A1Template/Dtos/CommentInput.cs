using System.ComponentModel.DataAnnotations;

namespace A1.Models;

public class CommentInput
{
    [Required]
    public string UserComment { get; set; }

    [Required]
    public string Name { get; set; }
}