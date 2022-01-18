﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Data;
using WebApplication3.Models;

namespace WebApplication3.Areas.admin.Controllers
{
    [Area("admin")]
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public BlogController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
           _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View(_context.Blogs.Include(u=>u.User).ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Blog model)
        {
            if (ModelState.IsValid)
            {
                if(model.ImageFile.ContentType== "image/jpeg"|| model.ImageFile.ContentType== "image/png")
                {
                    if(model.ImageFile.Length<= 3145728)
                    {

                        string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            model.ImageFile.CopyTo(stream);
                        }

                        model.Image = fileName;
                        model.UserId = 1;
                        _context.Blogs.Add(model);
                        _context.SaveChanges();
                        return RedirectToAction("Index");

                    }
                    else
                    {
                        ModelState.AddModelError("", "hecm boyukdur!");
                        return View(model);
                    }

                   
                   
                }
                else
                {
                    ModelState.AddModelError("", "Format uygun deyil!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }



        public IActionResult Update(int? id)
        {
            return View(_context.Blogs.Find(id));
        }

        [HttpPost]
        public IActionResult Update(Blog model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null)
                {
                    if (model.ImageFile.ContentType == "image/jpeg" || model.ImageFile.ContentType == "image/png")
                    {
                        if (model.ImageFile.Length <= 3145728)
                        {

                            string oldImage = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", model.Image);
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }

                            string fileName = Guid.NewGuid() + "-" + model.ImageFile.FileName;
                            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", fileName);


                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                model.ImageFile.CopyTo(stream);
                            }

                            model.Image = fileName;
                            _context.Blogs.Update(model);
                            _context.SaveChanges();
                            return RedirectToAction("Index");

                        }
                        else
                        {
                            ModelState.AddModelError("", "hecm boyukdur!");
                            return View(model);
                        }



                    }
                    else
                    {
                        ModelState.AddModelError("", "Format uygun deyil!");
                        return View(model);
                    }
                }

                else
                {
                    _context.Blogs.Update(model);
                    _context.SaveChanges();
                    return RedirectToAction("index");
                }
            }
            else
            {
                return View(model);
            }
        }




        public IActionResult Delete(int? id)
        {
            if (id==null)
            {
                return NotFound();
            }

            Blog blog = _context.Blogs.Find(id);
            if (blog == null)
            {
                return NotFound();
            }

            string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads", blog.Image);
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            _context.Blogs.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

    }
}
