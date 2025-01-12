using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Domain.Abstractions
{
    public class BaseEntity<T> where T : struct
    {
        public T Id { get; set; }
    }
}
