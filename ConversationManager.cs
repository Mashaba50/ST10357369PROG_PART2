using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CybersecurityChatbotApp
{
    /// <summary>
    /// Manages the flow of conversation between the user and the chatbot.
    /// Handles user input, keyword recognition, sentiment analysis,
    /// response generation, and follow-up prompts.
    /// </summary>
    public class ConversationManager
    {
        // Dependencies for processing user input and generating responses
        private readonly KeywordRecognizer _keywordRecognizer;   // Recognizes keywords in user input
        private readonly ResponseGenerator _responseGenerator;   // Generates appropriate chatbot responses
        private readonly SentimentAnalyser _sentimentAnalyser;   // Analyzes sentiment of user input
        private readonly UserMemory _userMemory;                 // Stores user-related information

        /// <summary>
        /// Constructor to initialize dependencies.
        /// </summary>
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

        /// <summary>
        /// Main loop to handle user queries continuously until the user exits.
        /// Recognizes keywords, analyzes sentiment, generates responses,
        /// and offers follow-up questions.
        /// </summary>
        public void HandleUserQueries()
        {
            while (true)
            {
                // Set prompt color to white
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\nAsk a cybersecurity question (or type 'exit'): ");
                // Read user input, convert to lowercase, and trim whitespace
                string input = Console.ReadLine()?.ToLower().Trim();

                // Validate input
                if (string.IsNullOrWhiteSpace(input))
                {
                    // Prompt user to enter a valid question if input is empty
                    Chatbot.TypeWriteLine("Please enter a valid question.", ConsoleColor.Red);
                    continue; // Restart loop
                }

                // Exit condition
                if (input == "exit")
                {
                    // Get a farewell message
                    var farewell = Chatbot.GetRandomResponse("farewell");
                    // Display farewell
                    Chatbot.TypeWriteLine(farewell, ConsoleColor.Green);
                    break; // Exit loop
                }

                // Recognize keywords in user input
                string recognizedKeyword = _keywordRecognizer.RecognizeKeyword(input);

                // Analyze sentiment of user input
                string sentimentResponse = _sentimentAnalyser.AnalyzeSentiment(input);

                // Generate a response based on input, recognized keyword, and user memory
                string response = _responseGenerator.GenerateResponse(input, recognizedKeyword, _userMemory);

                // Print the user's input with quotes for clarity
                Console.WriteLine($"User: \"{input}\"");
                // Print chatbot's sentiment response and generated reply
                Console.WriteLine($"Chatbot: {sentimentResponse} {response}".Trim());

                // If a keyword was recognized, offer a relevant follow-up
                if (!string.IsNullOrEmpty(recognizedKeyword))
                {
                    OfferFollowUp(recognizedKeyword);
                }
            }
        }

        /// <summary>
        /// Offers a follow-up question or prompt based on the recognized keyword.
        /// Changes text color to dark cyan for emphasis.
        /// </summary>
        /// <param name="keyword">The keyword recognized from user input.</param>
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
            // Reset console color to default
            Console.ResetColor();
        }
    }
}