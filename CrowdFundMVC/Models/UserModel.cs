using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrowdFundCore.Options;

namespace CrowdFundMVC.Models
{
    public class UserModel
    {
        public List<UserOption> Users { get; set; }
    }


    public class UserOptionModel
    {
        public UserOption user { get; set; }
    }
}