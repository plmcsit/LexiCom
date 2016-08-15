using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using Lexical_Analyzer;

namespace LexiCom
{
    public partial class LexiCom : Form
    {
        public LexiCom() 
        {
            InitializeComponent();
        }

        private void LexButton_Click(object sender, EventArgs e)
        {

            //LEXICAL ANALYZER
            LexicalAnalyzer lex = new LexicalAnalyzer();
            StartLexical StartLex = new StartLexical();
            string txt = Code.Text.TrimStart();
            lex = StartLex.StartLexicalAnalyzer(txt, lex);
            DisplayTokens(lex);



        }

        private void DisplayTokens(LexicalAnalyzer lex)
        {
            string result = "Successfully Executed...";
            int ctr = 0, id = 0;
            LexGrid.Rows.Clear();
            foreach (var item in lex.tokens)
            {
                id++;
                LexGrid.Rows.Add(id, lex.lexemes[ctr], item);
                ctr++;
            }

            if (lex.invalid != 0)
                result = "Encountered (" + lex.invalid.ToString() + ") error/s. Please try again...";

            Output.Text =
                "No. of valid lexemes: " + lex.valid.ToString()
                + "\nNo. of invalid lexemes: " + lex.invalid.ToString()
                + "\nLexical Analyzer " + result;
        }

        private void LexBtn_Click(object sender, EventArgs e)
        {
            if(LexPanel.Location.X == 743)
            {

                    LexPanel.Location = new Point(463, LexPanel.Location.Y);
                    if (Code.Size.Width != 444)
                    {
                        Code.Size = new Size(444, Code.Size.Height);
                        Output.Size = new Size(444, Output.Size.Height);
                    }
            }
            else if(LexPanel.Location.X == 463)
            {
                    LexPanel.Location = new Point(743, LexPanel.Location.Y);
                    Code.Size = new Size(691, Code.Size.Height);
                    Output.Size = new Size(691, Output.Size.Height);
            }
        }
    }
}
