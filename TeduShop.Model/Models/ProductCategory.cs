using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeduShop.Model.Abstract;
namespace TeduShop.Model.Models
{
    [Table("ProductCategories")]
    
   public  class ProductCategory: Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }
        [Required]
        [MaxLength(256)]
        public string Name { set; get; }
        [Required]
        [MaxLength(256)]
        public string Alias { set; get; }
        [Required]
        [MaxLength(500)]
        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisPlayOder { set; get; }
        [MaxLength(256)]
        public string Image { set; get; }
       
        public bool? HomeFlags { set; get; }
        public virtual IEnumerable<Product> Products { set; get; }
    }
}
