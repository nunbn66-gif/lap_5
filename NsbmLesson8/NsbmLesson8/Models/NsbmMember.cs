using System.ComponentModel;

namespace NsbmLesson8.Models
{
    public class NsbmMember
    {
        public string NsbmMemberId { get; set; }
        public string NsbmUserName { get; set; }
        public string NsbmPassword { get; set; }
        [DisplayName("Ho va ten")]
        public string NsbmFullName { get; set; }
        public string NsbmEmail { get; set; }
    }
}
