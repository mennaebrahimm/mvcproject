namespace mvcproject.Models
{
    public enum NotificationStatus
    {
        read=0,
        unread=1,
        deleted=2
    }
    public class Notification
    {
        public int id { get; set; }   
        public string title { get; set; }

        public string content {  get; set; }

        public NotificationStatus status { get; set; }

    }
}
