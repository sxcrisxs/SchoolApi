﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Models
{
    public class Courses
    {
        [Key]
        public int CourseID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CourseName { get; set; }

      
    }
}
