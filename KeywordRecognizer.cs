using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    public class KeywordRecognizer
    {
        private readonly ResponseGenerator _responseGenerator;
        private readonly Dictionary<string, string> _keywords = new Dictionary<string, string>()
        {
            { "password", "password" },
            { "phishing", "phishing" },
            { "privacy", "privacy" },
            { "scam", "scam" }
        };

        public KeywordRecognizer(ResponseGenerator responseGenerator)
        {
            _responseGenerator = responseGenerator;
        }

        public string RecognizeKeyword(string input)
        {
            foreach (var keyword in _keywords.Keys)
            {
                if (input.Contains(keyword))
                {
                    return _keywords[keyword];
                }
            }
            return null;
        }
    }
}
