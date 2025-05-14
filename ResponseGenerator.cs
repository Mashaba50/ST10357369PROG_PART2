using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    /// <summary>
    /// Responsible for generating responses based on user input.
    /// Provides tips or guidance related to cybersecurity topics.
    /// </summary>
    public class ResponseGenerator
    {
        // Random number generator to select random tips
        private readonly Random _random = new Random();

        // Dictionary mapping topics to a list of tips for each topic
        private readonly Dictionary<string, List<string>> _tips = new Dictionary<string, List<string>>()
        {
            ["password"] = new List<string>
            {
                "Use a unique password for every account.",
                "Avoid using birthdays or names as passwords.",
                "Consider using a password manager for better security.",
                "Aim for passwords that are at least 12 characters long.",
                "Include a mix of uppercase, lowercase letters, numbers, and symbols."
            },
            ["phishing"] = new List<string>
            {
                "Never click on suspicious links in emails or messages.",
                "Double-check the sender's email address and domain.",
                "Be wary of emails that create a sense of urgency.",
                "Hover over links before clicking to see the actual URL.",
                "Never provide sensitive information via email."
            },
            ["privacy"] = new List<string>
            {
                "Limit the personal information you share on social media.",
                "Review and adjust privacy settings on your apps and accounts.",
                "Use privacy-focused browsers and search engines.",
                "Be cautious about granting app permissions.",
                "Consider using a VPN on public Wi-Fi."
            },
            ["scam"] = new List<string>
            {
                "Avoid sharing sensitive information over the phone or email.",
                "Be cautious of 'too good to be true' offers and prizes.",
                "Trust your instincts — if something feels off, it probably is.",
                "Verify requests from unknown contacts through official channels.",
                "Never send money to someone you haven't met in person."
            }
        };

        /// <summary>
        /// Generates a response based on user input and recognized keyword.
        /// If a recognized keyword is provided, returns a random tip related to that topic.
        /// Otherwise, prompts the user to ask about a specific cybersecurity topic.
        /// </summary>
        /// <param name="userInput">The raw input from the user (not used directly here).</param>
        /// <param name="recognizedKeyword">The keyword recognized from user input, if any.</param>
        /// <param name="memory">UserMemory object to keep track of user data (not used here but available for expansion).</param>
        /// <returns>A response string with a tip or prompt.</returns>
        public string GenerateResponse(string userInput, string recognizedKeyword, UserMemory memory)
        {
            // If a valid keyword was recognized and exists in tips dictionary
            if (recognizedKeyword != null && _tips.ContainsKey(recognizedKeyword))
            {
                // Return a randomly selected tip for that topic
                return $"{GetRandomTip(recognizedKeyword)}";
            }

            // If no recognized keyword, prompt user to ask about specific topics
            return $"I'm not sure I understood that. Could you ask about a specific cybersecurity topic like 'passwords' or 'phishing'?";
        }

        /// <summary>
        /// Retrieves a random tip for a given topic from the tips list.
        /// </summary>
        /// <param name="topic">The topic for which to get a tip (e.g., 'password').</param>
        /// <returns>A randomly selected tip string, or an empty string if topic not found.</returns>
        private string GetRandomTip(string topic)
        {
            if (_tips.ContainsKey(topic))
            {
                var list = _tips[topic]; // Get the list of tips for the topic
                // Select a random tip from the list
                return list[_random.Next(list.Count)];
            }
            // Return empty string if topic not found
            return "";
        }
    }
}