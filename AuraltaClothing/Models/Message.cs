﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Models
{
    public class Message
    {

        public int MessageId { get; set; }

        public string FirstName  { get; set; }

        public string LastName{ get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string Description { get; set; }

    }
}