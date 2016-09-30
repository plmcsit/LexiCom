using System;
using System.IO;
using System.Collections.Generic;
using PerCederberg.Grammatica.Runtime;

using TokenLibrary;

namespace Syntax_Analyzer
{
    public class SyntaxInitializer
    {

        public string Start(List<TokensClass> tokens)
        {
            string tokenstream = "";
            string result;
            int line = 1;
            int linejump = 0;
            foreach (var t in tokens)
            {
                if (t.getLines() != line)
                {
                    linejump = t.getLines() - line;
                    line = t.getLines();
                    for (int i = 0; i < linejump; i++)
                    {
                        tokenstream += "\n";
                    }
                }
                tokenstream += t.getTokens() + " ";
            }
            tokenstream = tokenstream.TrimEnd();

            Parser p;
            p = CreateParser(tokenstream);

            try
            {
                p.Parse();
                Fail("parsing succeeded");
                result = "Syntax Analyzer Succeeded...";
            }
            catch (ParserCreationException e)
            {
                Fail(e.Message);
                result = e.Message;
            }
            catch (ParserLogException e)
            {
                result = e.Message;
            }
            return result;
        }

        private Parser CreateParser(string input)
        {
            Parser parser = null;
            SyntaxAnalyzer analyzer = null;
            try
            {
                parser = new SyntaxParser(new StringReader(input), analyzer);
                parser.Prepare();
            }
            catch (ParserCreationException e)
            {
                Fail(e.Message);
            }
            return parser;
        }

        protected void Fail(string message)
        {
            if (message != "parsing succeeded")
                throw new Exception(message);
        }
    }
}
