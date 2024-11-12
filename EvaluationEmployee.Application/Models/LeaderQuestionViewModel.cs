using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _5W2H.Core.Entities;

namespace _5W2H.Application.Models
{
    public class LeaderQuestionViewModel
    {
        public LeaderQuestionViewModel() {}
        public LeaderQuestionViewModel(int questionId, string text, string topic) 
        {
            QuestionId = questionId;
            Text = text;
            Topic = topic;
        }


        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Topic { get; set;}

        public static LeaderQuestionViewModel FromEntity(LeaderQuestion leaderQuestion)
            => new (leaderQuestion.Id, leaderQuestion.Text, leaderQuestion.Topic);
    }
}