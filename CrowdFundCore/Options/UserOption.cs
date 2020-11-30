using System.Collections.Generic;
using CrowdFundCore.Models;

namespace CrowdFundCore.Options
{
    public class UserOption
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public decimal Gross { get; set; }
        public List<Project> Project { get; set; }
    }
}
