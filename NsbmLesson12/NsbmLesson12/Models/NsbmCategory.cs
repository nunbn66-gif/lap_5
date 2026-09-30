using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NsbmLesson12.Models
{
    [Table("Category")]
    public class NsbmCategory
    {
        [Key]
        public int NsbmId { get; set; }

        [Required(ErrorMessage = "Ten danh muc khong duoc de trong")]
        [StringLength(100)]
        [Column(TypeName = "nvarchar(100)")]
        public string Nsbmname { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NsbmCreatedDate { get; set; }

        public ICollection<NsbmProduct> NsbmProducts { get; set; }
    }
}