using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Core.Models
{
	public class Connection
	{
        public Connection(string connectionId, string stingConnection)
        {
            ConnectionId = connectionId;
            StingConnection = stingConnection;
        }
        public string ConnectionId { get; set; } = string.Empty;
		public string StingConnection { get; set; } = string.Empty;

		public static Connection Create(string connectionId, string stingConnection)
        {
            var connection = new Connection(connectionId, stingConnection); 

            return connection;
        }
	}
}
