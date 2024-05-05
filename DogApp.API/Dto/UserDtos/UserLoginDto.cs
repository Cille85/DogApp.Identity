namespace DogApp.API.Dto.UserDtos
{
    public class UserLoginDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}