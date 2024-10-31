namespace _5W2H.Core.Entities
{
    public class Question : BaseEntity
    {
        public Question() { }
    
        public Question(string text, string topic)
        {
            Text = text;
            Topic = topic;
        }

        public string Text { get; set; } 
        public string Topic { get; set; }
    }
}