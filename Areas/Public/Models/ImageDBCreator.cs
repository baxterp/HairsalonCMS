using HairDemoSite.Areas.Public.Data.SiteData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Drawing;

namespace HairDemoSite.Areas.Public.Models
{
    public class ImageDBCreator
    {
        private siteDataDbContext context;
        private IWebHostEnvironment hev;

        public ImageDBCreator(siteDataDbContext context, IWebHostEnvironment hev)
        {
            this.context = context;
            this.hev = hev;
        }

        public bool CreateUpdateImagesData()
        {
            var webRoot = hev.WebRootPath;
            var imageLocation = webRoot + @"\public\img\";

            string[] fullyQualifiedFilesnames = Directory.GetFileSystemEntries(imageLocation, "*", SearchOption.AllDirectories);
            List<PublicImages> fileData = new List<PublicImages>();

            fullyQualifiedFilesnames.ToList().GetRange(2, fullyQualifiedFilesnames.Count() - 2).ForEach(file =>
            {
                Image img = Image.FromFile(file);

                var width = img.Width;
                var height = img.Height;
                var name = file.Split(@"\").Last();

                var serverPath = file.Replace(webRoot, "");


                var dataToSave = new PublicImages
                {
                    ImageName = name,
                    ImageHeight = height,
                    ImageWidth = width,
                    ImageLocation = serverPath.Replace(@"\", @"/")
                };

                fileData.Add(dataToSave);
            });


            foreach (var image in fileData)
            {
                if (!context.PublicImages.Select(s => s.ImageName).Contains(image.ImageName) 
                    && !context.PublicImages.Select(s => s.ImageLocation).Contains(image.ImageLocation))
                {
                    context.PublicImages.Add(image);
                }
            }

            context.SaveChanges();

            return true;
        }
    }
}
