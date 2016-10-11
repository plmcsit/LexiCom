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
        List<Node> productions = new List<Node>();
        public List<string> SET = new List<string>();
        public List<string> PRODUCTION = new List<string>();

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
                    productions.Add(node);
                }
                else
                {
                    production += "Enter: <" + name + ">\n";
                    productions.Add(node);
                }
                prevparent.Add(currparent);
                currparent = node;
            }
            else
            {
                node.SetParent(currparent);
                productions.Add(node);
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
               
                string message = "Expected: ";
                errors.setColumn(e.GetError(0).Column);
                errors.setLines(e.GetError(0).Line);


                if (p.GetLastProductionState() == "NULL")
                {
                    PredictSets ps = new PredictSets();
                    int code = p.GetLastProductionCode();
                    message += ps.GetPredictSet(code);
                }
                else
                {
                    foreach (var item in e.GetError(0).Details)
                    {
                        message += item + ", ";
                    }
                }

                //foreach (var item in e.GetError(0).Details)
                //{
                //    message += item + ", ";
                //}

                if (message == "Expected: @, (, &&, ||, >=, <=, <, >, ==, !=, )")
                {
                    message = "Expected: ";
                    foreach (var item in e.GetError(0).Details)
                    {
                        message += item + ", ";
                    }
                }

                message += ".";

                errors.setErrorMessage(message);
                errors.setType(e.GetError(0).Type.ToString());
                result = e.Message;
                
            }
            recursiveprod = p.GetRecursiveProduction();
            GetSyntaxTable(p.GetAllProductionCode(), p.GetAllProductionState());
            return result;
        }

        private void GetSyntaxTable(List<int> code, List<string> state)
        {
            Node node = null;
            Boolean delete = true;
            string prodstate = "";
            string recprod = recursiveprod;
            int ctr = -1, count = 1, prodcode = 0;
            string currentparent = "";
            while (productions.Count != 0)
            {
                ctr++;
                prodcode = code[ctr];
                prodstate = state[ctr];
                node = productions[count];


                if (node.GetId() == prodcode)
                {
                    delete = true;
                    currentparent = node.GetParent().GetName();
                    PRODUCTION.Add(currentparent);
                    SET.Add(node.GetName());
                }
                else
                {

                    string name = Enum.GetName(typeof(SyntaxConstants), prodcode);
                    if (PRODUCTION.Count != 1)
                    {
                        PRODUCTION.Add(currentparent);
                        SET.Add(name);
                        PRODUCTION.Add(name);
                        SET.Add("λ");
                        delete = false;
                    }
                    else
                    {
                        PRODUCTION.Add("<program>");
                        SET.Add(name);
                        PRODUCTION.Add(name);
                        SET.Add("λ");
                        delete = false;
                    }
                }

                if (count != 1 && delete)
                {
                    productions.RemoveAt(0);
                }
                else if(delete)
                {
                    productions.RemoveAt(0);
                    productions.RemoveAt(0);
                    count = 0;
                }


            }
            
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
