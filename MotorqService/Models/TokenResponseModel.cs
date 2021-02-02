namespace MotorqService.Models
{
    public class TokenResponseModel
    {
        public  string accessToken { get; set; }
        public int expiresIn { get; set; }
        public string tokenType { get; set; }
    }
}
