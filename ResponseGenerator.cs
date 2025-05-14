using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    public class ResponseGenerator
    {
        private readonly Random _random = new Random();

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

        public string GenerateResponse(string userInput, string recognizedKeyword, UserMemory memory)
        {
            if (recognizedKeyword != null && _tips.ContainsKey(recognizedKeyword))
            {
                return $"{GetRandomTip(recognizedKeyword)}";
            }

            
            return $"I'm not sure I understood that. Could you ask about a specific cybersecurity topic like 'passwords' or 'phishing'?";
        }

        private string GetRandomTip(string topic)
        {
            if (_tips.ContainsKey(topic))
            {
                var list = _tips[topic];
                return list[_random.Next(list.Count)];
            }
            return "";
        }
    }
}