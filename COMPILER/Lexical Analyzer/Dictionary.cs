using System.Collections.Generic;

namespace Lexical_Analyzer
{
    public class Dictionary
    {
        //RESERVED WORDS
        public class ReservedWords
        { 
            public List<string> rw_1 = new List<string> { "For", "If", "Until" };
            public List<string> rw_2 = new List<string> { "No", "Yes" };
            public List<string> rw_3 = new List<string> { "Boolean", "Char", "Double", "Int", "String" };
            public List<string> rw_4 = new List<string> { "PS" };
            public List<string> rw_5 = new List<string> { "Object" };
            public List<string> rw_6 = new List<string> { "Otherwise" };
            public List<string> rw_space = new List<string> {"as", "is", "Array", "Clear", "Default", "Let", "Null",
                                                              "of", "by", "Read", "Response", "Say", "Task", "Var" };
            public List<string> rw_period = new List<string> { "Clear", "End", "EndIf", "Skip", "Stop" };
            public List<string> rw_colon = new List<string> { "Lead" };
            public List<string> rw_newline = new List<string> { "Do", "Start"};
        }
        public class ReservedWordsDelims
        {
            public List<char> delim_1 = new List<char> { ' ', '(' };
            public List<char> delim_2 = new List<char> { '.', '&', '|', ')', '=' };
            public List<char> delim_3 = new List<char> { ' ', '.' };
            public List<char> delim_4 = new List<char> { ' ', '{' };
            public List<char> delim_5 = new List<char> { ' ', '@' };
            public List<char> delim_6 = new List<char> { ' ', '\n' };
            public List<char> delim_space = new List<char> { ' ' };
            public List<char> delim_period = new List<char> { '.' };
            public List<char> delim_colon = new List<char> { ':' };
            public List<char> delim_newline = new List<char> { '\n' };
            public List<char> delim_end = new List<char> { '.', ' ', '\n', '\t','(' , ':', ',', '&', '\'', '[', ']', '?', '#', '$', '%', '\\',
                                                           '|', '=', '+', '-', '*', '/', ')', '"', ';', '<', '>', '!', '@', '^', '~', '`', '_'};
            public List<char> delim_digit = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
        public ReservedWordsDelims AddRange(ReservedWordsDelims rwd)
        {
            ReservedWordsDelims rw = new ReservedWordsDelims();
            rwd.delim_end.AddRange(rw.delim_digit);
            rwd.delim_end.Add('0');
            return rwd;
        }


        //RESERVED SYMBOLS
        public class ReservedSymbols
        {
            public List<string> rs_digit = new List<string> { "[" };
            public List<string> rs_caplet = new List<string> { "@" };
            public List<string> rs_newline = new List<string> { ":" };
            public List<string> rs_period = new List<string> { "}", "]" };
            public List<string> rs_6 = new List<string> { "." };
            public List<string> rs_7 = new List<string> { "&&", "||" };
            public List<string> rs_8 = new List<string> { "," };
            public List<string> rs_9 = new List<string> { ";" };
            public List<string> rs_10 = new List<string> { "+", "-", "*", "/", "!", "=", "==", "!=", "<", "<=", ">", ">=", "%=" };
            public List<string> rs_11 = new List<string> { "," };
            public List<string> rs_13 = new List<string> { "++", "--" };
            public List<string> rs_14 = new List<string> { "(", "+=", "-=", "*=", "/=" };
            public List<string> rs_15 = new List<string> { ")" };
            public List<string> rs_done = new List<string> { "#" };
        }
        public class ReservedSymbolsDelims
        {
            public List<char> delim_digit = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            public List<char> delim_caplet = new List<char> { 'A','B','C','D','E','F','G','H','I','J','K','L','M',
                                                       'N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            public List<char> delim_newline = new List<char> { '\n' };
            public List<char> delim_period = new List<char> { '.' };
            public List<char> delim_6 = new List<char> { ' ', '\n', '#' };
            public List<char> delim_7 = new List<char>();
            public List<char> delim_8 = new List<char> { ' ', '"' };
            public List<char> delim_9 = new List<char> { ' ', '"', '\'', '0' };
            public List<char> delim_10 = new List<char> { '0' };
            public List<char> delim_11 = new List<char> { ' ', ';', ',', ')' };
            public List<char> delim_13 = new List<char> { '.' };
            public List<char> delim_14 = new List<char>();
            public List<char> delim_15 = new List<char> { '\n', '+', '-', '*', '/' };
            public List<char> delim_end = new List<char> { '.', ' ', '\n', '\t','(' , ':', ',', '\'', '[', ']', '?', '#', '$', '%', '\\',
                                                            ')', '"', ';', '@', '^', '~', '`', '_', '!', '<', '>','*', '/'};
        }
        public ReservedSymbolsDelims AddRange(ReservedSymbolsDelims rsd)
        {
            ReservedWordsDelims rwd = new ReservedWordsDelims();
            Delims d = new Delims();
            rsd.delim_7.AddRange(rwd.delim_1);
            rsd.delim_7.AddRange(rsd.delim_caplet);
            rsd.delim_14.AddRange(rsd.delim_caplet);
            rsd.delim_14.AddRange(rsd.delim_digit);
            rsd.delim_9.AddRange(rsd.delim_14);
            rsd.delim_10.AddRange(rsd.delim_7);
            rsd.delim_10.AddRange(rsd.delim_digit);
            rsd.delim_13.AddRange(rsd.delim_caplet);
            rsd.delim_end.AddRange(rsd.delim_caplet);
            rsd.delim_end.AddRange(d.delim_lowlet);
            rsd.delim_end.AddRange(rsd.delim_digit);
            rsd.delim_end.Add('0');
            return rsd;
        }


