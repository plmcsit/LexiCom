using System;
using System.Drawing;
using System.Windows.Forms;
using Lexical_Analyzer;
using Syntax_Analyzer;

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
            if (Code.Text != "")
            {
                //LEXICAL ANALYZER
                Output.Text = "========== Starting Lexical Analyzer ==========\n";
                LexicalAnalyzer lex = new LexicalAnalyzer();
                LexicalInitializer Lexical = new LexicalInitializer();
                string txt = Code.Text.TrimStart();
                lex = Lexical.InitializeAnalyzer(txt, lex);
                //DISPLAY TOKENS
                DisplayTokens(lex);
                Output.Text += "\n========== End of Lexical Analyzer ============\n";

                if(syntax_mode.Checked)
                if (lex.invalid == 0 && lex.tokens.Count != 0)
                {
                    //SYNTAX ANALYZER
                    SyntaxInitializer Syntax_Analyzer = new SyntaxInitializer();
                    Output.Text += "\n========== Starting Syntax Analyzer ==========\n";
                    Output.Text += Syntax_Analyzer.Start(lex.tokens);
                    Output.Text += "\n========== End of Syntax Analyzer ============\n\n";
                }
            }
        }

        private void DisplayTokens(Lexical_Analyzer.LexicalAnalyzer lex)
        {
            string result = "Successfully Executed.";
            int ctr = 0, id = 0;
            LexGrid.Rows.Clear();
            foreach (var item in lex.tokens)
            {
                id++;
                LexGrid.Rows.Add(id, lex.lexemes[ctr], item);
                ctr++;
            }

            if (lex.invalid != 0)
                result = "Encountered " + lex.invalid.ToString() + " error/s.\nPlease try again.";

            Output.Text +=
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

        private void syntaxAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (syntax_mode.Checked)
                syntax_mode.Checked = false;
            else
                syntax_mode.Checked = true;
        }
    }
}
