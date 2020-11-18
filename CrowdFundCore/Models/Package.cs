using System;
using System.Collections.Generic;
using System.Text;
using ProjectCF.Models;

namespace ProjectCF_Console.Models
{
    public class Package
    {
        public int Id { get; set; }
        public decimal Ammount { get; set; }
        public string Description { get; set; }
        public string Reward { get; set; }
        public bool IsActive { get; set; }
        public Project Project { get; set; }
       // public User User { get; set; } Do we need it?
    }
}
