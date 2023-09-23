using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCoreProjectWebApp.Models;

public class Kitap
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string KitapAdi { get; set; }
    [Required]
    public string Tanim { get; set; }
    [Required]
    public string Yazar { get; set; }
    [Required]
    [Range(10,5000)]
    public Double Fiyat { get; set; }

    [ValidateNever]
    public int KitapTuruId { get; set; }
    
    [ForeignKey("KitapTuruId")]
    [ValidateNever]
    public KitapTuru KitapTuru { get; set; }

    [ValidateNever]
    public string ResimUrl { get; set; }
}