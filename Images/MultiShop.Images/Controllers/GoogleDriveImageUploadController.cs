using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Images.DAL;
using MultiShop.Images.Services;

namespace MultiShop.Images.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class GoogleDriveImageUploadController : ControllerBase
    {
        private readonly ICloudStorageService _cloudStorageService;

        public GoogleDriveImageUploadController(ICloudStorageService cloudStorageService)
        {
            _cloudStorageService = cloudStorageService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return Ok();
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Create([FromForm] ImageDrive imageDrive)
        {
            if (imageDrive.Photo == null)
                return BadRequest("Photo zorunlu");

            imageDrive.SavedFileName =
                GenerateFileNameToSave(imageDrive.Photo.FileName);

            imageDrive.SavedUrl =
                await _cloudStorageService.UploadFileAsync(
                    imageDrive.Photo,
                    imageDrive.SavedFileName
                );

            return Ok(new
            {
                imageDrive.Name,
                imageDrive.SavedFileName,
                imageDrive.SavedUrl
            });
        }

        private string? GenerateFileNameToSave(string incomingFileName)
        {
            var fileName = Path.GetFileNameWithoutExtension(incomingFileName);
            var extension = Path.GetExtension(incomingFileName);
            return $"{fileName}-{DateTime.Now.ToUniversalTime().ToString("yyyyMMddHHmmss")}{extension}";
        }        
    }
}
