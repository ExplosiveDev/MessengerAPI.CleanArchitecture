using AutoMapper;
using Messenger.API.Contracts;
using Messenger.Core.Models;

namespace Messenger.API.Mapping
{
	public class ContractsMapping : Profile
	{
        public ContractsMapping()
        {
            CreateMap<UserResponse,User>().ReverseMap();
        }
    }
}
