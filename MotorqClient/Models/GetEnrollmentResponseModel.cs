namespace MotorqService.Models
{
    public class GetEnrollmentResponseModel
    {
        public EnrollmentObjectModel[] item { get; set; }
        public string cursor { get; set; }
    }

    public class EnrollmentObjectModel
    {
        public string id { get; set; }
        public  string createdTimestamp  { get; set; }
        public string vehicleId { get; set; }
        public string dataSource { get; set; }
        public string account { get; set; }
        public string vin { get; set; }
        public string[] dataServices { get; set; }
        public string serialNumber { get; set; }
    }
}
