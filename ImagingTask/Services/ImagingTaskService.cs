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

        public async Task<IEnumerable<ImagingTaskModel>> GetAllImagingTask(int takeRow, int skipRow)
        {
            IEnumerable<ImagingTaskModel> imagingTaskModels;

            const string query = @"select * from dbo.ImagingScheduleJob order by Jobname
                                    offset @takeRow rows
                                    fetch next @skipRow rows only";

             //order by Jobname-- this is a MUST there must be ORDER BY statement
             // --the paging comes here
             //offset 5 rows-- skip 10 rows
             //fetch next 4 rows only; --take 10 rows

            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    //imagingTaskModels = await conn.QueryAsync<ImagingTaskModel>
                    //    ("Get_AllImagingTask", commandType: CommandType.StoredProcedure);


                      imagingTaskModels = await conn.QueryAsync<ImagingTaskModel>(query, new { takeRow,skipRow }, commandType: CommandType.Text);

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

        public async Task<ImagingTaskModel> SingleTask(int jobId)
        {
            ImagingTaskModel TaskModel = new ImagingTaskModel();
            const string query = @"select * from dbo.ImagingScheduleJob where id =@jobId";

            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try { 
                    TaskModel = await conn.QueryFirstOrDefaultAsync<ImagingTaskModel>(query, new { jobId }, commandType: CommandType.Text); }
                catch (Exception ex) { throw ex; }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
                return TaskModel;
            }
        }
    }
}
