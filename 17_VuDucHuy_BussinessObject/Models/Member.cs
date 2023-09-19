﻿using System;
using System.Collections.Generic;

namespace _17_VuDucHuy_BussinessObject.Models
{
    public partial class Member
    {
        public Member()
        {
            Orders = new HashSet<Order>();
        }

        public int MemberId { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public Member(string email, string companyName, string city, string country, string password)
        {
            Email = email;
            CompanyName = companyName;
            City = city;
            Country = country;
            Password = password;
        }
    }
}