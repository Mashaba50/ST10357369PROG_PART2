using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace CybersecurityChatbotApp
{
    public static class Chatbot
    {
        /// <summary>
        /// Displays ASCII art along with some cybersecurity tips.
        /// </summary>
        public static void DisplayAsciiArt()
        {
            // Set console text color to magenta for the ASCII art
            Console.ForegroundColor = ConsoleColor.Magenta;
            // Print ASCII art and tips about cybersecurity
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
       |  6. Keep software     |    |     regularly        |    |  Be cautious       |  
       |     updated           |    |  7. Enable 2FA      |    |                    |  
       '--------------------'    '--------------------'    '--------------------'  
");
            // Reset console color to default
            Console.ResetColor();
        }

        /// <summary>
        /// Greets the user, asks for their name, and stores it in memory.
        /// </summary>
        /// <param name="memory">UserMemory object to store user info.</param>
        public static void GreetUser(UserMemory memory)
        {
            // Set color to white for the question
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Hi there! What's your name? ");
            // Change color to yellow for user input
            Console.ForegroundColor = ConsoleColor.Yellow;
            string name = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                // Store user's name in memory
                memory.Remember("userName", name);
                // Greet the user
                TypeWriteLine($"\nWelcome, {name}! I'm your Cybersecurity Assistant.", ConsoleColor.Green);
            }
            else
            {
                // If no name entered, greet generally
                TypeWriteLine("\nWelcome! I'm your Cybersecurity Assistant.", ConsoleColor.Green);
            }

            Console.ResetColor();

            // Get a random greeting message and display it
            var greeting = GetRandomResponse("greeting");
            TypeWriteLine(greeting, ConsoleColor.Cyan);
        }

        /// <summary>
        /// Handles user input and generates responses.
        /// </summary>
        public static void GetUserInputAndRespond()
        {
            // Set color for prompt
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("User: ");
            // Read user input
            string userInput = Console.ReadLine()?.Trim();
            // Change color for displaying user input
            Console.ForegroundColor = ConsoleColor.Yellow;
            // Display the user's input with label
            Console.WriteLine($"User: {userInput}");

            // Generate a random response for general inquiry
            string response = GetRandomResponse("general_inquiry");
            // Set color for chatbot response
            Console.ForegroundColor = ConsoleColor.Cyan;
            // Display chatbot response with label
            Console.WriteLine($"Chatbot: {response}");
            Console.ResetColor();
        }

        /// <summary>
        /// Types out text character-by-character with a delay for effect.
        /// </summary>
        /// <param name="text">Text to display.</param>
        /// <param name="color">Console color for the text.</param>
        /// <param name="delay">Delay in milliseconds between characters.</param>
        public static void TypeWriteLine(string text, ConsoleColor color, int delay = 35)
        {
            // Set text color
            Console.ForegroundColor = color;
            // Iterate through each character in the text
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(delay); // Pause between characters for effect
            }
            Console.WriteLine(); // Move to the next line
            Console.ResetColor(); // Reset to default color
        }

        /// <summary>
        /// Retrieves a random response from predefined sets based on listName.
        /// </summary>
        /// <param name="listName">Key for the desired response list.</param>
        /// <returns>A random response string.</returns>
        public static string GetRandomResponse(string listName)
        {
            // Dictionary of response lists
            var responses = new Dictionary<string, List<string>>()
            {
                ["greeting"] = new List<string> { "Hello there!", "Hi!", "Greetings!", "Welcome!" },
                ["farewell"] = new List<string> { "Goodbye!", "Farewell!", "See you later!", "Stay safe!" },
                ["positive_acknowledgement"] = new List<string> { "Great!", "Excellent!", "Good to hear!", "Understood." },
                ["negative_acknowledgement"] = new List<string> { "Oh, I'm sorry to hear that.", "That's unfortunate.", "I understand." },
                ["general_inquiry"] = new List<string> { "That's an interesting question.", "Let me think about that.", "Could you tell me more?" }
            };

            // Check if the requested list exists
            if (responses.ContainsKey(listName))
            {
                var list = responses[listName];
                var rand = new Random(); // Random generator
                // Return a random response from the list
                return list[rand.Next(list.Count)];
            }
            return ""; // Return empty string if list not found
        }
    }
}