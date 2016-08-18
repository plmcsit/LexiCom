using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace Lexical_Analyzer
{
    class Sample
    {
        public List<String> tokens = new List<String>();
        public List<String> lexemes = new List<String>();
        public int invalid = 0;
        public int valid = 0;
        public int ctr = 0;
        TransitionDiagram td = new TransitionDiagram();

        public Boolean GetReservedWords(string txt)
        {
            TransitionDiagram.ReservedWordsDelims rwd = new TransitionDiagram.ReservedWordsDelims();
            TransitionDiagram.ReservedWords rw = new TransitionDiagram.ReservedWords();
            List<String> words;
            List<char> delims;
            List<String> temp;
            Boolean found = false, hastoken = false, exitfor = false, ifEnd = false;
            int tempctr = 0, limit = 0;
            rwd = td.AddRange(rwd);

            if (txt.Length != 1)
            {
                while ((txt.Length - 1) > tempctr && !isEnd(txt[tempctr + 1], rwd))
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
                    foreach (string w in words)
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

        public Boolean isEnd(char c, TransitionDiagram.ReservedWordsDelims rwd)
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

    }

}
