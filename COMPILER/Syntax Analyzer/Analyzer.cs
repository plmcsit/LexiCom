using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syntax_Analyzer
{
    public class Analyzer
    {
        Dictionary.Non_Terminals nt = new Dictionary.Non_Terminals();
        Dictionary.Maps map = new Dictionary.Maps();
        int ctr = 0;

        public Boolean Start(List<string> tokens, string nonterm){ return NonTerm(nt.S, tokens, nonterm); }
        public Boolean Program(List<string> tokens, string nonterm){ return NonTerm(nt.Program, tokens, nonterm); }
        public Boolean body(List<string> tokens, string nonterm){ return NonTerm_Mapper(map.body, tokens, nonterm); }
        public Boolean var(List<string> tokens, string nonterm) { return NonTerm(nt.var, tokens, nonterm); }
        public Boolean let(List<string> tokens, string nonterm) { return NonTerm(nt.let, tokens, nonterm); }
        public Boolean dtype(List<string> tokens, string nonterm) { return NonTerm_Mapper(map.dtype, tokens, nonterm); }
        
        public Boolean Process(string nonterm, List<string> token)
        {
            Boolean parsed = false;
            switch(nonterm)
            {
                case "Program":
                    parsed = Program(token, nonterm);
                    break;
                case "body":
                    parsed = body(token, nonterm);
                    break;
                case "var":
                    parsed = var(token, nonterm);
                    break;
                case "let":
                    parsed = let(token, nonterm);
                    break;
                case "dtype":
                    parsed = dtype(token, nonterm);
                    break;
            }
                return parsed;
        }

        public List<string> Mapper(string map)
        {
            List<string> dictionary = new List<string>();
            switch(map)
            {
                case "body1":
                    dictionary = nt.body1;
                    break;
                case "body2":
                    dictionary = nt.body2;
                    break;
                case "dtype1":
                    dictionary = nt.dtype1;
                    break;
                case "dtype2":
                    dictionary = nt.dtype2;
                    break;
                case "dtype3":
                    dictionary = nt.dtype3;
                    break;
                case "dtype4":
                    dictionary = nt.dtype4;
                    break;
                default:
                    dictionary = null;
                    break;
            }
            return dictionary;
        }

        public Boolean NonTerm(List<string> dictionary, List<string> tokens, string term)
        {
            Boolean parsed = false, end = false, ifprocess = false;
            string nonterm = "";
            int i = 0;
            while (!end)
            {
                if (i < dictionary.Count)
                {
                    if (dictionary[i].ElementAt(0) == '^')
                    {
                        nonterm = dictionary[i].Remove(0, 1);
                        ifprocess = Process(nonterm, tokens);
                        
                    }
                    else if (tokens[ctr] == dictionary[i])
                    {
                        ctr++;
                        if (tokens[ctr - 1] == dictionary[dictionary.Count - 1])
                        {
                            parsed = true;
                            end = true;
                        }
                    }
                    else
                    {
                        parsed = false;
                        end = true;
                    }
                    i++;
                }
                else
                {
                    end = true;
                }
            }

            return parsed;
        }

        public Boolean NonTerm_Mapper(List<string> mapping, List<string> tokens, string term)
        {
            Boolean parsed = false, end = false, found = false;
            List<string> dictionary = new List<string>();
            string nonterm = "";
            int i = 1;
            foreach (string map_nonterm in mapping)
            {
                dictionary = Mapper(map_nonterm);
                
                if (dictionary != null)
                {
                    if (dictionary.Count == 1)
                        i = 0;
                    if (dictionary[0].ElementAt(0) == '^')
                    {
                        nonterm = dictionary[0].Remove(0, 1);
                        found = Process(nonterm, tokens);
                        if (found) break;
                    }
                    else if (tokens[ctr] == dictionary[0])
                    {
                        found = true;
                        break;
                    }
                }
                else
                {
                    found = true;
                    parsed = true;
                    break;
                }
            }

            if (found == true && dictionary != null)
                while (!end)
                {
                    if (i < dictionary.Count)
                    {
                        if (dictionary[i].ElementAt(0) == '^')
                        {
                            nonterm = dictionary[i].Remove(0, 1);
                            parsed = Process(nonterm, tokens);
                            if (parsed)
                                i++;
                        }
                        else if (tokens[ctr] == dictionary[i])
                        {
                            ctr++;
                            if (tokens[ctr - 1] == dictionary[dictionary.Count - 1])
                            {
                                parsed = true;
                                end = true;
                            }
                        }
                        else
                        {
                            parsed = false;
                            end = true;
                        }
                        i++;
                    }
                    else
                    {
                        if (found == true)
                            parsed = true;
                        end = true;
                    }
                }

            return parsed;
        }


    }
}
