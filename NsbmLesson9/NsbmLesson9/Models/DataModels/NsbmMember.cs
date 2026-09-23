using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NsbmLesson9.Models.DataModels
{
    public class NsbmMember
    {
        public int NsbmMemberId { get; set; }
        
        public string NsbmUserName { get; set; }
      
        public string NsbmPassword { get; set; }
        public string NsbmEmail { get; set; }
        public string NsbmPhoneNumber { get; set; }
        public string NsbmFullName { get; set; }
        public DateTime NsbmBirthday { get; set; }
    }
}
