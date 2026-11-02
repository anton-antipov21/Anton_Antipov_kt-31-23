
using System.Collections.Generic;

namespace Anton_Antipov_kt_31_23.Models
{
    public class Discipline
    {
        public int DisciplineId { get; set; }

        public string Name { get; set; } = string.Empty;

        public bool IsDeleted { get; set; } = false;

        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}
