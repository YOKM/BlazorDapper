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

        public async Task<bool> EditImagingTask(int jobid, ImagingTaskDetailModel EditDetailSchTask)
        {
            var parameters = new DynamicParameters();

            parameters.Add("Jobid", jobid, DbType.Int32);
            parameters.Add("Jobname", EditDetailSchTask.Jobname, DbType.String);
            parameters.Add("EmailNotificationAddress", EditDetailSchTask.EmailNotificationAddress, DbType.String);
            parameters.Add("JobdetailsType", EditDetailSchTask.JobdetailsType, DbType.String);
            parameters.Add("SFtphost", EditDetailSchTask.SFtphost, DbType.String);
            parameters.Add("SFtpuploadFrom", EditDetailSchTask.SFtpuploadFrom, DbType.String);
            parameters.Add("SFtpuploadto", EditDetailSchTask.SFtpuploadto, DbType.String);

            parameters.Add("SFtpdownloadFrom", EditDetailSchTask.SFtpdownloadFrom, DbType.String);
            parameters.Add("SFtpdownloadTo", EditDetailSchTask.SFtpdownloadTo, DbType.String);
            parameters.Add("UsernamesFtp", EditDetailSchTask.UsernamesFtp, DbType.String);
            parameters.Add("PaswordsFtp", EditDetailSchTask.PaswordsFtp, DbType.String);

            parameters.Add("SshfingerPrint", EditDetailSchTask.SshfingerPrint, DbType.String);
            parameters.Add("Extra1", EditDetailSchTask.Extra1, DbType.String);
            parameters.Add("Extra2", EditDetailSchTask.Extra2, DbType.String);
            parameters.Add("Extra3", EditDetailSchTask.Extra3, DbType.String);
            parameters.Add("Extra4", EditDetailSchTask.Extra4, DbType.String);
            parameters.Add("Extra5", EditDetailSchTask.Extra5, DbType.String);

            parameters.Add("FileExtensiontoUpload", EditDetailSchTask.FileExtensiontoUpload, DbType.String);
            parameters.Add("PortNumber", EditDetailSchTask.PortNumber, DbType.String);
            parameters.Add("WordsToCheck", EditDetailSchTask.WordsToCheck, DbType.String);


            using (var conn = new SqlConnection(_configuration.Value))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync("Update_ImagingDetailTask", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex) { throw ex; }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
                return true;
            }

            return true;

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
