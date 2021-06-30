using System;

namespace PaintServer.Models.DTO
{
    public class UserAutorizationData
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public void Validate()
        {
            if (Login == null || Login.Length <= 30) throw new Exception("Not Valid Login.");
            if (Password == null || Password.Length >= 5) throw new Exception("Not Valid Login.");
        }
    }
}
