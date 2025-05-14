using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    public class ConversationManager
    {
        private readonly KeywordRecognizer _keywordRecognizer;
        private readonly ResponseGenerator _responseGenerator;
        private readonly SentimentAnalyser _sentimentAnalyser;
        private readonly UserMemory _userMemory;

        public ConversationManager(
            KeywordRecognizer keywordRecognizer,
            ResponseGenerator responseGenerator,
            SentimentAnalyser sentimentAnalyser,
            UserMemory userMemory)
        {
            _keywordRecognizer = keywordRecognizer;
            _responseGenerator = responseGenerator;
            _sentimentAnalyser = sentimentAnalyser;
            _userMemory = userMemory;
        }

        public void HandleUserQueries()
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nAsk a cybersecurity question (or type 'exit'): ");
                string input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Chatbot.TypeWriteLine("Please enter a valid question.", ConsoleColor.Red);
                    continue;
                }

                if (input == "exit")
                {
                    var farewell = Chatbot.GetRandomResponse("farewell");
                    Chatbot.TypeWriteLine(farewell, ConsoleColor.Green);
                    break;
                }

                // Recognize keywords
                string recognizedKeyword = _keywordRecognizer.RecognizeKeyword(input);

                // Detect sentiment
                string sentimentResponse = _sentimentAnalyser.AnalyzeSentiment(input);

                // Generate response
                string response = _responseGenerator.GenerateResponse(input, recognizedKeyword, _userMemory);

                // Print conversation
                Console.WriteLine($"User: \"{input}\"");
                Console.WriteLine($"Chatbot: {sentimentResponse} {response}".Trim());

                // Offer follow-up if applicable
                if (!string.IsNullOrEmpty(recognizedKeyword))
                {
                    OfferFollowUp(recognizedKeyword);
                }
            }
        }

        private void OfferFollowUp(string keyword)
        {
            switch (keyword)
            {
                case "password":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Would you like to know how to create a strong password?");
                    break;
                case "phishing":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Are you interested in learning about different types of phishing attacks?");
                    break;
                case "privacy":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Should we discuss how to protect your privacy on social media?");
                    break;
                case "scam":
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Want to hear about common online scams to watch out for?");
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Is there anything else I can help you with?");
                    break;
            }
            Console.ResetColor();
        }
    }
}