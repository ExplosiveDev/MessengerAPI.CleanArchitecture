using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;

namespace Messenger.DataAccess.Mapping
{
	public class DataBaseMapping : Profile
	{
        public DataBaseMapping()
        {
			CreateMap<UserEntity, User>().ReverseMap();

			CreateMap<string, RoleEntity>()
				.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src))
				.ForMember(dest => dest.Id, opt => opt.Ignore());

			CreateMap<RoleEntity, string>()
				.ConvertUsing(src => src.Name);

			CreateMap<MessageEntity, Message>()
				.ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp.ToString("yyyy:MM:dd:HH:mm:ss")))
				.ReverseMap();

            CreateMap<ChatEntity, Chat>().ReverseMap();
			CreateMap<ConnectionEntity, Connection>().ReverseMap();
			CreateMap<PrivateChatEntity, PrivateChat>().ReverseMap();
			CreateMap<GroupChatEntity, GroupChat>().ReverseMap();
			CreateMap<UserChatEntity, UserChat>().ReverseMap();
			CreateMap<TextMessageEntity, TextMessage>().ReverseMap();
			CreateMap<MediaMessageEntity, MediaMessage>().ReverseMap();
			CreateMap<FileEntity, MyFile>().ForMember(dest => dest.FilePath, opt => opt.Ignore()).ReverseMap();

		}
    }
}
