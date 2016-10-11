using System;
using System.IO;
using System.Collections.Generic;
using Core.Library;

using TokenLibrary;

namespace Syntax_Analyzer
{
    public class SyntaxInitializer : SyntaxAnalyzer
    {
        public string production = "";
        public string recursiveprod = "";
        Node currparent = null;
        List<Node> prevparent = new List<Node>();
        public override void Enter(Node node)
        {
            string name = node.GetName();
            if (name.Contains("Prod_"))
            {
                node.SetParent(currparent);
                name = name.Substring(5);

                if(currparent != null)
                {
                    production += "Enter: <" + name + "> Parent: " + currparent.GetName() + "\n";
                }
                else
                {
                    production += "Enter: <" + name + ">\n";
                }
                prevparent.Add(currparent);
                currparent = node;
            }
            else
            {
                node.SetParent(currparent);
                production += "Enter: " + name + " Parent: " + currparent.GetName() + "\n";
            }
            
        }
        public override Node Exit(Node node)
        {
            if(currparent == node)
            {
                currparent = prevparent[prevparent.Count-1];
                prevparent.RemoveAt(prevparent.Count - 1);
            }
            return node;
        }

        public override Node Analyze(Node node)
        {
            return base.Analyze(node);
        }

        public override Node Analyze(Node node, ParserLogException log)
        {
            return base.Analyze(node, log);
        }

        public ErrorClass errors = new ErrorClass();
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
                Node parse = p.Parse();
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
               
                string message = "Expected ";
                errors.setColumn(e.GetError(0).Column);
                errors.setLines(e.GetError(0).Line);
                if (e.GetError(0).Details != null && e.GetError(0).Details.Count != 1)
                {
                    message = "Expected one of ";
                }
                foreach (var item in e.GetError(0).Details)
                {
                    message += item + ", ";     
                }
                message += ".";

                

                errors.setErrorMessage(message);
                errors.setType(e.GetError(0).Type.ToString());
                result = e.Message;
                int code = p.GetLastProductionCode();
            }
            recursiveprod = p.GetRecursiveProduction();
            return result;
        }

        private Parser CreateParser(string input)
        {
            Parser parser = null;
            try
            {
                parser = new SyntaxParser(new StringReader(input), this);
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
