using System;
using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    /// <summary>
    /// Manages user-specific data by storing and retrieving key-value pairs.
    /// Useful for maintaining context or remembering user preferences during a conversation.
    /// </summary>
    public class UserMemory
    {
        // Dictionary to store user data as key-value pairs
        private readonly Dictionary<string, string> _memory = new Dictionary<string, string>();

        /// <summary>
        /// Stores a piece of information associated with a specific key.
        /// If the key already exists, its value will be updated.
        /// </summary>
        /// <param name="key">The identifier for the data to store.</param>
        /// <param name="value">The data value to associate with the key.</param>
        public void Remember(string key, string value)
        {
            // Store or update the value associated with the key
            _memory[key] = value;
        }

        /// <summary>
        /// Retrieves the stored value associated with a specific key.
        /// </summary>
        /// <param name="key">The identifier for the data to retrieve.</param>
        /// <returns>
        /// The value associated with the key if it exists; otherwise, null.
        /// </returns>
        public string Retrieve(string key)
        {
            // Check if the key exists in the dictionary
            if (_memory.ContainsKey(key))
            {
                // Return the associated value
                return _memory[key];
            }
            // Return null if the key is not found
            return null;
        }
    }
}