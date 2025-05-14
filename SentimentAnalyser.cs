using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    /// <summary>
    /// Analyzes user input to determine the sentiment (positive or negative).
    /// Uses simple keyword matching to infer user mood or attitude.
    /// </summary>
    public class SentimentAnalyser
    {
        // List of keywords indicating positive sentiment
        private readonly List<string> _positiveWords = new List<string> { "curious", "interested", "excited", "good", "great", "thank you", "thanks" };

        // List of keywords indicating negative sentiment
        private readonly List<string> _negativeWords = new List<string> { "worried", "confused", "frustrated", "scared", "bad", "terrible", "help", "problem" };

        /// <summary>
        /// Analyzes the user's input to determine sentiment.
        /// Checks for presence of positive or negative keywords.
        /// </summary>
        /// <param name="input">The user's input string.</param>
        /// <returns>
        /// A sentiment-based response string, including an acknowledgment and an emoji.
        /// Returns an empty string if no sentiment keywords are detected.
        /// </returns>
        public string AnalyzeSentiment(string input)
        {
            // Convert input to lowercase for case-insensitive matching
            string lowerInput = input.ToLower();

            // Check for positive sentiment keywords
            foreach (var word in _positiveWords)
            {
                if (lowerInput.Contains(word))
                {
                    // Return a positive acknowledgment with a thumbs-up emoji
                    return Chatbot.GetRandomResponse("positive_acknowledgement") + " 👍";
                }
            }

            // Check for negative sentiment keywords
            foreach (var word in _negativeWords)
            {
                if (lowerInput.Contains(word))
                {
                    // Return a negative acknowledgment with a thinking face emoji
                    return Chatbot.GetRandomResponse("negative_acknowledgement") + " 🤔";
                }
            }

            // If no sentiment keywords are found, return an empty string (no response)
            return "";
        }
    }
}