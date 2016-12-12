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
            //Boolean isDone = false;
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

                List<int> codes = p.GetAllProductionCode();
                PredictSets ps = new PredictSets();
                string message = "Expected: ";
                errors.setColumn(e.GetError(0).Column);
                errors.setLines(e.GetError(0).Line);
                int ctr = GetSyntaxTable(codes);
                //isDone = true;

                if(codes.Count - 1 >= ctr)
                {
                    int code = codes[ctr];
                    message += ps.GetPredictSet(code);
                }
                else
                {
                    int code = codes[ctr - 1];
                    message += ps.GetPredictSet(code);
                }
                //if (p.GetLastProductionState() == "NULL")
                //{
                //    int code = p.GetLastProductionCode();
                //    message += ps.GetPredictSet(code);
                //}
                //else
                //{
                //    foreach (var item in e.GetError(0).Details)
                //    {
                //        message += item + ", ";
                //    }
                //}
                if (message == "Expected: ")
                {
                    string errormessage = e.GetError(0).ErrorMessage;
                    if(errormessage.Contains("unexpected token"))
                    {
                        errormessage = "";
                        foreach (var item in e.GetError(0).Details)
                        {
                            errormessage += item + ", "; 
                        }
                    }
                    if (errormessage == "unexpected end of file")
                        errormessage = "\".\"";

                    message += errormessage;
                }

                //if (message == "Expected: @, (, &&, ||, >=, <=, <, >, ==, !=, )")
                //{
                //    message = "Expected: ";
                //    foreach (var item in e.GetError(0).Details)
                //    {
                //        message += item + ", ";
                //    }
                //}

                message += ".";

                errors.setErrorMessage(message);
                errors.setType(e.GetError(0).Type.ToString());
                result = e.Message;
                
            }
            recursiveprod = p.GetRecursiveProduction();
            GetSyntaxTable(p.GetAllProductionCode());
            return result;
        }

        private int GetSyntaxTable(List<int> code)
        {
            SyntaxProductions prod = new SyntaxProductions();
            Boolean delete = true;
            Node node = null;
            string recprod = recursiveprod;
            int ctr = -1, count = 1, prodcode = 0;
            string currentparent = "";
            while (productions.Count != 0)
            {
                ctr++;
                prodcode = code[ctr];
                node = productions[count];


                if (node.GetId() == prodcode)
                {

                    string nodename = node.GetName().ToLower();
                    currentparent = node.GetParent().GetName();
                    currentparent = currentparent.ToLower();
                    currentparent = prod.GetProductionName(currentparent);
                    nodename = prod.GetProductionName(nodename);
                    delete = true;
                    if (currentparent.Contains("prod_"))
                    {
                        currentparent = "<" + currentparent.Substring(5) + ">";
                    }
                    if(nodename.Contains("prod_"))
                    {
                        nodename = "<" + nodename.Substring(5) + ">";
                    }

                    PRODUCTION.Add(currentparent);
                    SET.Add(nodename);
                }
                else
                {

                    string name = Enum.GetName(typeof(SyntaxConstants), prodcode);
                    name = name.ToLower();
                    name = prod.GetProductionName(name);
                    if (name.Contains("prod_"))
                    {
                        name = "<" + name.Substring(5) + ">";
                    }

                    if (PRODUCTION.Count != 1)
                    {
                        currentparent.ToLower();
                        currentparent = prod.GetProductionName(currentparent);
                        if (currentparent.Contains("prod_"))
                        {
                            currentparent = "<" + currentparent.Substring(5) + ">";
                        }
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
            return (ctr + 1);
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
