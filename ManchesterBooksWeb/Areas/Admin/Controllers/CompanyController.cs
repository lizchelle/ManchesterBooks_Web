﻿using ManchesterBooksWeb2.Models;
using ManchesterBooksWeb2.DataAccess;
using Microsoft.AspNetCore.Mvc;
using ManchesterBooksWeb2.DataAccess.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;
using ManchesterBooksWeb2.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManchesterBooksWeb2.Models.View_Models;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using ManchesterBooksWeb2.Utility;
using Microsoft.AspNetCore.Authorization;

namespace ManchesterBooksWeb.Areas.Admin.Controllers;
[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]

public class CompanyController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
   
    public CompanyController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
       
    }
    public IActionResult Index()
    {
        return View();
    }
       //Get
    public IActionResult Upsert(int? id)
    {
        Company company = new();
           

        if (id == null || id == 0)
        {
            return View(company);

        }
        else
        {
            company =_unitOfWork.Company.GetFirstOrDefault(u=>u.Id == id);
            return View(company);
         
        }
        
         
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Upsert(Company obj, IFormFile? file)
    {
        
        if (ModelState.IsValid)
        {
                       
            if (obj.Id == 0)
            {
                _unitOfWork.Company.Add(obj);
                TempData["success"] = "Company created successfully";
            }
            else
            {
                _unitOfWork.Company.Update(obj);
                TempData["success"] = "Company updated successfully";
            }
            _unitOfWork.Save();
           
            return RedirectToAction("Index");

        }
        return View(obj);
    }

   
    
    
    #region API CALLS
    [HttpGet]

    public IActionResult GetAll()
    {
        var companyList = _unitOfWork.Company.GetAll();
        return Json(new { data = companyList });
    }

    [HttpDelete]

    public IActionResult Delete(int? id)
    {
        var obj = _unitOfWork.Company.GetFirstOrDefault(u =>u.Id == id);
        if (obj == null)
        {
            return Json(new { success = false, message = "Error while deleting" });
        }

        _unitOfWork.Company.Remove(obj);
        _unitOfWork.Save();
        return Json(new { success = true, message = "Delete Successful" });
    }
    #endregion

}