namespace CarzCo
{
    // Class representing a maintenance record for a vehicle.
    public class MaintenanceRecord
    {
        // Unique identifier for the maintenance record.
        public readonly int Id;

        // Type of service performed (e.g., repair, inspection).
        public ServiceType ServiceType { get; set; }

        // Date the service was performed, defaulting to today's date.
        public DateTime Date = DateTime.Today;

        // Constructor for initializing a maintenance record with an ID and service type.
        internal MaintenanceRecord(int id, ServiceType servicetype) 
        {
            Id = id;
            ServiceType = servicetype;
        }    
    }
}