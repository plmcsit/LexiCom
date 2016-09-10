using System.Collections.Generic;

namespace Syntax_Analyzer
{
    public class Dictionary
    {
        public class Non_Terminals
        {
            public List<string> S = new List<string>
            { "^Program", "#" };
            public List<string> Program = new List<string>
            { "Task", "Lead", ":", "Start", "^body", "End", "." };
            public List<string> body1 = new List<string>
            {"^var", "^body"};
            public List<string> body2 = new List<string>
            { "^let", "^body" };
            public List<string> var = new List<string>
            { "Var", "id", "as", "^dtype", "." };
            public List<string> let = new List<string>
            { "Let", "id", "as", "^dtype", "." };
            public List<string> dtype1 = new List<string>
            { "Int" };
            public List<string> dtype2 = new List<string>
            { "Double" };
            public List<string> dtype3 = new List<string>
            { "Char" };
            public List<string> dtype4 = new List<string>
            { "String" };

            public List<string> NULL = new List<string>();
        }
         
        public class Maps
        {
            public List<string> body = new List<string>
            { "body1", "body2", "NULL" };

            public List<string> dtype = new List<string>
            { "dtype1", "dtype2", "dtype3", "dtype4" };

        }

        
    }
}
