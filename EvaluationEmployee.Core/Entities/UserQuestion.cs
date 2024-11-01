namespace _5W2H.Core.Entities
{
    public class UserQuestion : BaseEntity
    {
        public UserQuestion() { }
    
        public UserQuestion(string text, string topic)
        {
            Text = text;
            Topic = topic;
        }

        public string Text { get; set; } 
        public string Topic { get; set; }
    }
}