        //LITERALS
        public class Literals
        {
            public List<char> nums = new List<char> { '~', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
        public class LiteralsDelims
        {
            public List<char> delim_txt = new List<char> { ' ', ';', ',', ')', '.' };
            public List<char> delim_num = new List<char> { '+', '-', '*', '/', ',', '.', ' ', '&', '|', ')' };
        }

        //Identifier
        public class Identifier
        {
            public List<char> delim_digit = new List<char> { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
            public List<char> delim_lowlet = new List<char> { 'a','b','c','d','e','f','g','h','i','j','k','l','m',
                                                       'n','o','p','q','r','s','t','u','v','w','x','y','z' };
            public List<char> delim_caplet = new List<char> {'A','B','C','D','E','F','G','H','I','J','K','L','M',
                                                      'N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            public List<char> delim_undscr = new List<char> { '_' };
            public List<char> id = new List<char>();
        }
        public class IdentifierDelims
        {
            public List<char> delim_end = new List<char> { '.', ' ', '\n', '=', '\t','(' , ':', ',', '\'', '[', ']', '?', '#', '$', '%', '\\',
                                                           ')', '"', ';', '@', '^', '~', '`', '_', '!', '<', '>','*', '/'};
        }

        //OTHER DELIMITERS
        public class Delims
        {
            public List<char> delim_zero = new List<char> { '0' };
            public List<char> delim_lowlet = new List<char> { 'a','b','c','d','e','f','g','h','i','j','k','l','m',
                                                       'n','o','p','q','r','s','t','u','v','w','x','y','z' };
            public List<char> delim_mathOp = new List<char> { '+', '-', '*', '/' };
            public List<char> delim_undscr = new List<char> { '_' };
            public List<char> delim_identifier = new List<char>();
            public List<char> delim_lit = new List<char>();
            public List<char> delim_12 = new List<char>();
            public List<char> delim_16 = new List<char> { ' ' };
        }
        public Delims AddRange(Delims d)
        {
            ReservedSymbolsDelims rsd = new ReservedSymbolsDelims();
            ReservedWordsDelims rwd = new ReservedWordsDelims();
            d.delim_identifier.AddRange(rsd.delim_caplet);
            d.delim_identifier.AddRange(d.delim_lowlet);
            d.delim_identifier.AddRange(rsd.delim_digit);
            d.delim_identifier.Add('0');
            d.delim_identifier.Add('_');
            d.delim_lit.AddRange(rsd.delim_digit);
            d.delim_lit.Add('0');
            d.delim_12.AddRange(rwd.delim_2);
            d.delim_12.AddRange(d.delim_mathOp);
            d.delim_16.AddRange(rsd.delim_digit);
            return d;
        }
    }
}
