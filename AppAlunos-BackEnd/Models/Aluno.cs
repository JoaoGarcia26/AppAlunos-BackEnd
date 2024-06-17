using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AppAlunos_BackEnd.Models;

public class Aluno
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(80, ErrorMessage = "O nome excedeu os 80 caracteres.")]
    public string Nome { get; set; }
    [Required]
    [EmailAddress]
    [StringLength(100, ErrorMessage = "O email excedeu os 100 caracteres.")]
    public string Email { get; set; }
    [Required]
    public int Idade { get; set; }
}
