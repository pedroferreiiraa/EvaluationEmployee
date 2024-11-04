namespace _5W2H.Core.Entities
{
    public class LeaderQuestion : BaseEntity
    {
        public LeaderQuestion() { }
    
        public LeaderQuestion(string text, string topic)
        {
            Text = text;
            Topic = topic;
        }

        public string Text { get; private set; } 
        public string Topic { get; private set; }
    }
}
