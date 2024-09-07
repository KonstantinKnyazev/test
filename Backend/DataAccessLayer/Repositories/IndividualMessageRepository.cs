using Medfar.Interview.Types;
using System.Data.SqlClient;

namespace Medfar.Interview.DAL.Repositories
{
    public class IndividualMessageRepository
    {
        private static string _connectionString = @"Data Source=localhost;Initial Catalog=MEDFAR_DEV_INTERVIEW;Integrated Security=True";
        private static SqlConnection _dbConnection;

        public IndividualMessageRepository()
        {
        }

        public List<IndividualMessage> GetAll()
        {
            _dbConnection = new SqlConnection(_connectionString);
            SqlCommand command = new SqlCommand("SELECT * FROM IndividualMessage", _dbConnection);

            _dbConnection.Open();

            SqlDataReader reader = command.ExecuteReader();


            List<IndividualMessage> messages = new List<IndividualMessage>();
            while (reader.Read())
            {
                IndividualMessage message = new IndividualMessage
                {
                    Id = (Guid)reader["Id"],
                    Version = (int)reader["Version"],
                    CreationDate = (DateTime)reader["CreationDate"],
                    CreatedBy = (Guid)reader["CreatedBy"],
                    LastUpdateDate = (DateTime?)reader["LastUpdateDate"],
                    LastUpdatedBy = (Guid?)reader["LastUpdatedBy"],
                    DeletionDate = (DateTime?)reader["DeletionDate"],
                    DeletedBy = (Guid?)reader["DeletedBy"],
                    ArchivalDate = (DateTime?)reader["ArchivalDate"],
                    ArchivedBy = (Guid?)reader["ArchivedBy"],
                    Subject = (string)reader["Subject"],
                    Body = (string)reader["Body"],
                    SendDate = (DateTime)reader["SendDate"],
                    IsTask = (bool)reader["IsTask"],
                    StartDate = (DateTime?)reader["StartDate"],
                    DueDate = (DateTime?)reader["DueDate"],
                    IsDraft = (bool)reader["IsDraft"],
                    IsGroupTask = (bool?)reader["IsGroupTask"],
                    DocumentPatientId = (Guid?)reader["DocumentPatientId"],
                    FileName = (string)reader["FileName"],
                    TypeTaskLookupId = (Guid?)reader["TypeTaskLookupId"],
                    PriorityLookupId = (Guid?)reader["PriorityLookupId"],
                    FromContactId = (Guid)reader["FromContactId"]
                };

                messages.Add(message);
            }

            return messages;
        }

        public List<IndividualMessage> Search(string searchString, DateTime? fromDate, DateTime? toDate)
        {
            _dbConnection = new SqlConnection(_connectionString);

            string sqlQuery = @"SELECT * FROM " +
                                 " IndividualMessage " +
                                 " WHERE (subject like '%" + searchString + "%' OR Body like  '%" + searchString + "%' ) ";
            SqlCommand command = new SqlCommand(sqlQuery, _dbConnection);
            

            if (fromDate.HasValue)
            {
                sqlQuery += " AND SendDate >= '" + fromDate + "'";
            }
            if (toDate.HasValue)
            {
                sqlQuery += " AND SendDate <= '" + toDate + "'";
            }
            
            _dbConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            List<IndividualMessage> messages = new();

            while (reader.Read())
            {
                IndividualMessage message = new()
                {
                    Id = (Guid)reader["Id"],
                    Version = (int)reader["Version"],
                    CreationDate = (DateTime)reader["CreationDate"],
                    CreatedBy = (Guid)reader["CreatedBy"],
                    LastUpdateDate = (DateTime?)reader["LastUpdateDate"],
                    LastUpdatedBy = (Guid?)reader["LastUpdatedBy"],
                    DeletionDate = (DateTime?)reader["DeletionDate"],
                    DeletedBy = (Guid?)reader["DeletedBy"],
                    ArchivalDate = (DateTime?)reader["ArchivalDate"],
                    ArchivedBy = (Guid?)reader["ArchivedBy"],
                    Subject = (string)reader["Subject"],
                    Body = (string)reader["Body"],
                    SendDate = (DateTime)reader["SendDate"],
                    IsTask = (bool)reader["IsTask"],
                    StartDate = (DateTime?)reader["StartDate"],
                    DueDate = (DateTime?)reader["DueDate"],
                    IsDraft = (bool)reader["IsDraft"],
                    IsGroupTask = (bool?)reader["IsGroupTask"],
                    DocumentPatientId = (Guid?)reader["DocumentPatientId"],
                    FileName = (string)reader["FileName"],
                    TypeTaskLookupId = (Guid?)reader["TypeTaskLookupId"],
                    PriorityLookupId = (Guid?)reader["PriorityLookupId"],
                    FromContactId = (Guid)reader["FromContactId"]
                };

                messages.Add(message);
            }

            return messages;
        }

    }
}


