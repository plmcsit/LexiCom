using System;
using System.Collections.Generic;
using System.Linq;

//Unused Libraries
//using System.Text;
//using System.Threading.Tasks;
//using System.Collections.Generic;

namespace Lexical_Analyzer
{
    public class StartLexical
    {

        //INITIALIZATION
        public LexicalAnalyzer StartLexicalAnalyzer(string txt, LexicalAnalyzer lex)
        {
            Boolean hastoken = false;
            txt = txt.TrimStart();
            lex.tokens.Clear();
            lex.lexemes.Clear();
            lex.invalid = 0;
            lex.valid = 0;
            while (txt != "")
            {

                if (hastoken = lex.GetReservedWords(txt))
                    txt = txt.Remove(0, lex.ctr);
                else if (hastoken = lex.GetReservedSymbols(txt))
                    txt = txt.Remove(0, lex.ctr);
                else if (hastoken = lex.GetLiterals(txt))
                    txt = txt.Remove(0, lex.ctr);
                else if (hastoken = lex.GetIdentifiers(txt))
                    txt = txt.Remove(0, lex.ctr);
                else
                {
                    lex.invalid++;
                    lex.tokens.Add("INVALID");
                    if (lex.state != 0)
                    {
                        switch (lex.state)
                        {
                            case 1:
                                lex.ctr = GetCtr(txt, 1);
                                break;
                        }
                    }
                    if (lex.ctr == 0 && txt.Length != 1) lex.ctr = GetCtr(txt);
                    else if (lex.ctr == 0 && txt.Length == 1) lex.ctr = 1;
                    lex.lexemes.Add(txt.Substring(0, lex.ctr));
                    txt = txt.Remove(0, lex.ctr);

                }
                txt = txt.TrimStart();
            }

            return lex;
        }

        //GET CTRS
        private int GetCtr(string txt)
        {
            TransitionDiagram.ReservedWordsDelims rwd = new TransitionDiagram.ReservedWordsDelims();
            TransitionDiagram td = new TransitionDiagram();
            rwd = td.AddRange(rwd);

            Boolean ifEnd = false;
            int ctr = 0;

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

            if (!(txt.Length >= ctr)) ctr--;
            return ctr;
        }
        private int GetCtr(string txt, int ctr)
        {
            Boolean notEnd = true;
            List<char> delims = new List<char>{ '"', '\\', '\n' };
            while (notEnd && (txt.Length - 1) >= ctr)
            {
                foreach (char c in delims)
                {
                    if ((txt.Length - 1) > ctr)
                    {
                        if (c == txt.ElementAt(ctr))
                        {
                            notEnd = false;
                            if (c == '\\')
                                if (txt.Length - 1 != ctr)
                                    ctr++;
                        }
                    }
                    else
                        notEnd = false;
                }
                ctr++;
            }
            return ctr;
        }
    }
}
