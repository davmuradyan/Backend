namespace Backend.Data.Entities {
    public class UserFeedbackEntity {
        public int UserFeedbackID { get; set; }
        public int UserID { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public int? Rating { get; set; }
        public DateTime SubmitDate { get; set; }

        public UserEntity? User { get; set; }
    }
}