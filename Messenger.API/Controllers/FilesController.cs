using Messenger.Application.Services;
using Messenger.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class FilesController : ControllerBase
    {
        public record FileProps(
            string FileName,
            string FilePath,
            string URL
        );

        private readonly IFileService _fileService;
        private readonly IUserService _userService;

        public FilesController(IFileService fileService, IUserService userService)
        {
            _fileService = fileService;
            _userService = userService;
        }

        private async Task<FileProps> GetFileProperties(IFormFile file)
        {
            var uploadsFolder = Path.Combine("wwwroot", "uploads");
            var fullUploadsPath = Path.Combine(Directory.GetCurrentDirectory(), uploadsFolder);

            var originalFileName = Path.GetFileName(file.FileName);
            var safeFileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";

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

            return new FileProps(originalFileName, Path.Combine(uploadsFolder, safeFileName),  fileUrl );
        }

        [Authorize]
        [HttpPost("Upload")]
        public async Task<ActionResult> Upload([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "Файл не був наданий або порожній" });

            if (file.Length > 50 * 1024 * 1024) // 50MB max
                return BadRequest(new { message = "Розмір файлу перевищує 50MB" });

            var fileProps = await GetFileProperties(file);

            var fileEntity = new MyFile
            {
                FileName = fileProps.FileName,
                FilePath = fileProps.FilePath,
                FileSize = file.Length,
                ContentType = file.ContentType,
                URL = fileProps.URL,
                Message = null,
                User = null

            };

            var fileEntityId = await _fileService.Upload(fileEntity);

            if (fileEntityId == Guid.Empty)
                return StatusCode(500, new { message = "Помилка при збереженні файлу в базі даних" });

            return Ok(new 
            {
                Id = fileEntityId
            });

        }
        [Authorize]
        [HttpPost("UploadAvatar")]
        public async Task<ActionResult> UploadAvatar([FromForm] IFormFile file)
        {
            var userId = User.FindFirst("userId")?.Value;

            if (userId == null)
            {
                return Unauthorized("Invalid token");
            }

            var user = await _userService.GetById(Guid.Parse(userId));

            if (user == null)
            {
                return BadRequest(new { message = "Користувач не знайдений" });
            }

            var fileProps = await GetFileProperties(file);

            var fileEntity = new MyFile
            {
                FileName = fileProps.FileName,
                FilePath = fileProps.FilePath,
                FileSize = file.Length,
                ContentType = file.ContentType,
                URL = fileProps.URL,
                Message = null,
                User = user
            };

            var avatar = await _fileService.UploadAvatar(fileEntity);

            if (avatar == null)
                return StatusCode(500, new { message = "Помилка при збереженні файлу в базі даних" });

            return Ok(new
            {
                activeAvatar = avatar
            });

        }

    }
}
