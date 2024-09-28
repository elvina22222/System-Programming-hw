using hw2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw2
{
    public partial class Department
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
