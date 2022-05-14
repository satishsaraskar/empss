using EmployeeForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace EmployeeForm.Controllers
{
    public class EmpApiController : ApiController
    {
        Db_EmpoyeeEntities empdb = new Db_EmpoyeeEntities();
        [HttpPost]
        public IHttpActionResult AddEmployee(tbl_Employee md)
        {

            Employee_Model er = new Employee_Model();
            try
            {
                
                if (md!=null && md.Age<=18)
                {
                    tbl_Employee em = new tbl_Employee();

                    em.Name = md.Name;
                    em.Age = md.Age;
                    em.Salary = md.Salary;

                    empdb.tbl_Employee.Add(em);
                    empdb.SaveChanges();

                    er.statuscode = 0;
                    er.statusmessage = "success";
                    return Ok(er);


                }
                else
                {

                    er.statuscode = 1;
                    er.statusmessage = "Invalid Parameters";
                    return Ok(er);

                }


            }
            catch (Exception Ex)
            {
              
                er.statuscode = 1;
                er.statusmessage = "Something Went Wrong. Please Try Again!!";
            }
            return Ok(er);
        }
        [HttpGet]
        public IHttpActionResult GetEmployee()
        {

            Employee_Model er = new Employee_Model();
            try
            {
                var empdata = empdb.tbl_Employee.ToList();
                if (empdata != null)
                {
                    foreach(var m in empdata)
                    {
                        tbl_Employee tm = new tbl_Employee();

                        tm.Id = m.Id;
                        tm.Name = m.Name;
                        tm.Age = m.Age;
                        tm.Salary = m.Salary;

                        er.Employees.Add(tm);

                    }
                    er.statuscode = 0;
                    er.statusmessage = "success";
                    return Ok(er);


                }
                else
                {

                    er.statuscode = 1;
                    er.statusmessage = "Invalid Parameters";
                    return Ok(er);

                }


            }
            catch (Exception Ex)
            {

                er.statuscode = 1;
                er.statusmessage = "Something Went Wrong. Please Try Again!!";
            }
            return Ok(er);
        }
        [HttpPost]
        public IHttpActionResult DeleteEmployee(tbl_Employee em)
        {

            Employee_Model er = new Employee_Model();
            try
            {

                if (em.Id != 0 )
                {
                    var de = empdb.tbl_Employee.Where(x => x.Id == em.Id).First();
                    empdb.tbl_Employee.Remove(de);
                    empdb.SaveChanges();

                    er.statuscode = 0;
                    er.statusmessage = "success";
                    return Ok(er);


                }
                else
                {

                    er.statuscode = 1;
                    er.statusmessage = "Invalid Parameters";
                    return Ok(er);

                }


            }
            catch (Exception Ex)
            {

                er.statuscode = 1;
                er.statusmessage = "Something Went Wrong. Please Try Again!!";
            }
            return Ok(er);
        }
        [HttpPost]
        public IHttpActionResult EditEmployee(tbl_Employee em)
        {

            Employee_Model er = new Employee_Model();
            try
            {

                if (em != null && em.Age <= 18)
                {
                    empdb.Entry(em).State = EntityState.Modified;
                    empdb.SaveChanges();

                    er.statuscode = 0;
                    er.statusmessage = "success";
                    return Ok(er);


                }
                else
                {

                    er.statuscode = 1;
                    er.statusmessage = "Invalid Parameters";
                    return Ok(er);

                }


            }
            catch (Exception Ex)
            {

                er.statuscode = 1;
                er.statusmessage = "Something Went Wrong. Please Try Again!!";
            }
            return Ok(er);
        }
    }
}
