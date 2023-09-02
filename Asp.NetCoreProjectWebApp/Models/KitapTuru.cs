﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Asp.NetCoreProjectWebApp.Models;

public class KitapTuru
{
    [Key]  //primary key
    public int Id { get; set; }
    
    [Required] //not null
    [MaxLength(25)]
    [DisplayName("Kitap Türü Adı")]
    public string Ad { get; set; }
    
}