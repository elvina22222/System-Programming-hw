using hw2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    public partial class Group
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public int IdFaculty { get; set; }

        public virtual Faculty IdFacultyNavigation { get; set; } = null!;

        public virtual ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
