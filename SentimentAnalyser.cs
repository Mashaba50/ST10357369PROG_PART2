using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    public class SentimentAnalyser
    {
        private readonly List<string> _positiveWords = new List<string> { "curious", "interested", "excited", "good", "great", "thank you", "thanks" };
        private readonly List<string> _negativeWords = new List<string> { "worried", "confused", "frustrated", "scared", "bad", "terrible", "help", "problem" };

        public string AnalyzeSentiment(string input)
        {
            string lowerInput = input.ToLower();

            foreach (var word in _positiveWords)
            {
                if (lowerInput.Contains(word))
                {
                    return Chatbot.GetRandomResponse("positive_acknowledgement") + " 👍";
                }
            }

            foreach (var word in _negativeWords)
            {
                if (lowerInput.Contains(word))
                {
                    return Chatbot.GetRandomResponse("negative_acknowledgement") + " 🤔";
                }
            }
            return "";
        }
    }
}