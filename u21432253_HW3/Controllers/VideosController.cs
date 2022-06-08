using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21432253_HW3.Models;

namespace u21432253_HW3.Controllers
{
    public class VideosController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            // Get all the files from folde store them in a aray
            string[] files = Directory.GetFiles(Server.MapPath("~/Media/Videos/"));
            // create a array of file model
            List<FileModel> PicsList = new List<FileModel>();
            foreach (string file in files)
            {
                // Create new file model for every file in file array
                FileModel fileModel = new FileModel();
                fileModel.FileName = Path.GetFileName(file);
                // Add the file in the file models list
                PicsList.Add(fileModel);
            }

            return View(PicsList);
        }
        public FileResult Download(string name)
        {
            // Get the path
            string path = Server.MapPath("~/Media/Videos/") + name;
            // Convert to byte
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            // Download
            return File(bytes, "application/octet-stream", name);
        }

        public ActionResult Delete(string name)
        {

            // the path of the file
            string fullPath = Request.MapPath("~/Media/Videos/" + name);
            // delete the file from that path
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            return RedirectToAction("Index");
        }
    }
}