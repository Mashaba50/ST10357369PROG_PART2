using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    /// <summary>
    /// Recognizes predefined keywords within user input.
    /// Used to identify specific topics or intents in user queries.
    /// </summary>
    public class KeywordRecognizer
    {
        // Dependency on ResponseGenerator, if needed for future expansion
        private readonly ResponseGenerator _responseGenerator;

        // Dictionary of keywords to recognize, mapping keyword trigger words to their identifiers
        private readonly Dictionary<string, string> _keywords = new Dictionary<string, string>()
        {
            { "password", "password" },
            { "phishing", "phishing" },
            { "privacy", "privacy" },
            { "scam", "scam" }
        };

        /// <summary>
        /// Constructor that initializes the KeywordRecognizer with dependencies.
        /// </summary>
        /// <param name="responseGenerator">An instance of ResponseGenerator, currently not used but available for expansion.</param>
        public KeywordRecognizer(ResponseGenerator responseGenerator)
        {
            _responseGenerator = responseGenerator;
        }

        /// <summary>
        /// Checks if the input contains any of the predefined keywords.
        /// If a keyword is found, returns the corresponding keyword string.
        /// If no keywords are found, returns null.
        /// </summary>
        /// <param name="input">The user input string to analyze.</param>
        /// <returns>The recognized keyword string or null if none found.</returns>
        public string RecognizeKeyword(string input)
        {
            // Loop through all the predefined keywords
            foreach (var keyword in _keywords.Keys)
            {
                // Check if the input contains the current keyword
                if (input.Contains(keyword))
                {
                    // Return the associated keyword value
                    return _keywords[keyword];
                }
            }
            // No keywords recognized
            return null;
        }
    }
}