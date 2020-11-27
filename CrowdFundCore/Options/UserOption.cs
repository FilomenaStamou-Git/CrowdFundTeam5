﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //public List<FundingProject> FundingProjects { get; set; }
       // public List<Project> Project { get; set; }

    }
}
