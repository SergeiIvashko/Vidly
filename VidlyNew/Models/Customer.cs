﻿using System.ComponentModel.DataAnnotations;

namespace Vidli.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Date of Birth")]

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
        public MembershipType? MembershipType { get; set; }
    }
}
