using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax_Analyzer
{
    public class Initializer
    {
        public Boolean InitializeSyntaxAnalyzer (List<string> tokens)
        {
            Analyzer SyntaxAnalyzer = new Analyzer();
            Boolean parsed = false;
            parsed = SyntaxAnalyzer.Start(tokens,"");
            return parsed;

        }
    }
}
