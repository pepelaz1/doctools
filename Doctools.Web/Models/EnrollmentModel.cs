﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doctools.Web.Models
{
    public class EnrollmentModel
    {
        public DateTime EnrollmentDate { get; set; }
        public CourseModel Course { get; set; }
    }
}