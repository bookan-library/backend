﻿using BookanLibrary.Core.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookanLibrary.Core.Model
{
    public class Buyer : User
    {
        public Buyer(string firstName, string lastName, string email, string password,
            string phoneNumber, Role role, Address address) : base(firstName, lastName, email, password, phoneNumber, role, address) { }

        public Buyer() { }
    
    }


}
