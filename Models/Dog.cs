using System.ComponentModel.DataAnnotations;

namespace midterm_project.Models;

public class Dog {
    public int DogId { get; set; }

    [Required]
    [Display(Name = "Name")]
    public string? Name { get; set; }

    [Required]
    [Display(Name = "Breed")]
    public string? Breed { get; set; }

    [Required]
    [Display(Name = "Gendre")]
    public string? Gendre { get; set; }

    [Required]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required]
    [Display(Name = "ImgUrl")]
    public string? ImgUrl { get; set; }
}