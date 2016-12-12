using System;
using System.Collections.Generic;
using Syntax_Analyzer;
using TokenLibrary;
using Core.Library;
using System.IO;

namespace Semantics_Analyzer
{
    public class SemanticsInitializer : SyntaxAnalyzer
    {
        public class Tokens : TokensClass
        {
            public List<string> attribute = new List<string>();

            public void addAttribute(string attribute)
            {
                this.attribute.Add(attribute);
            }

            public List<string> getAttribute()
            {
                return this.attribute;
            }
        }

        public string error = "";
        public List<Tokens> tokens;
        //public List<Tokens> ID = new List<Tokens>();
        public List<Tokens> globalID = new List<Tokens>();

        //List of Identifiers
        public List<SemanticsConstants.Identifiers> identifiers = new List<SemanticsConstants.Identifiers>();
        public List<SemanticsConstants.Arrays> arrays = new List<SemanticsConstants.Arrays>();
        public List<SemanticsConstants.Index> indexes = new List<SemanticsConstants.Index>();
        public List<SemanticsConstants.Objects> objects = new List<SemanticsConstants.Objects>();
        public List<SemanticsConstants.Task> tasks = new List<SemanticsConstants.Task>();


        public SemanticsInitializer()
            : this(new List<Tokens>()) { }

        public SemanticsInitializer(List<Tokens> tokens)
        {
            this.tokens = tokens;
        }

        public string Start()
        {
            string tokenstream = "";
            string result = "Semantics Analyzer Failed...\n";
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
                if (error == "")
                    result = "Semantics Analyzer Succeeded...";
            }
            catch (ParserCreationException)
            {
                result = "Semantics Analyzer Halted due to Syntax Analyzer Error...";
            }
            catch (ParserLogException)
            {
                result = "Semantics Analyzer Halted due to Syntax Log Error...";
            }
            return result;
        }

        private Parser CreateParser(string input)
        {
            SyntaxParser parser = null;
            try
            {
                parser = new SyntaxParser(new StringReader(input), this);
                parser.Prepare();
            }
            catch (ParserCreationException e)
            {
                throw new Exception(e.Message);
            }
            return parser;
        }

        public Tokens GetTokens(int line, int column)
        {
            List<Tokens> t = new List<Tokens>();
            Tokens token = new Tokens();
            int endline = 0;
            foreach (var item in tokens)
            {
                if (item.getLines() == line)
                    t.Add(item);
            }
            foreach (var item in t)
            {
                endline += item.getTokens().Length + 1;
                if (column <= endline)
                {
                    token = item;
                    break;
                }
            }
            return token;
        }

        private void hasGlobalID(Tokens token)
        {
            Boolean isdeclared = false;
            if (globalID.Count != 0)
            {
                foreach (var item in globalID)
                {
                    if (token.getLexemes() == item.getLexemes())
                    {
                        error += "Semantics Error (Ln" + token.getLines() + "): " + token.getLexemes() + " is already declared.\n";
                        isdeclared = true;
                        break;
                    }
                }
            }

            if (!isdeclared)
            {
                globalID.Add(token);
            }
        }

        private string getDtype(string dtype)
        {
            switch (dtype)
            {
                case "INT":
                    dtype = "Int";
                    break;
                case "DOUBLE":
                    dtype = "Double";
                    break;
                case "CHAR":
                    dtype = "Char";
                    break;
                case "STRING":
                    dtype = "String";
                    break;
                case "BOOLEAN":
                    dtype = "Boolean";
                    break;
                case "NULL":
                    dtype = "Null";
                    break;

            }
            return dtype;
        }

        private SemanticsConstants.Identifiers setIdentifier
        (string identifier, string attrib, string dtype, string scope, string value, int lines, string token)
        {
            SemanticsConstants.Identifiers ID = new SemanticsConstants.Identifiers();
            ID.setAttrib(attrib);
            ID.setDtype(dtype);
            ID.setId(identifier);
            ID.setLines(lines);
            ID.setScope(scope);
            ID.setTokens(token);
            ID.setValue(value);
            return ID;
        }

    }
}
