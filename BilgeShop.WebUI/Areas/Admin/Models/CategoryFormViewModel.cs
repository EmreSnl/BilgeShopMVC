using System.ComponentModel.DataAnnotations;

namespace BilgeShop.WebUI.Areas.Admin.Models
{
    public class CategoryFormViewModel
    {
        public int Id { get; set; } // Bu model ile aynı formdan hem ekleme hem güncelleme yapılacağı için, Id bilgisi de taşınmalı.
        [Display(Name = "Kategori Adı")]
        [Required(ErrorMessage = "Kategori Adı alanını doldurmak zorunludur.")]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [MaxLength(1000)]
        public string? Description { get; set; }
        // ? -> nullable - boş gönderilebilir.
    }
}
