using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Controllers
{
    public class ApplicationController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public ApplicationController(IHostingEnvironment hostingEnvironment)
        {
            _environment = hostingEnvironment;
        }
        public IActionResult Index()
        {

            return View("Register",new GymModels.Applicant() { Name = "abc" });
        }

        [HttpPost]
        public IActionResult Register(GymModels.Applicant applicant)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Capture(string name)
        {
            var files = HttpContext.Request.Form.Files;
            string _path = string.Empty;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting Filename  
                        var fileName = file.FileName;
                        // Unique filename "Guid"  
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        // Getting Extension  
                        var fileExtension = Path.GetExtension(fileName);
                        // Concating filename + fileExtension (unique filename)  
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        //  Generating Path to store photo   
                        var filepath = Path.Combine(_environment.WebRootPath, "uploadedimages") + $@"\{newFileName}";

                        if (!string.IsNullOrEmpty(filepath))
                        {
                            // Storing Image in Folder  
                            if( StoreInFolder(file, filepath))
                            {
                                _path = filepath;
                            }
                        }

                    }
                }
                return Json(_path);
            }
            else
            {
                return Json("");
            }
        }

        private bool StoreInFolder(IFormFile file, string fileName)
        {
            try
            {
                using (FileStream fs = System.IO.File.Create(fileName))
                {
                    file.CopyTo(fs);
                    fs.Flush();
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
