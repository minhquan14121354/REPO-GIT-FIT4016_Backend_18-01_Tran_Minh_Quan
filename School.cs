using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class School
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Principal { get; set; }
    [Required]
    public string Address { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public virtual ICollection<Student> Students { get; set; }
}