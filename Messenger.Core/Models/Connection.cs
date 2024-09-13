using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
	public class Connection
	{
        public Connection(Guid userId, string connectionId, string stingConnection)
        {
            UserId= userId;
            ConnectionId = connectionId;
            StingConnection = stingConnection;
        }
        public Guid UserId { get; set; }
        public string ConnectionId { get; set; } = string.Empty;
		public string StingConnection { get; set; } = string.Empty;

		public static Connection Create(Guid userId, string connectionId, string stingConnection)
        {
            var connection = new Connection(userId, connectionId, stingConnection); 

            return connection;
        }
	}
}
