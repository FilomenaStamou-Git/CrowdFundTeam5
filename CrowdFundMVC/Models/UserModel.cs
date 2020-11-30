using System.Collections.Generic;
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