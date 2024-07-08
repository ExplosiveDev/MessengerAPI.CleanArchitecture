using AutoMapper;
using Messenger.Core.Models;
using Messenger.DataAccess.Entities;
using Messenger.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

			CreateMap<MessageEntity, Message>().ReverseMap();
			CreateMap<ChatEntity, Chat>().ReverseMap();
			CreateMap<ConnectionEntity, Connection>().ReverseMap();

		}
    }
}
