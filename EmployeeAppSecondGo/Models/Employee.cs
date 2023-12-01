using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeAppSecondGo.Interfaces;

namespace EmployeeAppSecondGo.Models
{
    internal class Employee : IEmployee
    {
        public Employee(Guid id, string name, string position)
        {
            Id = id;
            Name = name;
            Position = position;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
    }
}
