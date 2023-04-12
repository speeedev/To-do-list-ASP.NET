using _1.Models.Entities;

using System.ComponentModel.DataAnnotations;

namespace _1.Models;

public class TodoViewModel
{
    [Required(ErrorMessage = "It cannot be left blank.")]
    public string? Title { get; set; }
    public IEnumerable<Todo>? Todos { get; set; }
}
