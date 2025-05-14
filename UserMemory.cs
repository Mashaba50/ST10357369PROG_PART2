using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;

namespace CybersecurityChatbotApp
{
    public class UserMemory
    {
        private readonly Dictionary<string, string> _memory = new Dictionary<string, string>();

        public void Remember(string key, string value)
        {
            _memory[key] = value;
        }

        public string Retrieve(string key)
        {
            return _memory.ContainsKey(key) ? _memory[key] : null;
        }
    }
}
