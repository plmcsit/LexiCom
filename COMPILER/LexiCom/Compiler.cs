using System;
using System.Windows.Forms;
using System.Collections.Generic;

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
                string txt = Code.Text;
                lex = Lexical.InitializeAnalyzer(txt, lex);
                //DISPLAY TOKENS
                DisplayTokens(lex);
                Output.Text += "\n========== End of Lexical Analyzer ============\n";

                if (syntax_mode.Checked)
                //if (lex.invalid == 0 && lex.tokens.Count != 0)
                if (lex.invalid == 0 && lex.lex.Count != 0)
                {
                    //SYNTAX ANALYZER
                    SyntaxInitializer Syntax_Analyzer = new SyntaxInitializer();
                    Output.Text += "\n========== Starting Syntax Analyzer ==========\n";
                    Output.Text += Syntax_Analyzer.Start(tokenDump(lex.lex));
                    Output.Text += "\n========== End of Syntax Analyzer ============\n\n";
                }
            }
        }

        private void DisplayTokens(LexicalAnalyzer lex)
        {
            string result = "Successfully Executed.";
            int ctr = 0, id = 0;
            LexGrid.Rows.Clear();

            if (lex.invalid != 0)
                result = "Encountered " + lex.invalid.ToString() + " error/s.\nPlease try again.\n";
            Output.Text += "Lexical Analyzer " + result;

            foreach (var token in lex.lex)
            {
                if (token.getTokens() == "INVALID")
                {

                    Output.Text += "Invalid input: "
                                + token.getLexemes()
                                + " on line "
                                + token.getLines() + "\n";
                }
                else if (token.getTokens() == "NODELIM")
                {
                    Output.Text += "Proper delimiter expected: "
                                + token.getLexemes()
                                + " on line "
                                + token.getLines() + "\n";
                }
                else
                {
                    id++;
                    LexGrid.Rows.Add(id, token.getLexemes(), token.getTokens(), token.getAttributes());
                }
                ctr++;
            }
           
        }

        //private void LexBtn_Click(object sender, EventArgs e)
        //{
        //    if (LexPanel.Location.X == 743)
        //    {

        //        LexPanel.Location = new Point(463, LexPanel.Location.Y);
        //        if (Code.Size.Width != 444)
        //        {
        //            Code.Size = new Size(444, Code.Size.Height);
        //            Output.Size = new Size(444, Output.Size.Height);
        //        }
        //    }
        //    else if (LexPanel.Location.X == 463)
        //    {
        //        LexPanel.Location = new Point(743, LexPanel.Location.Y);
        //        Code.Size = new Size(691, Code.Size.Height);
        //        Output.Size = new Size(691, Output.Size.Height);
        //    }
        //}

        private void syntaxAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (syntax_mode.Checked)
                syntax_mode.Checked = false;
            else
                syntax_mode.Checked = true;
        }

        public List<TokenLibrary.TokensClass> tokenDump(List<Lexical_Analyzer.Tokens> tokens) {
            List<TokenLibrary.TokensClass> t = new List<TokenLibrary.TokensClass>();
            Tokens token = new Tokens();
            foreach (var item in tokens)
            {
                token.setAttributes(item.getAttributes());
                token.setLexemes(item.getLexemes());
                token.setLines(item.getLines());
                token.setTokens(item.getTokens());
                t.Add(token);
            }
            return t;
        }
        
    }
}
