using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolApi.Models
{
    public class StudentsCourses
    {
        //public Students StudentId { get; set; }
        //public Courses CourseID { get; set; }

        [Key]
        [Column(Order = 1)]
        public int StudentId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CourseID { get; set; }

       // [ForeignKey("StudentId")]
       //public Students Student { get; set; }

       // [ForeignKey("CourseID")]
       // public Courses Course { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime EnrollDate { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string Status { get; set; }

    }
}
