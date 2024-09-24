using ITI_Project.Models.Context;
using ITI_Project.Models.Entities;
using ITI_Project.Models.EntitiesBL;
using Microsoft.AspNetCore.Mvc;
using ITI_Project.Models.ViewModel;
using System.Net.NetworkInformation;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;

namespace ITI_Project.Controllers
{
    public class InstructorController : Controller,IDisposable
    {
        InstructorBL inst = new InstructorBL();
        public IActionResult Index()
        {

          var Instructrs= inst.GetAll();
            return View(Instructrs);
        }
        public IActionResult SearchByName(string name)
        {
            return View("Index", inst.GetInstructorsByAddress(name));
        }
        public IActionResult Details(int id)
        {
            var Instructr = inst.GetByID(id);
            return View(Instructr);
        }
        public IActionResult Add()
        { 
            return View(inst.instviewModel());
        }
        [HttpPost]
        public IActionResult Add(Inst_Dep_CrsViewModel i)
        {
            Instructor instructor = new Instructor();
            if (!i.Name.IsNullOrEmpty())
            {
                instructor.Name=i.Name;
                instructor.Salary=i.Salary;
                instructor.Address=i.Address;
                instructor.Image=i.Image;
                instructor.dept_id=i.dept_id;
                instructor.Crs_id=i.Crs_id;

                inst.Add(instructor);
                return RedirectToAction("Index");
            }
            i.Dep = inst.DepartList();
            i.crs=inst.CrsList();
            return View(i);
        }
        public IActionResult Edit(int id) {
           Inst_Dep_CrsViewModel Vinst =inst.instviewModel();
            
           var instructor= inst.GetByID(id);
            if(instructor is not null)
            {
                Vinst.Id = instructor.Id;
                Vinst.Name=instructor.Name;
                Vinst.Salary=instructor.Salary;
                Vinst.Address=instructor.Address;
                Vinst.Image=instructor.Image;
                Vinst.Crs_id= instructor.Crs_id;
                Vinst.dept_id=instructor.dept_id;
                return View(Vinst);
            }
           return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(int? id, Inst_Dep_CrsViewModel i)
        {

            Instructor instructor = new Instructor();
            if (i.Name is not null)
            {
                instructor.Id=i.Id;
                instructor.Name = i.Name;
                instructor.Salary = i.Salary;
                instructor.Address = i.Address;
                instructor.Image = i.Image;
                instructor.Crs_id = i.Crs_id;
                instructor.dept_id = i.dept_id;

                inst.Update(instructor);
                return RedirectToAction("Index");
            }
            i.Dep = inst.DepartList();
            i.crs = inst.CrsList();

            return View(i);
        }
    }
}
