using School_Management_System.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Domain.Entities
{
    public class Student : BaseEntity<int>
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
 
        [StringLength(200)]
        public required string Name { get; set; }
        [StringLength(500)]
        public required string Address { get; set; }
        [StringLength(500)]
        [DataType(DataType.PhoneNumber)]
        public required string Phone { get; set; }
        public int DepartmentId { get; set; }


        //Navigation properties
        public virtual Department Department { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
 
    }
}
