using System;
using System.Collections.Generic;

namespace Syntax_Analyzer
{
    public class Initializer
    {
        public int invalid = 0;
        public string output = "";
        public Boolean InitializeSyntaxAnalyzer (List<string> tokens)
        {
            Analyzer SyntaxAnalyzer = new Analyzer();
            Boolean parsed = false;
            parsed = SyntaxAnalyzer.Start(tokens, "Start", false, 0);
            invalid = SyntaxAnalyzer.invalid;
            output = SyntaxAnalyzer.output;
            return parsed;
        }
    }
}
