using EmployeeForm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeForm.Controllers
{
    public class EmployeeController : Controller
    {
        Db_EmpoyeeEntities empdb = new Db_EmpoyeeEntities();
        // GET: Employee
        public ActionResult Employee()
        {

            var empdata = empdb.tbl_Employee.ToList();
            ViewBag.EmployeeData = empdata;

            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(tbl_Employee md)
        {
            if(ModelState.IsValid)
            {
                tbl_Employee em = new tbl_Employee();

                em.Name = md.Name;
                em.Age = md.Age;
                em.Salary = md.Salary;

                 empdb.tbl_Employee.Add(em);
                 empdb.SaveChanges();

            }

            ModelState.Clear();
           
            var empdata = empdb.tbl_Employee.ToList();
            ViewBag.EmployeeData = empdata;

            return View("Employee");
        }
        public ActionResult EditEmployee(int id)
        {
            var em = empdb.tbl_Employee.Where(x => x.Id == id).First();

            tbl_Employee m = new tbl_Employee();
            m.Id = em.Id;
            m.Name = em.Name;
            m.Age = em.Age;
            m.Salary = em.Salary;

            return View(m);
        }
        [HttpPost]
        public ActionResult EditEmployee(tbl_Employee te)
        {
           
            empdb.Entry(te).State = EntityState.Modified;
            empdb.SaveChanges();

            ModelState.Clear();

            var empdata = empdb.tbl_Employee.ToList();
            ViewBag.EmployeeData = empdata;

            return View("Employee");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var de = empdb.tbl_Employee.Where(x => x.Id == id).First();
            empdb.tbl_Employee.Remove(de);
            empdb.SaveChanges();

            var empdata = empdb.tbl_Employee.ToList();
            ViewBag.EmployeeData = empdata;

            return View("Employee");
        }
    }
}