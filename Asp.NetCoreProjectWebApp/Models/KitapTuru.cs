using System.ComponentModel.DataAnnotations;

namespace Asp.NetCoreProjectWebApp.Models;

public class KitapTuru
{
    [Key]  //primary key
    public int Id { get; set; }
    [Required] //not null
    public string Ad { get; set; }
    
}