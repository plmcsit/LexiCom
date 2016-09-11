using System;
using System.Collections.Generic;
using System.Linq;

namespace Syntax_Analyzer
{
    public class Analyzer
    {
        Dictionary.Non_Terminals nt = new Dictionary.Non_Terminals();
        Dictionary.Maps map = new Dictionary.Maps();
        Boolean ismapper = false, watch = false, valid = true;
        int ctr = 0;
        public int invalid = 0;
        public string output = "";
        string tail = "";

        //NON TERMINAL FUNCTIONS
        public Boolean Start(List<string> tokens, string nonterm, Boolean ismap, int tempctr) { return NonTerm(nt.S, tokens, nonterm, ismap, tempctr); }
        public Boolean Program(List<string> tokens, string nonterm, Boolean ismap, int tempctr) { return NonTerm(nt.Program, tokens, nonterm, ismap, tempctr); }
        public Boolean body(List<string> tokens, string nonterm, Boolean ismap, int tempctr) { return NonTerm_Mapper(map.body, tokens, nonterm, true, tempctr); }
        public Boolean var(List<string> tokens, string nonterm, Boolean ismap, int tempctr) { return NonTerm(nt.var, tokens, nonterm, ismap, tempctr); }
        public Boolean let(List<string> tokens, string nonterm, Boolean ismap, int tempctr) { return NonTerm(nt.let, tokens, nonterm, ismap, tempctr); }
        public Boolean dtype(List<string> tokens, string nonterm, Boolean ismap, int tempctr) { return NonTerm_Mapper(map.dtype, tokens, nonterm, true, tempctr); }
        

        //STRUCTURED FUNCTIONS
        public Boolean Process(string nonterm, List<string> token, Boolean ismap, int tempctr)
        {
            Boolean parsed = false;
            switch(nonterm)
            {
                case "Program":
                    parsed = Program(token, nonterm, ismap, tempctr);
                    break;
                case "body":
                    parsed = body(token, nonterm, ismap, tempctr);
                    break;
                case "var":
                    parsed = var(token, nonterm, ismap, tempctr);
                    break;
                case "let":
                    parsed = let(token, nonterm, ismap, tempctr);
                    break;
                case "dtype":
                    parsed = dtype(token, nonterm, ismap, tempctr);
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
                case "NULL":
                    dictionary = nt.NULL;
                    break;
            }
            return dictionary;
        }

        public Boolean NonTerm(List<string> dictionary, List<string> tokens, string nonterm, Boolean ismap, int tempctr)
        {
            string dict = "";
            foreach (var item in dictionary)
            {
                dict += item + " ";
            }
            output += "<"+ nonterm + "> " + "{ " + dict + " } -> ";
            Boolean parsed = false, end = false, found = false;
            string localnonterm = "", token_string = "", dictionary_string = "";
            int map_ctr = tempctr, map_i = 0;
            int i = 0;

            foreach (string token in dictionary)
            {
                if (token.ElementAt(0) != '^')
                {
                    if (ismap)
                    {
                        if (map_i + 1 < dictionary.Count)
                        {
                            if (tokens.Count > map_ctr)
                            {
                                dictionary_string += token;
                                token_string += tokens[map_ctr];
                                map_ctr++;
                            }
                            map_i++;
                        }
                        else
                        {
                            if (tokens.Count > map_ctr)
                            {
                                dictionary_string += token;
                                token_string += tokens[map_ctr];
                            }
                            end = true;
                        }
                    }
                    else
                    {
                        if (i + 1 < dictionary.Count)
                        {
                            if (tokens.Count > ctr)
                            {
                                dictionary_string += token;
                                token_string += tokens[ctr];
                                ctr++;
                            }
                            i++;
                        }
                        else
                        {
                            if (tokens.Count > ctr)
                            {
                                dictionary_string += token;
                                token_string += tokens[ctr];
                            }
                            end = true;
                        }

                    }
                }
                else
                {
                    if (ismap)
                    {
                        if (map_i + 1 < dictionary.Count)
                        {
                            localnonterm = token.Remove(0, 1);
                            found = Process(localnonterm, tokens, ismap, map_ctr);
                            if (found)
                            {
                                dictionary_string += token;
                                token_string += "^" + localnonterm;
                                map_ctr++;
                            }
                            else
                            {
                                dictionary_string += token;
                                parsed = found;
                                end = true;
                            }
                            map_i++;
                        }
                    }
                    else
                    {
                        if (i + 1 < dictionary.Count)
                        {
                            localnonterm = token.Remove(0, 1);
                            found = Process(localnonterm, tokens, ismap, ctr);
                            if (found)
                            {
                                dictionary_string += token;
                                token_string += "^" + localnonterm;
                                ctr++;
                            }
                            else
                            {
                                dictionary_string += token;
                                parsed = found;
                                end = true;
                            }
                            i++;
                        }
                    }
                }

                if (end)
                {
                    if (dictionary_string == token_string)
                    {
                        parsed = true;
                        if (ismap)
                        {
                            ctr = map_ctr;
                            i = map_i;
                            ismap = false;
                        }
                    }
                    break;
                }
            }
            return parsed;
        }

        public Boolean NonTerm_Mapper(List<string> mapping, List<string> tokens, string nonterm, Boolean ismap, int tempctr)
        {
            Boolean parsed = false, end = false;
            List<string> dictionary = new List<string>();
 
            foreach (string map_nonterm in mapping)
            {
                Boolean found = false;
                string localnonterm = "", token_string = "", dictionary_string = "";
                int i = 0;
                int map_ctr = tempctr, map_i = 0;
                dictionary = Mapper(map_nonterm);
                if (parsed) break;
                if (dictionary.Count != 0)
                {
                    foreach (string token in dictionary)
                    {
                        if (token.ElementAt(0) != '^')
                        {
                            if (map_i + 1 < dictionary.Count)
                            {
                                if (tokens.Count > map_ctr)
                                {
                                    dictionary_string += token;
                                    token_string += tokens[map_ctr];
                                    map_ctr++;
                                }
                                map_i++;
                            }
                            else
                            {
                                if (tokens.Count > map_ctr)
                                {
                                    dictionary_string += token;
                                    token_string += tokens[map_ctr];
                                }
                                end = true;
                            }

                        }
                        else
                        {
                            if (map_i + 1 < dictionary.Count)
                            {
                                localnonterm = token.Remove(0, 1);
                                found = Process(localnonterm, tokens, true, map_ctr);
                                if (found)
                                {
                                    dictionary_string += token;
                                    token_string += "^" + localnonterm;
                                    map_ctr++;
                                }
                                else
                                {
                                    dictionary_string += token;
                                    parsed = found;
                                    end = true;
                                }
                                map_i++;
                            }
                        }

                        if (end)
                        {
                            if (dictionary_string == token_string)
                            {
                                ctr = map_ctr;
                                i = map_i;
                                parsed = true;
                            }
                            break;
                        }
                    }
                }
                else
                {
                    parsed = true;
                    break;
                }
            }
            
            return parsed;
        }
    }
}