using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HairDemoSite.Areas.Public.Data.SiteData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HairDemoSite.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MPCarouselController : ControllerBase
    {
        private siteDataDbContext context;
        private IWebHostEnvironment hostingEnv;

        public MPCarouselController(siteDataDbContext context, IWebHostEnvironment hostingEnv)
        {
            this.context = context;
            this.hostingEnv = hostingEnv;
        }

        [HttpPost]
        [ActionName("CreateNewTile")]
        public void CreateNewTile(NewTileDTO dto)
        {
            try
            {
                int imageID = context.PublicImages
                                        .Where(w => w.ImageLocation == dto.ImageLocation)
                                        .Select(s2 => s2.ImageId).FirstOrDefault();

                MpCarousel newCarouselTile = new MpCarousel { ImageId = imageID, TileMessage = dto.TileMessage, TileTitle = dto.TileTitle };

                context.MpCarousel.Add(newCarouselTile);
                context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [ActionName("DeleteTile")]
        public void DeleteTile(RequestData data)
        {
            try
            {
                bool gotIntValue = int.TryParse(data.idString, out int id);

                if (gotIntValue && id > 0)
                {
                    var entrytoDelete = context.MpCarousel.Select(s => s).Where(w => w.TileId == id).FirstOrDefault();

                    if (entrytoDelete != null)
                    {
                        context.MpCarousel.Remove(entrytoDelete);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost]
        [ActionName("FileUpload")]
        public async Task<IActionResult> FileUpload()
        {
            try
            {
                var fileData = Request.Form.Files;

                foreach (IFormFile file in fileData)
                {
                    var fileExtension = file.Name.Split(@".").LastOrDefault().ToLower();

                    if (fileExtension != "bmp" && fileExtension != "gif" && fileExtension != "jpeg" && fileExtension != "jpg" && fileExtension != "tiff" && fileExtension != "png")
                    {
                        return BadRequest("File format, " + fileExtension + " is not acceptable, use .bmp, .gif, .jpeg, .jpg, .tiff, .png");
                    }

                    string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = this.EnsureCorrectFilename(filename);

                    //string filename = DateTime.Now.ToString("dd_MM_yyyy HH-mm-ss") + "." + fileExtension;

                    var filePath = this.GetPathAndFilename(filename);

                    Image img;
                    using (var reader = new StreamReader(file.OpenReadStream()))
                    {
                        using (var memstream = new MemoryStream())
                        {
                            reader.BaseStream.CopyTo(memstream);
                            img = Image.FromStream(memstream, true);
                        }
                    }

                    var width = img.Width;
                    var height = img.Height;

                    if ((width * height) > 1000000)
                    {
                        int newHeight = 0;
                        int newWidth = 0;

                        if (height > 1000)
                        {
                            newWidth = 1000;
                            newHeight = (int)(((double)height / (double)width) * 1000);

                        }
                        else if (width > 1000)
                        {
                            newHeight = 1000;
                            newWidth = (int)(((double)width / (double)height) * 1000);
                        }

                        var newFile = new Bitmap(img, new Size(newWidth, newHeight));
                        newFile.Save(filePath, ImageFormat.Jpeg);

                        height = newHeight;
                        width = newWidth;
                    }
                    else
                    {
                        using (FileStream output = System.IO.File.Create(filePath))
                        {
                            await file.CopyToAsync(output);
                        }

                        img = Image.FromFile(filePath);

                        width = img.Width;
                        height = img.Height;

                    }

                    var dataToSave = new PublicImages
                    {
                        ImageName = filename,
                        ImageHeight = height,
                        ImageWidth = width,
                        ImageLocation = filePath.Replace(this.hostingEnv.WebRootPath + @"\", string.Empty).Replace(@"\", @"/")
                    };

                    context.PublicImages.Add(dataToSave);
                    context.SaveChanges();
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            if (filename.Length > 50)
            {
                var fileExtension = "." + filename.Split(@".").LastOrDefault().ToLower();
                var shortFilename = filename.Replace(fileExtension, string.Empty).Substring(0, 50 - fileExtension.Length);
                var newFilename = shortFilename + fileExtension;

                return newFilename;
            }

            return filename;
        }

        private string GetPathAndFilename(string filename)
        {
            var imageLocation = this.hostingEnv.WebRootPath + @"\public\img\saved\" + filename;

            return imageLocation;
        }
    }

    public class NewTileDTO
    {
        public string ImageLocation { get; set; }
        public string TileTitle { get; set; }
        public string TileMessage { get; set; }
    }

    public class RequestData
    {
        public string idString { get; set; }
    }
}
