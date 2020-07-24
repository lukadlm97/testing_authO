using auth_test.demo.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace auth_test.ViewModels
{
    public class TableModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int UsualCapacity { get; set; }
        [Required]
        public int MinCapacity { get; set; }
        public int MaxCapacity { get; set; }
        public bool IsSeparate { get; set; }
        public bool HaveMinimumSpend { get; set; }
        public double MinimumSpend { get; set; }
        public double CostOfReservaton { get; set; }
        public static implicit operator TablePlace(TableModel model)
        {
            return new TablePlace 
            {
                Id = 0,
                CostOfReservaton = model.CostOfReservaton,
                HaveMinimumSpend = model.HaveMinimumSpend,
                IsSeparate = model.IsSeparate,
                MaxCapacity = model.MaxCapacity,
                MinCapacity = model.MinCapacity,
                MinimumSpend = model.MinimumSpend,
                Name = model.Name,
                UsualCapacity = model.UsualCapacity
            };
        }
    }
}
