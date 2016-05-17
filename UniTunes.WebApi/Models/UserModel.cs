using UniTunes.Core.Domain.Model;

namespace UniTunesApi.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserStatus Status { get; set; }
        public bool IsAdministrator { get; set; }
        public string Password { get; set; }
    }
}