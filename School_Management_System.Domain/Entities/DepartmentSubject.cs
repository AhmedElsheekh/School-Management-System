using School_Management_System.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Domain.Entities
{
    public class DepartmentSubject : BaseEntity<int>
    {
        public int DepartmentId { get; set; }
        public int SubjectId { get; set; }

        //Navigation properties
        public virtual Subject Subject { get; set; }
        public virtual Department Department { get; set; }
    }
}
