using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp.NetCoreProjectWebApp.Models
{
    public class Kiralama
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ogrenciId { get; set; }

        [ValidateNever]
        public int KitapId { get; set; }
        [ForeignKey("KitapId")]

        [ValidateNever]
        public Kitap Kitap { get; set; }




    }
}
