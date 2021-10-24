namespace HumanGuide.Core.Application.DTOs
{
    public class GetConnectedHumanDto
    {
        public int Id { get; set; }
        public GetHumanDto BaseConnectedHuman { get; set; }
    }
}
