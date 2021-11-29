using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace WebApi.Dto
{
    public class EmployeeDto
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public int MonthsWorked { get; set; }
        public int TotalTracksSold { get; set; }
        public decimal TotalPrice { get; set; }
    }
}