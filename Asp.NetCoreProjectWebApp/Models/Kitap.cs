using System.ComponentModel.DataAnnotations;

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
    
    
}