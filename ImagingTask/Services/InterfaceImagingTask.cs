using ImagingTask.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImagingTask.Data;



namespace ImagingTask.Services
{
   public interface InterfaceImagingTask
    {
      
        Task<IEnumerable<ImagingTaskModel>> GetAllImagingTask(int takeRow, int skipRow);

        Task<bool> CreateImagingTask(ImagingScheduleJob imagingSchTask);

        Task<bool> EditImagingTask(int jobId, ImagingTaskModel imagingSchTask);

        Task<ImagingTaskModel> SingleTask(int jobId);

        Task<bool> DeleteTask(int jobId);

    }
}
