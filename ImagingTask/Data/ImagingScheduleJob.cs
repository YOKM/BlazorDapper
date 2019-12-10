using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImagingTask.Data
{
    public class ImagingScheduleJob
    {
        public int Id { get; set; }
        public string Jobname { get; set; }
        public string scheduleTIME { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public string JOBTYPE { get; set; }

        public string EmailNotificationAddress { get; set; }
    }
}
