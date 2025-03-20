using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Messenger.Core.Models;
using Messenger.DataAccess.Repositories;

namespace Messenger.Application.Services
{
    public class FileService : IFileService
    {
        private readonly IFileRepository _fileRepository;

        public FileService(IFileRepository fileRepository)
        {
            _fileRepository = fileRepository;
        }

        public async Task<Guid> Upload(MyFile file)
        {
            return await _fileRepository.UploadFile(file);
        }
    }
}
