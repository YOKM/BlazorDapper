using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using ImagingTask.Data;
using ImagingTask.Model;

namespace ImagingTask.Services
{
    public class DetailTaskService : InterfaceDetailTask
    {
        private readonly SqlConnectionConfiguration _configuration;

        public DetailTaskService(SqlConnectionConfiguration connectionConfiguration)
        {
            _configuration = connectionConfiguration;

        }

        public Task<bool> CreateImagingTask(ImagingScheduleJob_Detail NewDetailSchTask)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteTask(int jobId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditImagingTask(int jobId, ImagingTaskDetailModel EditDetailSchTask)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ImagingTaskDetailModel>> GetAllImagingTaskDetail()
        {
            throw new NotImplementedException();
        }

        public async Task<ImagingTaskDetailModel> SingleTask(int jobId)
        {
            ImagingTaskDetailModel DetailTask = new ImagingTaskDetailModel();

            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string query = @"select * from dbo.Imaging_JOBdetails where Jobid =@jobId";

                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    DetailTask = await conn.QueryFirstOrDefaultAsync<ImagingTaskDetailModel>(query, new { jobId }, commandType: CommandType.Text);
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
            return DetailTask;
        }
    }

       
       
   
}
