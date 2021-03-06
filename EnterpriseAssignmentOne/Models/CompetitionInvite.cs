﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EnterpriseAssignmentOne.Models
{

    public enum TechnicalInterest
    {
        IoT,
        Cognitive,
        Wearable,
        AR_VR
    }



    public class CompetitionInvite
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your email address")]
        [RegularExpression(".+\\@.+\\..+",
        ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public string Phone { get; set; }

        public bool? WillAttend { get; set; }




        public String Address { get; set; }

        public String TwitterAccount { get; set; }

        [Required(ErrorMessage = "Please specify what you are interested in")]
        public TechnicalInterest Interest { get; set; }



    }
}