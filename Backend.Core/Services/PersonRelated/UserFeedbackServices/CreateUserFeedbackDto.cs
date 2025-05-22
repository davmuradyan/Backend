namespace Backend.Core.Services.PersonRelated.UserFeedbackServices
{
    public record CreateUserFeedbackDto
    {
        public int UserID { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public int? Rating { get; set; }
        public DateTime SubmitDate { get; set; }
    }
}
