using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Dto;

namespace WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET api/<controller>
        public List<EmployeeDto> Get()
        {
            MusicStoreDbContext db = new MusicStoreDbContext();
            List<EmployeeDto> employee_dto = db.Employees.Select(x => new EmployeeDto()
            {
                EmployeeId = x.EmployeeId,
                FullName = x.LastName + x.FirstName,
                Title = x.Title,
                City = x.City,
                //MonthsWorked = (DateTime.Now.Month + DateTime.Now.Year * 12) - (x.HireDate.HasValue == true ? x.HireDate.Value.Year : -1  + (x.HireDate.HasValue == true ? x.HireDate.Value.Month : -1) * 12),
                TotalTracksSold = db.InvoiceLines.Where(i => i.Invoice.Customer.EmployeeId == x.EmployeeId).Sum(i => i.Quantity),
                TotalPrice = db.InvoiceLines.Where(i => i.Invoice.Customer.EmployeeId == x.EmployeeId).Sum(i => i.Quantity * i.UnitPrice)
            }).OrderByDescending(c => c.TotalTracksSold).ToList();


            return employee_dto;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}