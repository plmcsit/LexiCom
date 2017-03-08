using System;
using System.Windows.Forms;
using System.Collections.Generic;

using Lexical_Analyzer;
using Syntax_Analyzer;
using Semantics_Analyzer;
using Code_Translation;
using Code_Generation;


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
            LexGrid.Rows.Clear();
            DataLexicalError.Rows.Clear();
            DataSyntaxError.Rows.Clear();
            Grid_Syntax.Rows.Clear();
            Grid_Dec.Rows.Clear();
            Grid_Array.Rows.Clear();
            Output.Text = "";
            if (Code.Text != "")
            {
                //LEXICAL ANALYZER
                Output.Text = "[1] Starting Lexical Analyzer\n";
                LexicalAnalyzer lex = new LexicalAnalyzer();
                LexicalInitializer Lexical = new LexicalInitializer();
                string txt = Code.Text;
                lex = Lexical.Start(txt, lex);
                //DISPLAY TOKENS
                DisplayTokens(lex);

                if (syntax_mode.Checked)
                    if (lex.invalid == 0 && lex.token.Count != 0)
                    {
                        //SYNTAX ANALYZER
                        SyntaxInitializer Syntax_Analyzer = new SyntaxInitializer();
                        SemanticsInitializer semantics = new SemanticsInitializer();
                        Output.Text += "\n[2] Starting Syntax Analyzer\n";

                        if (semantics_mode.Checked)
                        Output.Text += "[3] Starting Static Semantics Analyzer\n";
						string syntax_result = Syntax_Analyzer.Start (tokenDump (lex.token)) + "\n";
                        int c = 0;
                        Grid_Syntax.Rows.Clear();
                        foreach (var item in Syntax_Analyzer.SET)
                        {
                            Grid_Syntax.Rows.Add((c+1).ToString(), Syntax_Analyzer.PRODUCTION[c].ToString(), "->", Syntax_Analyzer.SET[c].ToString());
                            c++;
                        }


                        //MessageBox.Show(Syntax_Analyzer.production);
                        //MessageBox.Show(Syntax_Analyzer.recursiveprod);
                        if (syntax_result != "Syntax Analyzer Succeeded...\n")
                        {
                            int errornum = 1;
                            DataSyntaxError.Rows.Clear();
                            //if(Syntax_Analyzer.PRODUCTION[c-1] == "Prod_logop1")
                            //{
                            //    DataSyntaxError.Rows.Add(errornum, Syntax_Analyzer.errors.getLines(), Syntax_Analyzer.errors.getColumn(), "Expected: \"!\", \"id\", \"boollit\", \"intlit\", \"doublelit\", \"charlit\", \"stringlit\".");
                            //}
                            //else if (Syntax_Analyzer.PRODUCTION[c - 1] == "Prod_option" && Syntax_Analyzer.errors.getErrorMessage() == "Expected: Var, Clear, id, Int, Char, Boolean, Double, String, ++, --, Object, Until, Do, For, Array, If, Read, Say, Option, ., Stop, End.")
                            //{
                            //    DataSyntaxError.Rows.Add(errornum, Syntax_Analyzer.errors.getLines(), Syntax_Analyzer.errors.getColumn(), "Expected: \"intlit\", \"charlit\", \"stringlit\".");
                            //}
                            //else
                            if(Syntax_Analyzer.errors.getColumn() == 1)
                            {
                                Syntax_Analyzer.errors.setLines(Syntax_Analyzer.errors.getLines() - 1);
                            }
                            DataSyntaxError.Rows.Add(errornum, Syntax_Analyzer.errors.getLines(), Syntax_Analyzer.errors.getColumn(), Syntax_Analyzer.errors.getErrorMessage());
                            errornum++;
                        }
                        else
                        {
                            Output.Text += syntax_result;
                        }
                        if (semantics_mode.Checked)
                        {
                            semantics = SemanticsStart(tokenDumps(lex.token));
                            string semantics_result = semantics.Start();
                            foreach (var item in semantics.Identifiers)
                            {
                                Grid_Dec.Rows.Add(item.getLines(), item.getId(), item.getDtype(), item.getValue(), item.getScope());
                            }
                            foreach (var item in semantics.Indexes)
                            {
                                Grid_Array.Rows.Add(item.getId(), item.getDatatype(), item.getValue(), item.getIndex_1(), item.getIndex_2());
                            }
                            if (semantics.error != "" || syntax_result != "Syntax Analyzer Succeeded...\n")
                            {
                                Output.Text += semantics.error + semantics_result;
                            }
                            else
                            {
                                Output.Text += "Static Semantics Analyzer Succeeded...";
                                MessageBox.Show("Code compiled with no error.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                CodeTranslator generate = new CodeTranslator();
                                generate = CodeGenStart(TokenDump(lex.token), semantics);
                                generate.Start();
                                string code = generate.code;
                                code = code.Remove(code.Length - 2,2);
                                code += "}\n    public static int[] Random(int start, int end)\n{\nList<int> listNumbers = new List<int>();\nint length = (end - start) + 1;\nif (length < 2)\n{\n    Console.WriteLine(\"Insufficient Length of Random Numbers...\");\n    return listNumbers.ToArray();\n}\n\nRandom rand = new Random();\nint number;\nfor (int i = 0; i < length; i++)\n{\n    do\n    {\n        number = rand.Next(start, end + 1);\n    } while (listNumbers.Contains(number));\n    listNumbers.Add(number);\n}\nreturn listNumbers.ToArray();\n}";
                                code += "\nprivate static string Substr(string str, int index)\n{\nreturn str.Substring(index);\n}\nprivate static string Substr(string str, int index, int length)\n{\nreturn str.Substring(index, length);\n}\nprivate static int StrLen(string str)\n{\nreturn str.Length;\n}\npublic static int PInt(string s)\n{\n    int num = -1;\n bool p = false;\n  p = Int32.TryParse(s,out num);\n    return num;\n}";
                                code += "\npublic static char[] ToCharArray (string str)\n{\nreturn str.ToCharArray();\n}\n";
                                code += "\n   private static double Sqrt(int intNum)\n   {\n           return Double.Parse(Math.Sqrt(intNum).ToString(\"0.00##\"));\n   }\n";
                                code += "\npublic static double PDouble(string s)\n{\n    double num = -1;\n bool p = false;\n  p = Double.TryParse(s,out num);\n    return num;\n}\n}\n";
                                if (generatedCode.Checked)
                                {
                                    MessageBox.Show(code);
                                }
                                if(consoleOutput.Checked)
                                {
                                    //OUTPUT
                                    OutputInitializer output = new OutputInitializer();
                                    output.Start(code);
                                    if(output.error != "")
                                    {
                                        MessageBox.Show(output.error, "Woops!");
                                    }
                                }
                            }
                        }
                    }
            }
        }


        private SemanticsInitializer SemanticsStart(List<SemanticsInitializer.Tokens> tokens)
        {
            SemanticsInitializer sem = null;
            try
            {
                sem = new SemanticsInitializer(tokens);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return sem;
        }

        private CodeTranslator CodeGenStart(List<CodeTranslator.Tokens> tokens, SemanticsInitializer semantics)
        {
            CodeTranslator gen = null;
            try
            {
                gen = new CodeTranslator(tokens, semantics);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            return gen;
        }

        private string getTokens(List<Tokens> tokens)
        {
            string input = "";
            foreach (var item in tokens)
            {
                input += item.getTokens() + " ";
            }
            return input;
        }

        private void DisplayTokens(LexicalAnalyzer lex)
        {
            string result = "Succeeded...";
            int ctr = 0, id = 0, error = 0;
            LexGrid.Rows.Clear();
            DataLexicalError.Rows.Clear();
            DataSyntaxError.Rows.Clear();
            if (lex.invalid != 0)
                result = "Encountered " + lex.invalid.ToString() + " error/s.\nPlease try again.\n";
            Output.Text += "Lexical Analyzer " + result;

            foreach (var token in lex.token)
            {
                if (token.getTokens() == "INVALID")
                {
                    error++;
                    DataLexicalError.Rows.Add( error, "Invalid input: "
                                + token.getLexemes()
                                + " on line "
                                + token.getLines() + "\n");
                }
                else if (token.getTokens() == "NODELIM")
                {
                    error++;
                    DataLexicalError.Rows.Add(error, "Proper delimiter expected: "
                                + token.getLexemes()
                                + " on line "
                                + token.getLines() + "\n");
                }
                else
                {
                    id++;
                    LexGrid.Rows.Add(id, token.getLexemes(), token.getTokens(), token.getAttributes());
                }
                ctr++;
            }

        }

        private void syntaxAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (syntax_mode.Checked)
            {
                syntax_mode.Checked = false;
                semantics_mode.Checked = false;
            }
            else
            {
                syntax_mode.Checked = true;
                semantics_mode.Checked = true;
            }
        }



        public List<TokenLibrary.TokensClass> tokenDump(List<Tokens> tokens)
        {
            List<TokenLibrary.TokensClass> token = new List<TokenLibrary.TokensClass>();
            Tokens t = new Tokens();
            foreach (var item in tokens)
            {
                t = new Tokens();
                t.setAttributes(item.getAttributes());
                t.setLexemes(item.getLexemes());
                t.setLines(item.getLines());
                t.setTokens(item.getTokens());
                token.Add(t);
            }
            return token;
        }

        public List<SemanticsInitializer.Tokens> tokenDumps(List<Tokens> tokens)
        {
            List<SemanticsInitializer.Tokens> token = new List<SemanticsInitializer.Tokens>();
            SemanticsInitializer.Tokens t = new SemanticsInitializer.Tokens();
            foreach (var item in tokens)
            {
                t = new SemanticsInitializer.Tokens();
                t.setAttributes(item.getAttributes());
                t.setLexemes(item.getLexemes());
                t.setLines(item.getLines());
                t.setTokens(item.getTokens());
                token.Add(t);
            }
            return token;
        }

        public List<CodeTranslator.Tokens> TokenDump(List<Tokens> tokens)
        {
            List<CodeTranslator.Tokens> token = new List<CodeTranslator.Tokens>();
            CodeTranslator.Tokens t = new CodeTranslator.Tokens();
            foreach (var item in tokens)
            {
                t = new CodeTranslator.Tokens();
                t.setAttributes(item.getAttributes());
                t.setLexemes(item.getLexemes());
                t.setLines(item.getLines());
                t.setTokens(item.getTokens());
                token.Add(t);
            }
            return token;
        }

        private void semantics_mode_Click(object sender, EventArgs e)
        {
            if (semantics_mode.Checked)
                semantics_mode.Checked = false;
            else
            {
                semantics_mode.Checked = true;
                syntax_mode.Checked = true;
            }
        }

        private void LexGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            Code.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void generatedCode_Click(object sender, EventArgs e)
        {
            if(generatedCode.Checked == true)
            {
                generatedCode.Checked = false;
            }
            else
            {
                generatedCode.Checked = true;
            }
        }

        private void consoleOutput_Click(object sender, EventArgs e)
        {
            if (consoleOutput.Checked == true)
            {
                consoleOutput.Checked = false;
            }
            else
            {
                consoleOutput.Checked = true;
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
    }
}
