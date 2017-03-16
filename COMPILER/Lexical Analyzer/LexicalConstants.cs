using System.Collections.Generic;

namespace Lexical_Analyzer
{
    public class LexicalConstants
    {
        //RESERVED WORDS
        public class ReservedWords
        {
            public List<string> rw_whitespace = new List<string> { "Array", "as", "by", "Do", "is", "Let", "Object", "Option", "Otherwise", "of",
                                                                   "Read", "Response", "Say", "Start", "State", "Task", "Var" };
            public List<string> rw_1 = new List<string> { "Clear", "End", "EndIf", "Loop", "Skip", "Stop" };
            public List<string> rw_2 = new List<string> { "Default", "Lead" };
            public List<string> rw_3 = new List<string> { "For", "If", "Or", "Until", "LoopIf" };
            public List<string> rw_dtype = new List<string> { "String", "Boolean", "Char", "Double", "Int", "Null" };
            public List<string> rw_bool = new List<string> { "No", "Yes" };
        }
        public class ReservedWordsDelims
        {
            public List<char> whitespace = new List<char> { '\t', ' ', '\n' };
            public List<char> delim_1 = new List<char> { '\t', ' ', '\n', '.' };
            public List<char> delim_2 = new List<char> { '\t', ' ', '\n', ':' };
            public List<char> delim_3 = new List<char> { '\t', ' ', '\n', '(' };
            public List<char> delim_dtype = new List<char> { '\t', ' ', '\n', '.' };
            public List<char> delim_bool = new List<char> { '\t', ' ', '\n', '.', ';', '&', '|', ')' };
            public List<char> delim_end = new List<char> { '.', ' ', '\n', '\t','(' , ':', ',', '&', '\'', '[', ']', '?', '#', '$', '%', '\\',
                                                           '|', '=', '+', '-', '*', '/', ')', '"', ';', '<', '>', '!', '@', '^', '~', '`', '_'};
        }
        
        //RESERVED SYMBOLS
        public class ReservedSymbols
        {
            public List<string> rs_whitespace = new List<string> { ":" };
            public List<string> rs_caplet = new List<string> { "@" };
            public List<string> rs_concat = new List<string> { "," };
            public List<string> rs_delim4 = new List<string> { "." };
            public List<string> rs_delim5 = new List<string> { ")" };
            public List<string> rs_delim6 = new List<string> { "[", "%" };
            public List<string> rs_delim7 = new List<string> { "]" };
            public List<string> rs_delim8 = new List<string> { "++", "--" };
            public List<string> rs_condop = new List<string> { "!=", "==", ">", ">=", "<", "<=" };
            public List<string> rs_relop  = new List<string> { "&&", "||", "!", "=", ";" };
            public List<string> rs_rel0p  = new List<string> { "(" };
            public List<string> rs_math   = new List<string> { "+", "-", "*", "/" };
            public List<string> rs_done   = new List<string> { "#" };
        }
        public class ReservedSymbolsDelims
        {
            public List<char> whitespace = new List<char> { '\t', ' ', '\n' };
            public List<char> condop = new List<char> { '\t', ' ', '\n', '!', '~' };
            public List<char> concat = new List<char> { '\t', ' ', '\n', '"' };
            public List<char> relop = new List<char> { '\t', '"', '\'', '(' };
            public List<char> rel0p = new List<char> { '\t', '"', '\'', '(', ')'};
            public List<char> delim4 = new List<char> { '\t', ' ', '\n', '#' };
            public List<char> delim5 = new List<char> { '\t', '&', '|', ')', '.', ' ', '\n' };
            public List<char> delim6 = new List<char> { '\t', ' ' };
            public List<char> delim7 = new List<char> { '\t', '[', '='};
            public List<char> delim8 = new List<char> { '\t', ' ', ')', '.', ',', ';' };
            public List<char> math = new List<char> { '\t', '(' };    
            public List<char> delim_numbers = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            public List<char> delim_caplet = new List<char> { 'A','B','C','D','E','F','G','H','I','J','K','L','M',
                                                       'N','O','P','Q','R','S','T','U','V','W','X','Y','Z' };
            public List<char> delim_lowlet = new List<char> { 'a','b','c','d','e','f','g','h','i','j','k','l','m',
                                                       'n','o','p','q','r','s','t','u','v','w','x','y','z' };
            public List<char> mathop = new List<char> { '+', '-', '*', '/', '%' };
            public List<char> delim_bool = new List<char> { ' ', '\n', '.', ';', '&', '|', ')' };
            public List<char> delim_end = new List<char> { '.', ' ', '\n', '\t','(' , ':', ',', '\'', '[', ']', '?', '#', '$', '%', '\\',
                                                            ')', '"', ';', '@', '^', '~', '`', '_', '!', '<', '>','*', '/'};
        }
        public ReservedSymbolsDelims AddRange(ReservedSymbolsDelims rsd)
        {
            rsd.condop.AddRange(rsd.delim_numbers);
            rsd.condop.AddRange(rsd.delim_caplet);
            rsd.relop.AddRange(rsd.condop);
            rsd.rel0p.AddRange(rsd.condop);
            rsd.concat.AddRange(rsd.delim_caplet);
            rsd.delim4.AddRange(rsd.delim_caplet);
            rsd.delim5.AddRange(rsd.mathop);
            rsd.delim5.AddRange(rsd.delim_numbers);
            rsd.delim6.AddRange(rsd.delim_numbers);
            rsd.delim6.AddRange(rsd.delim_caplet);
            rsd.delim7.AddRange(rsd.mathop);
            rsd.delim7.AddRange(rsd.delim_bool);
            rsd.delim8.AddRange(rsd.delim_caplet);
            rsd.math.AddRange(rsd.condop);
            rsd.delim_end.AddRange(rsd.delim_numbers);
            rsd.delim_end.AddRange(rsd.delim_caplet);
            rsd.delim_end.AddRange(rsd.delim_lowlet);
            return rsd;
        }

        //LITERALS
        public class Literals
        {
            public List<char> nums = new List<char> { '~', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
        public class LiteralsDelims
        {
            public List<char> delim_txt = new List<char> { '\t', ' ', '\n', ';', ',', ')', '.', ':' };
            public List<char> delim_num = new List<char> { '\t', '+', '-', '*', '/', '.', ' ', ':', '\n', ';', '&', '|', ')','%', ']'};
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
                                                           ')', '"', ';', '@', '^', '~', '`', '_', '!', '<', '>','*', '/', '+', '-'};
        }        
    }
}