namespace _5W2H.Core.Entities
{
    public class LeaderQuestion 
    {
        public LeaderQuestion() { }
    
        public LeaderQuestion(string text, string topic)
        {
            Text = text;
            Topic = topic;
        }
    
        public int Id { get; private set; }
        public string Text { get; set; } 
        public string Topic { get; set; }
    }
}
