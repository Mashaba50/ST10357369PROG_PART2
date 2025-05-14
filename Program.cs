using System;

namespace CybersecurityChatbotApp
{
    /// <summary>
    /// Entry point of the Cybersecurity Awareness Chatbot application.
    /// Sets up dependencies, displays welcome art, and starts the conversation loop.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Set the console window title for better user experience
            Console.Title = "Cybersecurity Awareness Chatbot";

            // Initialize user memory to store user-specific data during the session
            var userMemory = new UserMemory();

            // Initialize response generator for creating chatbot responses
            var responseGenerator = new ResponseGenerator();

            // Initialize keyword recognizer with the response generator (if needed for future features)
            var keywordRecognizer = new KeywordRecognizer(responseGenerator);

            // Initialize sentiment analyser to detect user's emotional tone or sentiment
            var sentimentAnalyser = new SentimentAnalyser();

            // Create the conversation manager, passing all dependencies
            var conversationManager = new ConversationManager(
                keywordRecognizer,
                responseGenerator,
                sentimentAnalyser,
                userMemory
            );

            // Display ASCII art or logo for the chatbot to welcome users
            Chatbot.DisplayAsciiArt();

            // Greet the user with a friendly message
            Chatbot.GreetUser(userMemory);

            // Enter the main conversation loop to handle user queries
            conversationManager.HandleUserQueries();

            // After user exits, display a farewell message in green color
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using the Cybersecurity Chatbot. Stay safe online!");
            // Reset console color to default
            Console.ResetColor();
        }
    }
}