namespace Multishop.Message.DataAccess.Entities
{
    public class UserMessage
    {
        public int UserMessageId { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
        public DateTime SendDate { get; set; }
    }
}
