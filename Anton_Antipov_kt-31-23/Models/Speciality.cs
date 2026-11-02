
using System.Collections.Generic;

namespace Anton_Antipov_kt_31_23.Models
{
    public class Speciality
    {
        public int SpecialityId { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Code { get; set; } = string.Empty;

        public ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
