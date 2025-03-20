using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;

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
            };

            var entity = await _context.Files.AddAsync(fileEntity);
            await _context.SaveChangesAsync();
            return entity.Entity.Id;
        }

        public async Task<Message> AddPhotosToMessage(Guid messageId, Guid photoId)
        {
            var messageEntity = await _context.Messages.FindAsync(messageId);
            var photoEntity = await _context.Files.FindAsync(photoId);
            messageEntity.Files.Add(photoEntity);
            photoEntity.Message = messageEntity;
            photoEntity.MessageId = messageId;
            await _context.SaveChangesAsync();  
            return _mapper.Map<Message>(messageEntity);

        }
    }
}
