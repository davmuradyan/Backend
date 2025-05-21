namespace Backend.Data.Entities {
    public class UserEntity {
        public int UserID { get; set; }
        public required string IP { get; set; }
        public DateTime ConnectionTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public DateTime? DisconnectionTime { get; set; }
        public int? CityID { get; set; }

        public CityEntity? City { get; set; }
        public ICollection<UserFeedbackEntity> Feedbacks { get; set; } = new List<UserFeedbackEntity>();
    }
}