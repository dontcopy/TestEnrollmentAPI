namespace MotorqService.Models
{
    public class AuthRequest<T>
    {
        public string accessToken { get; set; }
        public T payLoad { get; set; }
    }
}
