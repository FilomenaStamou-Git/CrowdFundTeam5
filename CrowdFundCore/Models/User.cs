using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrowdFundCore.Models
{
    public class User
    {
        //TEST PULL 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }   
        public List<Project> Projects { get; set; } //hi mom
        public List<Funding> Fundings { get; set; }      
    }
}
