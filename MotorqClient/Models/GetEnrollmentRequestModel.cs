namespace MotorqService.Models
{
    public class GetEnrollmentRequestModel
    {
        public string vin { get; set; }
        public string vehicleId { get; set; }
        public int count { get; set; }
        public string cursor { get; set; }
    }
}
