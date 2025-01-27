using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SantasBag.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : ControllerBase
    {
        private readonly string _imagesPath;
        public ImagesController()
        {
            //путь к папке с изображениями
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        }

        [HttpGet("{imageName}")]
        [EnableCors("AllowAllFront")]
        public async Task<ActionResult> GetImage(string imageName)
        {
            var filePath = Path.Combine(_imagesPath, imageName+".png");

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "image/png");
        }
        [HttpGet()]
        [EnableCors("AllowAllFront")]
        public List<string> GetAllImages()
        {
            var imageNameArr = (Directory.GetFiles(_imagesPath)).Select(fn=> System.IO.Path.GetFileNameWithoutExtension(fn)).ToList();
            return imageNameArr;

        }

    }
}
