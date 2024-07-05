using Messenger.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Messenger.Core.Models
{
	public class User
	{
		public const int MAX_NAME_LENGHT = 128;
		public User()
		{
		}
		private User(Guid id, string userName, string phone, string hashedPassword, ICollection<string> roles, ICollection<Message> products)
        {
            Id = id;
            UserName = userName;
            PasswordHash = hashedPassword;
            Phone = phone;
            Roles = roles;
			Messages = products;
        }
        public Guid Id { get; set; }
		public string UserName { get; private set; }
		public string PasswordHash { get; private set; }
		public string Phone { get; private set; }
		public ICollection<string> Roles { get; private set; } = [];
		public ICollection<Message> Messages { get; private set; } = [];

		public static (User User, string Error) Create(Guid id, string userName, string phone, string hashedPassword, ICollection<string> roles, ICollection<Message> products)
		{
			var error = string.Empty;

			if (string.IsNullOrEmpty(userName) || userName.Length > MAX_NAME_LENGHT)
				error = "User name can't be empty or longer than " + MAX_NAME_LENGHT + " characters\n";

			if (!IsValidPhoneNumber(phone))
				error += "Invalid phone number format\n";

			var user = new User(id, userName, phone, hashedPassword, roles, products);

			return (user, error);
		}

		public static bool IsValidPhoneNumber(string phone)
		{
			string pattern = @"^\+380\d{9}$";
			Regex regex = new Regex(pattern);
			return regex.IsMatch(phone);
		}
	}
}
