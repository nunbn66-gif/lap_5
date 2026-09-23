using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NsbmLesson9.Models.DataViewModels
{
    public class NsbmMemberRegister
    {
       
        public int NsbmMemberId { get; set; }
        [DisplayName("Ten dang nhap")]
        [Required(ErrorMessage = "ten dang nhap khong duoc de trong")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "ten dang nhap phai tu 3 den 20 ky tu")]
        public string NsbmUserName { get; set; }
        [DisplayName("Mat khau")]
        [Required(ErrorMessage = "mat khau khong duoc de trong")]
        [DataType(DataType.Password)]
        public string NsbmPassword { get; set; }
        public string NsbmEmail { get; set; }
        public string NsbmPhoneNumber { get; set; }
        public string NsbmFullName { get; set; }
        public DateTime NsbmBirthday { get; set; }
    }
}