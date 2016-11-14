using System.Collections.Generic;

namespace BusinessApplication
{
    internal class ConfigurationManager
    {
        public static Dictionary<string, string> AppSettings { get; private set; }
        public static Dictionary<string, Connection> ConnectionStrings { get; private set; }
    }
}