using System;
using System.Collections.Generic;
using System.Linq;

//Unused Libraries
//using System.Text;
//using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    public class LexicalAnalyzer
    {  
        public List<String> tokens = new List<String>();
        public List<String> lexemes = new List<String>();
        public List<int> linetokens = new List<int>();
        LexicalConstants td = new LexicalConstants();
        Boolean isReserved = false;
        public int invalid = 0;
        public byte state = 0;
        public int valid = 0;
        public int lines = 1;
        public int ctr = 0;
        
        //GET NEWLINES
        public Boolean GetTokenLines(string txt, int tokenctr)
        {
            Boolean hastokenlines = false;
            if(txt.ElementAt(0) == '\n')
            {
                lines++;
                linetokens.Add(tokenctr);
                hastokenlines = true;
                ctr = 1;
            }
            else if(txt.ElementAt(0) == ' ')
            {
                hastokenlines = true;
                ctr = 1;
            }
            return hastokenlines;
        }

        //GET TOKENS
        public Boolean GetReservedWords(string txt)
        {
            LexicalConstants.ReservedWordsDelims rwd = new LexicalConstants.ReservedWordsDelims();
            LexicalConstants.ReservedWords rw = new LexicalConstants.ReservedWords();
            List<String> words;
            List<char> delims;
            List<String> temp;
            Boolean found = false, hastoken = false, exitfor = false, ifEnd = false, nodelim = true;
            int tempctr = 0,limit = 0;
            rwd = td.AddRange(rwd);

            if (txt.Length != 1)
            {
                while ((txt.Length - 1) > tempctr&&!isEnd(txt[tempctr + 1],rwd))
                {
                    tempctr++;
                }
                tempctr++;
            }

            for (int i = 0; i < 10; i++)
            {
                ctr = 0;
                words = new List<String>();
                delims = new List<char>();
                found = true;
                switch (i)
                {
                    case 0:
                        words = rw.rw_1;
                        delims = rwd.delim_1;
                        break;
                    case 1:
                        words = rw.rw_2;
                        delims = rwd.delim_2;
                        break;
                    case 2:
                        words = rw.rw_3;
                        delims = rwd.delim_3;
                        break;
                    case 3:
                        words = rw.rw_4;
                        delims = rwd.delim_4;
                        break;
                    case 4:
                        words = rw.rw_5;
                        delims = rwd.delim_5;
                        break;
                    case 5:
                        words = rw.rw_6;
                        delims = rwd.delim_6;
                        break;
                    case 6:
                        words = rw.rw_space;
                        delims = rwd.delim_space;
                        break;
                    case 7:
                        words = rw.rw_period;
                        delims = rwd.delim_period;
                        break;
                    case 8:
                        words = rw.rw_colon;
                        delims = rwd.delim_colon;
                        break;
                    case 9:
                        words = rw.rw_newline;
                        delims = rwd.delim_newline;
                        break;
                }
                //Check Reserved Words
                foreach (char c in txt)
                {
                    limit = words.Count - 1;
                    temp = new List<string>();
                    found = false;
                    foreach(string w in words)
                    {
                        //IF NOT OUT OF RANGE
                        if ((w.Length - 1) >= ctr)
                        {
                            //IF LETTER MATCHED
                            if (c == w.ElementAt(ctr))
                            {
                                found = true;
                                //CHECK SIZE OF WORD AND INPUT
                                if (w.Length == tempctr)
                                {
                                    //CHECK DELIMITER
                                    if ((tempctr - 1) == ctr)
                                    {
                                        foreach (char delim in delims)
                                        {
                                            //IF NOT OUT OF RANGE
                                            if ((txt.Length - 1) > ctr)
                                            {
                                                //IF FOUND DELIMITER
                                                if (txt[ctr + 1] == delim)
                                                {
                                                    hastoken = true;
                                                    nodelim = false;
                                                    tokens.Add(w);
                                                    lexemes.Add(w);
                                                    valid++;
                                                    break;
                                                }
                                            }
                                            else if (w == words[limit] && hastoken == false)
                                            {
                                                found = false;
                                            }
                                            if (hastoken == false)
                                            {
                                                hastoken = true;
                                                nodelim = false;
                                                tokens.Add("NODELIM");
                                                lexemes.Add(w);
                                                invalid++;
                                            }
                                        }

                                        if (hastoken)
                                        {
                                            break;
                                        }
                                        if(nodelim)
                                        {
                                            hastoken = true;
                                            tokens.Add("INVALID");
                                            lexemes.Add(w);
                                            invalid++;
                                            break;
                                        }
                                    }
                                    else temp.Add(w);
                                }
                            }

                        }
                    }
                    ctr++;
                    words = temp;
                    if (found == false) break;
                    if (hastoken)
                    {
                        exitfor = true;
                        break;
                    }
                }
                if (exitfor)
                {
                    exitfor = false;
                    break;
                }
            }

            //IF NOTHING FOUND
            if (found == false)
            {
                    hastoken = false;
                    foreach (var item in rwd.delim_end)
                    {
                        if (txt.ElementAt(ctr - 1) == item)
                            ifEnd = true;
                    }
                    while (ifEnd != true)
                    {
                        foreach (var item in rwd.delim_end)
                        {
                            if ((txt.Length) > ctr)
                            {
                                if (txt.ElementAt(ctr) == item)
                                {
                                    ifEnd = true;
                                    break;
                                }
                            }
                            else ifEnd = true;
                        }
                        if (ifEnd != true)
                            ctr++;
                    }
            }

            if (!(txt.Length >= ctr)) ctr--;
            
            return hastoken;
        }
        public Boolean GetReservedSymbols(string txt)
        {
            LexicalConstants td = new LexicalConstants();
            LexicalConstants.ReservedSymbols rs = new LexicalConstants.ReservedSymbols();
            LexicalConstants.ReservedSymbolsDelims rsd = new LexicalConstants.ReservedSymbolsDelims();
            Boolean found = false, hastoken = false, exitfor = false;
            rsd = td.AddRange(rsd);
            List<String> words;
            List<char> delims;
            List<String> temp;
            int tempctr = 0, limit = 0, sctr= 0;
            
            if (txt.Length != 1)
            {
                while ((txt.Length - 1) > tempctr && !isEnd(txt[tempctr + 1],rsd))
                {
                    tempctr++;
                }
                tempctr++;
            }

            for (int i = 0; i < 14; i++)
            {
                sctr = 0;
                words = new List<String>();
                delims = new List<char>();
                found = true;
                switch (i)
                {
                    case 0:
                        words = rs.rs_digit;
                        delims = rsd.delim_digit;
                        break;
                    case 1:
                        words = rs.rs_caplet;
                        delims = rsd.delim_caplet;
                        break;
                    case 2:
                        words = rs.rs_newline;
                        delims = rsd.delim_newline;
                        break;
                    case 3:
                        words = rs.rs_period;
                        delims = rsd.delim_period;
                        break;
                    case 4:
                        words = rs.rs_6;
                        delims = rsd.delim_6;
                        break;
                    case 5:
                        words = rs.rs_7;
                        delims = rsd.delim_7;
                        break;
                    case 6:
                        words = rs.rs_8;
                        delims = rsd.delim_8;
                        break;
                    case 7:
                        words = rs.rs_9;
                        delims = rsd.delim_9;
                        break;
                    case 8:
                        words = rs.rs_10;
                        delims = rsd.delim_10;
                        break;
                    case 9:
                        words = rs.rs_11;
                        delims = rsd.delim_11;
                        break;
                    case 10:
                        words = rs.rs_13;
                        delims = rsd.delim_13;
                        break;
                    case 11:
                        words = rs.rs_14;
                        delims = rsd.delim_14;
                        break;
                    case 12:
                        words = rs.rs_15;
                        delims = rsd.delim_15;
                        break;
                    case 13:
                        words = rs.rs_done;
                        break;
                }
                //Check Reserved Symbols
                if (i != 13)
                {
                    foreach (char c in txt)
                    {
                        limit = words.Count - 1;
                        temp = new List<string>();
                        found = false;
                        foreach (string w in words)
                        {
                            //IF NOT OUT OF RANGE
                            if ((w.Length - 1) >= sctr)
                            {
                                if (c == w.ElementAt(sctr))
                                {
                                    found = true;
                                    //CHECK SIZE OF WORD AND INPUT
                                    if (w.Length == tempctr)
                                    {
                                        //CHECK DELIMITER
                                        if ((tempctr - 1) == sctr)
                                        {
                                            foreach (char delim in delims)
                                            {
                                                //IF NOT OUT OF RANGE
                                                if ((txt.Length - 1) > sctr)
                                                {
                                                    //IF FOUND DELIMITER
                                                    if (txt[sctr + 1] == delim)
                                                    {
                                                        found = true;
                                                        hastoken = true;
                                                        tokens.Add(w);
                                                        lexemes.Add(w);
                                                        valid++;
                                                        break;

                                                    }
                                                }
                                                else if (w == words[limit] && hastoken == false) found = false;
                                            }

                                            if (hastoken) break;

                                        }
                                        else temp.Add(w);
                                    }
                                }
                            }
                        }
                        sctr++;
                        words = temp;
                        if (found == false) break;
                        if (hastoken)
                        {
                            exitfor = true;
                            break;
                        }
                    }
                }
                else
                {
                    if(txt.ElementAt(sctr) == words[0].ElementAt(0))
                    {
                        sctr = txt.Length;
                        tokens.Add("#");
                        lexemes.Add("#");
                        hastoken = true;
                    }
                }
                if (exitfor)
                {
                    exitfor = false;
                    break;
                }
            }
            if (hastoken) ctr = sctr;
                return hastoken;
        }
        public Boolean GetLiterals(string txt)
        {
            LexicalConstants.LiteralsDelims ld = new LexicalConstants.LiteralsDelims();
            LexicalConstants.Literals l = new LexicalConstants.Literals();
            List<char> delims = new List<char>();
            Boolean hastoken = false, validtxt = false;
            string literal = "";
            state = 0;
            int lctr = 0;

            if (txt.ElementAt(lctr) == '"')
                state = 1;
            else if (txt.ElementAt(lctr) == '\'')
                state = 2;
            else
            {
                foreach (char num in l.nums)
                {
                    if (txt.ElementAt(lctr) == num)
                        state = 3;
                }
            }

            if (state != 0)
            {
                switch (state)
                {
                    case 1: case 2:
                        delims = ld.delim_txt;
                        //String Literal Analyzer
                        if (state == 1)
                        {
                            if (txt.Length != 1)
                            {
                                while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '"') && !(txt[lctr + 1] == '\n'))
                                {
                                    literal += txt[lctr].ToString();
                                    lctr++;
                                }
                                
                                if ((txt.Length - 1) == lctr && (txt[lctr] != '"'))
                                    hastoken = false;
                                else
                                {
                                    if (!(lctr == 1 && txt[lctr] == '\\'))
                                    {
                                        validtxt = true;
                                        lctr++;
                                        foreach (char c in delims)
                                        {
                                            if ((txt.Length - 1) >= (lctr + 1))
                                            {
                                                if (txt[lctr + 1] == c)
                                                {

                                                    hastoken = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                    if (hastoken && validtxt)
                                    {
                                        valid++;
                                        tokens.Add("stringlit");
                                        lexemes.Add(txt.Substring(0, (lctr + 1)));
                                        ctr = lctr + 1;
                                    }
                                    else if (!validtxt)
                                    {
                                        ctr = lctr + 2;
                                        hastoken = false;
                                    }

                                }
                            }
                        }

                        //Character Literal Analyzer
                        else
                        {
                            if (txt.Length != 1)
                            {
                               
                                while ((txt.Length - 1) > lctr && !(txt[lctr + 1] == '\'') && !(txt[lctr + 1] == '\n'))
                                {
                                    literal += txt[lctr].ToString();
                                    lctr++;
                                }
                                if (lctr >= 3)
                                {
                                    hastoken = false;
                                    ctr = lctr + 2;
                                    if (ctr > txt.Length)
                                        ctr = txt.Length;
                                }
                                else
                                {
                                    if ((txt[1] == '\\' && lctr == 2) || (lctr == 1 && txt[1] != '\\') || lctr == 0)
                                        validtxt = true;
                                    else
                                    {
                                        validtxt = false;
                                        hastoken = false;
                                        ctr = lctr + 2;
                                        if (ctr > txt.Length)
                                            ctr = txt.Length;
                                    }
                                    if (validtxt)
                                    {
                                        if ((txt.Length - 1) >= (lctr + 1) && txt[lctr + 1] == '\'')
                                        {
                                            lctr++;
                                            foreach (char c in delims)
                                            {
                                                if ((txt.Length - 1) >= (lctr + 1))
                                                    if (txt[lctr + 1] == c)
                                                    {
                                                        hastoken = true;
                                                        break;
                                                    }
                                            }
                                        }
                                        if (hastoken)
                                        {
                                            valid++;
                                            tokens.Add("charlit");
                                            lexemes.Add(txt.Substring(0, (lctr + 1)));
                                            ctr = lctr + 1;
                                        }
                                        else
                                        {

                                            ctr = lctr + 1;
                                            if (ctr > txt.Length)
                                                ctr = lctr;
                                        }
                                    }
                                }
                            }
                        }
                        break;

                    case 3:
                        LexicalConstants.Identifier id = new LexicalConstants.Identifier();
                        delims = ld.delim_num;
                        Boolean isNumNext = true, hasnum = true, hasid = false;
                        List<char> num = new List<char> { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                        id.id.AddRange(id.delim_caplet);
                        id.id.AddRange(id.delim_caplet);

                        //If Negative
                        if (txt.ElementAt(lctr) == '~')
                        {
                            hasnum = false;
                            foreach (char n in num)
                            {
                                if ((txt.Length - 1) > lctr)
                                    if (txt.ElementAt(lctr + 1) == n)
                                    {
                                        hasnum = true;
                                        lctr++;
                                    }
                            }
                        }

                        if (hasnum)
                        {
                            while (isNumNext)
                            {
                                isNumNext = false;
                                foreach (char n in num)
                                {
                                    if ((txt.Length - 1) > lctr)
                                        if (txt.ElementAt(lctr + 1) == n)
                                        {
                                            lctr++;
                                            isNumNext = true;
                                        }
                                }
                            }

                            Boolean isDouble = false;
                            if((txt.Length - 1) > lctr)
                            if(txt.ElementAt(lctr + 1) == '.')
                            {
                                    if((txt.Length - 1) > lctr + 1)
                                    foreach (char n in num)
                                    {
                                            if (txt.ElementAt(lctr + 2) == n)
                                                isDouble = true;
                                    }
                            }

                            //Double Literal Analyzer
                                if (isDouble)
                                {
                                    lctr++;
                                    isNumNext = true;
                                    while (isNumNext)
                                    {
                                        isNumNext = false;
                                        foreach (char n in num)
                                        {
                                            if ((txt.Length - 1) > lctr)
                                                if (txt.ElementAt(lctr + 1) == n)
                                                {
                                                    lctr++;
                                                    isNumNext = true;
                                                }
                                        }
                                    }

                                    foreach (char delim in delims)
                                    {
                                        if ((txt.Length - 1) > lctr)
                                            if (txt.ElementAt(lctr + 1) == delim)
                                            {
                                                hastoken = true;
                                                break;
                                            }
                                    }

                                    if (hastoken)
                                    {
                                        valid++;
                                        tokens.Add("doublelit");
                                        lexemes.Add(txt.Substring(0, (lctr + 1)));
                                    }
                                    else
                                    {
                                        foreach (char c in id.id)
                                        {
                                            if ((txt.Length - 1) > lctr)
                                                if (txt.ElementAt(lctr + 1) == c)
                                                {
                                                    hasid = true;
                                                }
                                        }
                                    }

                                    if (!hasid)
                                        ctr = lctr + 1;
                                }
                                //Integer Literal Analyzer
                                else
                                {
                                    foreach (char delim in delims)
                                    {
                                        if (txt.ElementAt(lctr + 1) == delim)
                                        {
                                            hastoken = true;
                                            break;
                                        }
                                    }

                                    if (hastoken)
                                    {
                                        valid++;
                                        tokens.Add("intlit");
                                        lexemes.Add(txt.Substring(0, (lctr + 1)));
                                    }
                                    else
                                    {
                                        foreach (char c in id.id)
                                        {
                                            if (txt.ElementAt(lctr + 1) == c)
                                            {
                                                hasid = true;
                                            }
                                        }
                                    }
                                    if (!hasid)
                                        ctr = lctr + 1;
                                }
                        }
                        break;
                }
            }
            return hastoken;
        }
        public Boolean GetIdentifiers(string txt)
        {
            LexicalConstants.Identifier id = new LexicalConstants.Identifier();
            LexicalConstants.IdentifierDelims delims = new LexicalConstants.IdentifierDelims();
            Boolean hastoken = false, valID = false, isvalID = true;
            
            id.id.AddRange(id.delim_lowlet);
            id.id.AddRange(id.delim_caplet);
            id.id.AddRange(id.delim_undscr);
            id.id.AddRange(id.delim_digit);

            int ictr = 0;

            foreach (char c in id.delim_caplet)
            {
                if (txt.ElementAt(ictr) == c)
                {
                    valID = true;
                }
            }

            if(valID)
            {
                ictr++;
                isvalID = true;
                while (isvalID)
                {
                    isvalID = false;
                    foreach (char n in id.id)
                    {
                        if ((txt.Length - 1) > ictr)
                            if (txt.ElementAt(ictr + 1) == n)
                            {
                                ictr++;
                                isvalID = true;
                            }
                    }
                    if (ictr > 19)
                        valID = false;
                }
                
                if (valID)
                {
                    foreach (char delim in delims.delim_end)
                    {
                        if ((txt.Length - 1) > ictr)
                            if (txt.ElementAt(ictr + 1) == delim)
                            {
                                hastoken = true;
                                break;
                            }
                    }
                }

                if(hastoken)
                {
                    valid++;
                    tokens.Add("id");
                    lexemes.Add(txt.Substring(0, (ictr + 1)));
                }

                ctr = ictr + 1;
            }
            return hastoken;
        }

        //IS ENDS
        public Boolean isEnd(char c, LexicalConstants.ReservedWordsDelims rwd)
        {
            Boolean result = false;
            foreach (var item in rwd.delim_end)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Boolean isEnd(char c, LexicalConstants.ReservedSymbolsDelims rsd)
        {
            Boolean result = false;
            foreach (var item in rsd.delim_end)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        public Boolean isEnd(char c, List<char> ld)
        {
            Boolean result = false;
            foreach (var item in ld)
            {
                if (item == c)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

    }
}