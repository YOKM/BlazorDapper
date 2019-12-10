using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ImagingTask.Data;
using ImagingTask.Model;
using Dapper;
using System.Data;

namespace ImagingTask.Services
{
    public class ImagingTaskService : InterfaceImagingTask
    {
        private readonly SqlConnectionConfiguration _configuration;

        public ImagingTaskService(SqlConnectionConfiguration connectionConfiguration)
        {
            _configuration = connectionConfiguration;

        }


        public Task<bool> CreateImagingTask(ImagingScheduleJob imagingSchTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTask(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditImagingTask(int jobId, ImagingTaskModel imagingSchTask)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ImagingTaskModel>> GetAllImagingTask()
        {
            IEnumerable<ImagingTaskModel> imagingTaskModels;

            const string query = @"select * from dbo.ImagingScheduleJob";

            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    imagingTaskModels = await conn.QueryAsync<ImagingTaskModel>
                        ("Get_AllImagingTask", commandType: CommandType.StoredProcedure);


                    //  imagingTaskModels = await conn.QueryAsync<ImagingTaskModel>(query);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
             }
            return imagingTaskModels;

        }

        public Task<ImagingTaskModel> SingleTask(int jobId)
        {
            throw new NotImplementedException();
        }
    }
}
