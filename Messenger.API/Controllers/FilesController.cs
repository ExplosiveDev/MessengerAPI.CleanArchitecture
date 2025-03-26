using Messenger.Application.Services;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {

        private readonly IFileService _fileService;

        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [Authorize]
        [HttpPost("Upload")]
        public async Task<ActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "Файл не був наданий або порожній" });

            if (file.Length > 50 * 1024 * 1024) // 50MB max
                return BadRequest(new { message = "Розмір файлу перевищує 50MB" });

            var originalFileName = Path.GetFileName(file.FileName);
            var safeFileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";

            var uploadsFolder = Path.Combine("wwwroot", "uploads");
            var fullUploadsPath = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder);

            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(fullUploadsPath, safeFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{safeFileName}";

            var fileEntity = new MyFile
            {
                FileName = originalFileName,
                FilePath = Path.Combine(uploadsFolder, safeFileName),
                FileSize = file.Length,
                ContentType = file.ContentType,
                URL = fileUrl,
                Message = null
            };

            var fileEntityId = await _fileService.Upload(fileEntity);

            if (fileEntityId == Guid.Empty)
                return StatusCode(500, new { message = "Помилка при збереженні файлу в базі даних" });

            return Ok(new 
            {
                Id = fileEntityId,            });

        }
    }
}
