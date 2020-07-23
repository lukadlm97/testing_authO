using System;
using System.Collections.Generic;
using System.Text;

namespace auth_test.demo.Domain.Models
{
    public class TablePlace:DomainObject
    {
        public string Name { get; set; }
        public int UsualCapacity { get; set; }
        public int MinCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsSeparate { get; set; }
        public bool HaveMinimumSpend { get; set; }
        public double MinimumSpend { get; set; }
        public double CostOfReservaton { get; set; }
    }
}
