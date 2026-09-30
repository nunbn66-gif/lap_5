using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsbmLesson12.Models
{
    [Table("Product")]
    public class NsbmProduct
    {
        [Key]
        public int NsbmId { get; set; }

        [Required(ErrorMessage = "Ten san pham khong dc de trong")]
        [StringLength(150, ErrorMessage = "Ten sp gioi han 150 ki tu")]
        [Column(TypeName = "nvarchar(150)")]
        public string NsbmName { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string NsbmImage { get; set; }

        [Required(ErrorMessage = "Gia sp ko dc de trong")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal NsbmPrice { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal NsbmsalePrice { get; set; }

        [Column(TypeName = "tinyint")]
        public byte NsbmStatus { get; set; }

        [StringLength(1000, ErrorMessage = "Noi dung mo ta gioi han 1000 ky tu")]
        [Column(TypeName = "nvarchar(1000)")]
        public string Descriptions { get; set; }

        [Required(ErrorMessage = "Danh muc sp ko dc de trong")]
        public int NsbmCategoryId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NsbmCreatedDate { get; set; }

        public NsbmCategory NsbmCategory { get; set; }
    }
}