using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteFPT.Models
{
    public class ViewModels
    {
        public Enrollment enrollment { get; set; }
        public IEnumerable<Enrollment> enrollments { get; set; }
        public Course course { get; set; }
        public IEnumerable<Course> courses { get; set; }
    }
}
