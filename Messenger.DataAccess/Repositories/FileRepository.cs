using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Messenger.DataAccess.Repositories
{
    public class FileRepository : IFileRepository
    {
        private readonly MessengerDBcontext _context;
        private readonly IMapper _mapper;
        public FileRepository(MessengerDBcontext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Guid> UploadFile(MyFile file)
        {
            FileEntity fileEntity = new FileEntity()
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                ContentType = file.ContentType,
                URL = file.URL,
            };

            var entity = await _context.Files.AddAsync(fileEntity);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }
        private async Task SetActiveAvatar(Guid userId, Guid avatarId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (user != null)
            {
                user.ActiveAvatarId = avatarId;
                await _context.SaveChangesAsync();
            }
        }



        public async Task<MyFile> UploadAvatar(MyFile file)
        {
            var userEntity = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == file.User.Id);

            if (userEntity == null)
                throw new Exception("Користувача не знайдено");

            var fileEntity = new FileEntity
            {
                FileName = file.FileName,
                FilePath = file.FilePath,
                FileSize = file.FileSize,
                ContentType = file.ContentType,
                URL = file.URL,
                UserId = userEntity.Id // важливо!
            };

            _context.Files.Add(fileEntity); // додаємо в контекст

            await _context.SaveChangesAsync(); // зберігаємо, щоб файл отримав Id

            await SetActiveAvatar(userEntity.Id, fileEntity.Id);

            return _mapper.Map<MyFile>(fileEntity);
        }

        public async Task<bool> IsFileExists(Guid fileId) => await _context.Chats.AnyAsync(c => c.Id == fileId);

    }
}
