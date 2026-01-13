using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Student
{
    [Key]
    public int Id { get; set; }
    public int SchoolId { get; set; }
    [ForeignKey("SchoolId")]
    public virtual School School { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required]
    public string StudentId { get; set; }
    [Required]
    public string Email { get; set; }
    public string? Phone { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}