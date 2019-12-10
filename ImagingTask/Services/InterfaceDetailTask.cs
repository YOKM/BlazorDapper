using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImagingTask.Model;
using ImagingTask.Data;

namespace ImagingTask.Services
{
    interface InterfaceDetailTask
    {
        Task<IEnumerable<ImagingTaskDetailModel>> GetAllImagingTaskDetail();

        Task<bool> CreateImagingTask(ImagingScheduleJob_Detail NewDetailSchTask);

        Task<bool> EditImagingTask(int jobId, ImagingTaskDetailModel EditDetailSchTask);

        Task<ImagingTaskDetailModel> SingleTask(int jobId);

        Task<bool> DeleteTask(int jobId);
    }
}
