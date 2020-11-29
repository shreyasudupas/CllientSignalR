using SampleWebAPISignalR.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SampleWebAPISignalR.Repository
{
    public class DatabaseRepository
    {
        private readonly string conString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
        List<Messages> messages = new List<Messages>();

        public List<Messages> GetAllMessage()
        {
            using (var db = new  SqlConnection(conString))
            {
                db.Open();
                var sqlcommand = @"SELECT [MessageID], [Message], [EmptyMessage], [Date] FROM [dbo].[Messages]";
                SqlCommand cmd = new SqlCommand(sqlcommand, db);

                //SqlDependency dependency = new SqlDependency(cmd);
                //dependency.OnChange += new OnChangeEventHandler(dependency_OnChange);

                if (db.State == ConnectionState.Closed)
                    db.Open();

                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    messages.Add(new Messages
                    {
                        MessageID = (int)reader["MessageID"],
                        Message = (string) reader["Message"],
                        EmptyMessage = (reader["EmptyMessage"] != DBNull.Value) ? (string)reader["EmptyMessage"] : string.Empty,
                        MessageDate = Convert.ToDateTime(reader["Date"])
                    });
                }
            }
            return messages;
        }

        public int insertMessage(Messages msg)
        {
            int result = 0;
            try
            {
                using (var db = new SqlConnection(conString))
                {
                    db.Open();
                    var sqlcommd = "insert into [Messages](Message,EmptyMessage) values(@msg,@emptmsg)";
                    SqlParameter param1 = new SqlParameter("@msg",msg.Message);
                    SqlParameter param2 = new SqlParameter("@emptmsg", msg.EmptyMessage);
                    SqlCommand cmd = new SqlCommand(sqlcommd, db);
                    cmd.Parameters.Add(param1);
                    cmd.Parameters.Add(param2);

                    cmd.ExecuteNonQuery();
                    result = 1;
                }
            }catch(Exception e)
            {
                
            }
            return result;
        }

        private void dependency_OnChange(object sender, SqlNotificationEventArgs e)
        {
            //if (e.Type == SqlNotificationType.Change)
            //{
            //    MessagesHub.MessageHub.SendMessage(messages);
            //}
        }
    }
}