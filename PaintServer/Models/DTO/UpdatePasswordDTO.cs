namespace PaintServer.Models.DTO
{
    public class UpdatePasswordDTO : UserAutorizationData
    {
        public string NewPassword{ get; set; }
    }
}
