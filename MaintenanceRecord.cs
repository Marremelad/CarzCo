using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarzCo
{
    public class MaintenanceRecord
    {
        public readonly int Id;
        public ServiceType ServiceType { get; set; }
        public DateTime Date = DateTime.Today;
        internal MaintenanceRecord(int id, ServiceType servicetype) {
            Id = id;
            ServiceType = servicetype;
        }    
    }
}
