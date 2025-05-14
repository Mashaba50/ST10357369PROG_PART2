using System;

namespace CybersecurityChatbotApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Cybersecurity Awareness Chatbot";

            
            var userMemory = new UserMemory();
            var responseGenerator = new ResponseGenerator();
            var keywordRecognizer = new KeywordRecognizer(responseGenerator);
            var sentimentAnalyser = new SentimentAnalyser();
            var conversationManager = new ConversationManager(keywordRecognizer, responseGenerator, sentimentAnalyser, userMemory);

            Chatbot.DisplayAsciiArt();

            
            Chatbot.GreetUser(userMemory);

            
            conversationManager.HandleUserQueries();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Thank you for using the Cybersecurity Chatbot. Stay safe online!");
            Console.ResetColor();
        }
    }
}
