using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CybersecurityChatbotApp
{
    public static class Chatbot
    {
        public static void DisplayAsciiArt()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(@"
   / ____|                        | |                   | |               
 | |     _ __ __ _ _ __ ___  ___| |_ _ __ __ _ _ __ | |_ ___ _ __ ___  
 | |    | '__/ _` | '__/ _ \/ __| __| '__/ _` | '_ \| __/ _ \ '_ ` _ \ 
 | |____| | | (_| | | |  __/ (__| |_| | | (_| | | | | ||  __/ | | | | |
  \_____|_|  \__,_|_|  \___|\___|\__|_|  \__,_|_| |_|\__\___|_| |_| |_|
                                                                        
             ___                                 _     _                     
            / _ \                               | |   | |                    
           / /_\ \_ __ __ _ _ __ ___   ___ _ __| |__ | |_ ___  _ __ ___ ___  
           |  _  | '__/ _` | '_ ` _ \ / _ \ '__| '_ \| __/ _ \| '__/ __/ _ \ 
           | | | | | | (_| | | | | | |  __/ |  | | | | || (_) | | | (_|  __/ 
           \_| |_/_|  \__,_|_| |_| |_|\___|_|  |_| |_|\__\___|_|  \___\___| 
                                                                             
       .--------------------.    .--------------------.    .--------------------.  
       |  1. Don’t click on   |    |  2. Use strong      |    |  3. Browse safely  |  
       |     unknown links    |    |     passwords        |    | (HTTPS, VPN)      |  
       |  4. Verify senders    |    |  5. Change passwords |    |  Avoid public Wi-Fi|  
       |  6. Keep software     |    | regularly            |    |  Be cautious       |  
       |     updated           |    |  7. Enable 2FA      |    |                    |  
       '--------------------'    '--------------------'    '--------------------'  
");
        
            Console.ResetColor();
        }

        public static void GreetUser(UserMemory memory)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hi there! What's your name? ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            string name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                memory.Remember("userName", name);
                TypeWriteLine($"\nWelcome, {name}! I'm your Cybersecurity Assistant.", ConsoleColor.Green);
            }
            else
            {
                TypeWriteLine("\nWelcome! I'm your Cybersecurity Assistant.", ConsoleColor.Green);
            }

            Console.ResetColor();
            var greeting = GetRandomResponse("greeting");
            TypeWriteLine(greeting, ConsoleColor.Cyan);
        }

        public static void GetUserInputAndRespond()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            string userInput = Console.ReadLine()?.Trim();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"User: {userInput}");

           
            string response = GetRandomResponse("general_inquiry");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Chatbot: {response}");
            Console.ResetColor();
        }

        public static void TypeWriteLine(string text, ConsoleColor color, int delay = 35)
        {
            Console.ForegroundColor = color;
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay);
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        public static string GetRandomResponse(string listName)
        {
            var responses = new Dictionary<string, List<string>>()
            {
                ["greeting"] = new List<string> { "Hello there!", "Hi!", "Greetings!", "Welcome!" },
                ["farewell"] = new List<string> { "Goodbye!", "Farewell!", "See you later!", "Stay safe!" },
                ["positive_acknowledgement"] = new List<string> { "Great!", "Excellent!", "Good to hear!", "Understood." },
                ["negative_acknowledgement"] = new List<string> { "Oh, I'm sorry to hear that.", "That's unfortunate.", "I understand." },
                ["general_inquiry"] = new List<string> { "That's an interesting question.", "Let me think about that.", "Could you tell me more?" }
            };

            if (responses.ContainsKey(listName))
            {
                var list = responses[listName];
                var rand = new Random();
                return list[rand.Next(list.Count)];
            }
            return "";
        }
    }
}
