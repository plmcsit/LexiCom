using System;
using System.Collections.Generic;

using System.IO;
using Core.Library;
using TokenLibrary;
using Syntax_Analyzer;
using Semantics_Analyzer;

namespace Code_Translation
{
    public class CodeTranslator : SyntaxAnalyzer
    {

        public CodeTranslator()
            : this(new List<Tokens>(), new Semantics_Analyzer.SemanticsInitializer()) { }
        public Boolean runtime_error = false;
        private List<Tokens> tokens;
        private List<SemanticsConstants.Arrays> arrays;
        private List<SemanticsConstants.Identifiers> identifiers;
        private List<SemanticsConstants.Index> index;
        private List<SemanticsConstants.Objects> objects;
        private List<SemanticsConstants.Task> task;
        private string currscope = "Lead";
        
        public CodeTranslator(List<Tokens> tokens, SemanticsInitializer semantics)
        {
            this.tokens = tokens;
            this.arrays = semantics.arrays;
            this.identifiers = semantics.identifiers;
            this.index = semantics.indexes;
            this.objects = semantics.objects;
            this.task = semantics.tasks;
        }
        public class Tokens : TokensClass
        {
            public List<string> attribute = new List<string>();

            public string datatype;

            public int code;

            public void addAttribute(string attribute)
            {
                this.attribute.Add(attribute);
            }

            public List<string> getAttribute()
            {
                return this.attribute;
            }

            public void setDatatype(string datatype)
            {
                this.datatype = datatype;
            }

            public string getDatatype()
            {
                return this.datatype;
            }

            public void setCode(int code)
            {
                this.code = code;
            }

            public int getCode()
            {
                return this.code;
            }

        }
        public string error = "";
        public string code = "using System;\npublic class LexiCom\n{\n";
        private bool isRead = false;
        private bool isSay = false;
        private bool isSwitch = false;
        private bool isCase = false;
        private bool isDo = false;
        private bool isArray = false;
        private bool isFor = false;
        private bool isOutput = false;
        private bool isAt = false;
        private bool isAdd = false;
        private string input_datatype;
        private bool isDec = false;
        private bool isEnd = false;
        private bool isEndIf = false;
        private bool isOption = false;
        private bool isLoop = false;
        private bool isID = false;

        public string Start()
        {
           
            string tokenstream = "";
            string result = "Code Generation Failed...\n";
            int line = 1;
            int linejump = 0;
            int ctr = 0;
            foreach (var t in tokens)
            {
                if (t.getLines() != line)
                {
                    linejump = t.getLines() - line;
                    line = t.getLines();
                    for (int i = 0; i < linejump; i++)
                    {
                        tokenstream += "\n";
                    }
                }
                t.setCode(ctr);
                ctr++;
                tokenstream += t.getTokens() + " ";
            }
            tokenstream = tokenstream.TrimEnd();

            Parser p;
            p = CreateParser(tokenstream);

            try
            {
                p.Parse();
                if (error == "")
                    result = "Code Generation Succeeded...";
            }
            catch (ParserCreationException)
            {
                result = "Code Generation Halted due to Runtime Error...";
            }
            catch (ParserLogException)
            {
                result = "Code Generation Halted due to Runtime Log Error...";
            }
            return result;
        }

        private Parser CreateParser(string input)
        {
            SyntaxParser parser = null;
            try
            {
                parser = new SyntaxParser(new StringReader(input), this);
                parser.Prepare();
            }
            catch (ParserCreationException e)
            {
                throw new Exception(e.Message);
            }
            return parser;
        }

        public Tokens GetTokens(int line, int column)
        {
            List<Tokens> t = new List<Tokens>();
            Tokens token = new Tokens();
            int endline = 0;
            foreach (var item in tokens)
            {
                if (item.getLines() == line)
                    t.Add(item);
            }
            foreach (var item in t)
            {
                endline += item.getTokens().Length + 1;
                if (column <= endline)
                {
                    token = item;
                    break;
                }
            }
            return token;
        }

        public void SetTokenDatatype(int line, int column)
        {
            List<Tokens> t = new List<Tokens>();
            Tokens token = new Tokens();
            int endline = 0;
            foreach (var item in tokens)
            {
                if (item.getLines() == line)
                    t.Add(item);
                
            }
            foreach (var item in t)
            {
                endline += item.getTokens().Length + 1;
                if (column <= endline)
                {
                    token = item;
                    break;
                }
                
            }
        }

        //START TOKENS
        public override void EnterTask(Token node)
        {
            isAdd = true;
        }
        public override Node ExitTask(Token node)
        {
            if (isAdd)
            {
                isAdd = false;
            }
            return node;
        }
        public override void EnterLead(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLead(Token node)
        {
            if (isAdd)
            {
                code += "public static void Main()\n";
                isAdd = false;
            }
            return node;
        }
        public override void EnterStart(Token node)
        {
            isAdd = true;
        }
        public override Node ExitStart(Token node)
        {
            if (isAdd)
            {
                code += "{\n";
                isAdd = false;
            }
            return node;
        }
        public override void EnterEnd(Token node)
        {
            isAdd = true;
        }
        public override Node ExitEnd(Token node)
        {
            if (isAdd)
            {
                code += "}\n";
                isEnd = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterVar(Token node)
        {
            isAdd = true;
        }
        public override Node ExitVar(Token node)
        {
            if (isAdd)
            {
                if(currscope == "Global")
                {
                    code += "\npublic static ";
                }
                isDec = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterId(Token node)
        {
            isAdd = true;
        }
        public override Node ExitId(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {

                    Tokens t = new Tokens();
                    t = GetTokens(node.GetStartLine(), node.GetStartColumn());
                    code += " " + t.getLexemes();
                    if (isDec)
                    {
                        int codenum = t.getCode();
                        tokens[codenum].setDatatype(input_datatype);
                    }
                    if (isSay)
                    {
                        //code += ".ToString() ";
                    }
                }
                    isAdd = false;
            }
            return node;
        }
        public override void EnterAs(Token node)
        {
            isAdd = true;
        }
        public override Node ExitAs(Token node)
        {
            if (isAdd)
            {
                isAdd = false;
            }
            return node;
        }
        public override void EnterLet(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLet(Token node)
        {
            if (isAdd)
            {
                code += "const ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterObject(Token node)
        {
            isAdd = true;
        }
        public override Node ExitObject(Token node)
        {
            if (isAdd)
            {
                code += "public struct ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterOf(Token node)
        {
            isAdd = true;
        }
        public override Node ExitOf(Token node)
        {
            if (isAdd)
            {
                isAdd = false;
            }
            return node;
        }
        public override void EnterBy(Token node)
        {
            isAdd = true;
        }
        public override Node ExitBy(Token node)
        {
            if (isAdd)
            {
                isAdd = false;
            }
            return node;
        }
        public override void EnterIs(Token node)
        {
            isAdd = true;
        }
        public override Node ExitIs(Token node)
        {
            if (isAdd)
            {
                code += "= ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterClear(Token node)
        {
            isAdd = true;
        }
        public override Node ExitClear(Token node)
        {
            if (isAdd)
            {
                code += "Console.Clear()";
                isAdd = false;
            }
            return node;
        }
        public override void EnterRead(Token node)
        {
            isAdd = true;
        }
        public override Node ExitRead(Token node)
        {
            if (isAdd)
            {
                //code += "Console.ReadLine(";
                isRead = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterSay(Token node)
        {
            isAdd = true;
        }
        public override Node ExitSay(Token node)
        {
            if (isAdd)
            {
                code += "Console.Write(";
                isSay = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterSkip(Token node)
        {
            isAdd = true;
        }
        public override Node ExitSkip(Token node)
        {
            if (isAdd)
            {
                code += "continue;\n";
                isAdd = false;
            }
            return node;
        }
        public override void EnterStop(Token node)
        {
            isAdd = true;
        }
        public override Node ExitStop(Token node)
        {
            if (isAdd)
            {
                code += "break";
                isAdd = false;
            }
            return node;
        }
        public override void EnterIf(Token node)
        {
            isAdd = true;
        }
        public override Node ExitIf(Token node)
        {
            if (isAdd)
            {
            code += "if ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterOr(Token node)
        {
            isAdd = true;
        }
        public override Node ExitOr(Token node)
        {
            if (isAdd)
            {
                code += "}\nelse if";
                isAdd = false;
            }
            return node;
        }
        public override void EnterOtherwise(Token node)
        {
            isAdd = true;
        }
        public override Node ExitOtherwise(Token node)
        {
            if (isAdd)
            {
                code += "}\nelse{\n";
                isAdd = false;
            }
            return node;
        }
        public override void EnterOption(Token node)
        {
            isAdd = true;
        }
        public override Node ExitOption(Token node)
        {
            if (isAdd)
            {
                code += "switch(";
                isSwitch = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterState(Token node)
        {
            isAdd = true;
        }
        public override Node ExitState(Token node)
        {
            if (isAdd)
            {
                isCase = true;
                code += "case ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterDefault(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDefault(Token node)
        {
            if (isAdd)
            {
                code += "default";
                isAdd = false;
            }
            return node;
        }
        public override void EnterUntil(Token node)
        {
            isAdd = true;
        }
        public override Node ExitUntil(Token node)
        {
            if (isAdd)
            {
                code += "while ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterLoop(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLoop(Token node)
        {
            if (isAdd)
            {
                code += "}\n";
                isAdd = false;
                isLoop = true;
            }
            return node;
        }
        public override void EnterLoopif(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLoopif(Token node)
        {
            if (isAdd)
            {
                code += "\n}while ";
                isDo = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterDo(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDo(Token node)
        {
            if (isAdd)
            {
                code += "do{\n";
                isAdd = false;
            }
            return node;
        }
        public override void EnterFor(Token node)
        {
            isAdd = true;
        }
        public override Node ExitFor(Token node)
        {
            if (isAdd)
            {
                code += "for ";
                isFor = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterResponse(Token node)
        {
            isAdd = true;
        }
        public override Node ExitResponse(Token node)
        {
            if (isAdd)
            {
                code += "return ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterEndif(Token node)
        {
            isAdd = true;
        }
        public override Node ExitEndif(Token node)
        {
            if (isAdd)
            {
                code += "}\n";
                isEndIf = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterInt(Token node)
        {
            isAdd = true;
        }
        public override Node ExitInt(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {
                    input_datatype = "Int";
                    code += "int ";
                }
                isAdd = false;
            }
            return node;
        }
        public override void EnterDouble(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDouble(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {
                    input_datatype = "Double";
                    code += "double ";
                }
               isAdd = false;
            }
            return node;
        }
        public override void EnterChar(Token node)
        {
            isAdd = true;
        }
        public override Node ExitChar(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {
                    input_datatype = "Char";
                    code += "char ";
                }
                isAdd = false;
            }
            return node;
        }
        public override void EnterString(Token node)
        {
            isAdd = true;
        }
        public override Node ExitString(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {
                    code += "string ";
                    input_datatype = "String";
                }
                isAdd = false;
            }
            return node;
        }
        public override void EnterNull(Token node)
        {
            isAdd = true;
        }
        public override Node ExitNull(Token node)
        {
            if (isAdd)
            {
                input_datatype = "Void";
                code += "void ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterArray(Token node)
        {
            isAdd = true;
        }
        public override Node ExitArray(Token node)
        {
            if (isAdd)
            {
                isArray = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterBoolean(Token node)
        {
            input_datatype = "Boolean";
            isAdd = true;
        }
        public override Node ExitBoolean(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {
                    code += "bool ";
                }
                isAdd = false;
            }
            return node;
        }
        public override void EnterIntlit(Token node)
        {
            isAdd = true;
        }
        public override Node ExitIntlit(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                {
                    Tokens t = new Tokens();
                    t = GetTokens(node.GetStartLine(), node.GetStartColumn());
                    code += " " + t.getLexemes() + " ";
                }
                isAdd = false;
                
            }
            return node;
        }
        public override void EnterDoublelit(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDoublelit(Token node)
        {
            if (isAdd)
            {
                Tokens t = new Tokens();
                t = GetTokens(node.GetStartLine(), node.GetStartColumn());
                code += " " + t.getLexemes() + " ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterCharlit(Token node)
        {
            isAdd = true;
        }
        public override Node ExitCharlit(Token node)
        {
            if (isAdd)
            {
                Tokens t = new Tokens();
                t = GetTokens(node.GetStartLine(), node.GetStartColumn());
                code += " " + t.getLexemes() + " ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterStringlit(Token node)
        {
            isAdd = true;
        }
        public override Node ExitStringlit(Token node)
        {
            if(isAdd)
            {
                Tokens t = new Tokens();
                t = GetTokens(node.GetStartLine(),node.GetStartColumn());
                code += t.getLexemes();
                isAdd = false;
            }
            return node;
        }
        public override void EnterBoollit(Token node)
        {
            isAdd = true;
        }
        public override Node ExitBoollit(Token node)
        {
            if (isAdd)
            {
                string value = "";
                Tokens t = new Tokens();
                t = GetTokens(node.GetStartLine(), node.GetStartColumn());
                if(t.getLexemes() == "Yes")
                {
                    value = " true ";
                }
                else
                {
                    value = " false ";
                }
                    code += value;

                isAdd = false;
            }
            return node;
        }
        public override void EnterCol(Token node)
        {
            isAdd = true;
        }
        public override Node ExitCol(Token node)
        {
            if (isAdd)
            {
                if(isOption)
                {
                    code += ":\n";
                }
                isAdd = false;
            }
            return node;
        }
        public override void EnterSem(Token node)
        {
            isAdd = true;
        }
        public override Node ExitSem(Token node)
        {
            if (isAdd)
            {
                if (isFor)
                    code += "; ";
                else
                    code += ", ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterDie(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDie(Token node)
        {
            if (isAdd)
            {
                isAdd = false;
            }
            return node;
        }
        public override void EnterPer(Token node)
        {
            isAdd = true;
        }
        public override Node ExitPer(Token node)
        {
            if (isAdd)
            {
                //if(isLoop)
                //{
                //    isLoop = false;
                //    return node;
                //}
                if (!isEnd)
                {
                    if (!isEndIf)
                    {
                        if (!isLoop)
                        {
                            code += ";\n";
                            isEnd = false;
                            isEndIf = false;
                            isLoop = false;
                        }
                        else
                        {
                            isLoop = false;
                        }
                    }
                    else
                    {
                        isEndIf = false;
                    }
                }
                else
                {
                    isEnd = false;
                }
                isAdd = false;
            }
            return node;
        }
        public override void EnterOp(Token node)
        {
            isAdd = true;
        }
        public override Node ExitOp(Token node)
        {
            if (isAdd)
            {
                code += "( ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterCp(Token node)
        {
            isAdd = true;
        }
        public override Node ExitCp(Token node)
        {
            if (isAdd)
            {
                code += ")";
                isAdd = false;
            }
            return node;
        }
        public override void EnterOb(Token node)
        {
            isAdd = true;
        }
        public override Node ExitOb(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                    code += "[";
                isAdd = false;
            }
            return node;
        }
        public override void EnterCb(Token node)
        {
            isAdd = true;
        }
        public override Node ExitCb(Token node)
        {
            if (isAdd)
            {
                if (!isArray)
                    code += "]";
                isAdd = false;
            }
            return node;
        }
        public override void EnterAdd(Token node)
        {
            isAdd = true;
        }
        public override Node ExitAdd(Token node)
        {
            if (isAdd)
            {
                code += "+";
                isAdd = false;
            }
            return node;
        }
        public override void EnterMin(Token node)
        {
            isAdd = true;
        }
        public override Node ExitMin(Token node)
        {
            if (isAdd)
            {
                code += "-";
                isAdd = false;
            }
            return node;
        }
        public override void EnterMul(Token node)
        {
            isAdd = true;
        }
        public override Node ExitMul(Token node)
        {
            if (isAdd)
            {
                code += "*";
                isAdd = false;
            }
            return node;
        }
        public override void EnterDiv(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDiv(Token node)
        {
            if (isAdd)
            {
                code += "/";
                isAdd = false;
            }
            return node;
        }
        public override void EnterMod(Token node)
        {
            isAdd = true;
        }
        public override Node ExitMod(Token node)
        {
            if (isAdd)
            {
                code += "%";
                isAdd = false;
            }
            return node;
        }
        public override void EnterInc(Token node)
        {
            isAdd = true;
        }
        public override Node ExitInc(Token node)
        {
            if (isAdd)
            {
                code += "++ ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterDec(Token node)
        {
            isAdd = true;
        }
        public override Node ExitDec(Token node)
        {
            if (isAdd)
            {
                code += "-- ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterIseq(Token node)
        {
            isAdd = true;
        }
        public override Node ExitIseq(Token node)
        {
            if (isAdd)
            {
                code += " == ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterNoteq(Token node)
        {
            isAdd = true;
        }
        public override Node ExitNoteq(Token node)
        {
            if (isAdd)
            {
                code += " != ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterGreat(Token node)
        {
            isAdd = true;
        }
        public override Node ExitGreat(Token node)
        {
            if (isAdd)
            {
                code += " > ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterLess(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLess(Token node)
        {
            if (isAdd)
            {
                code += " < ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterLogand(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLogand(Token node)
        {
            if (isAdd)
            {
                code += " && ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterLogor(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLogor(Token node)
        {
            if (isAdd)
            {
                code += " || ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterNot(Token node)
        {
            isAdd = true;
        }
        public override Node ExitNot(Token node)
        {
            if (isAdd)
            {
                code += " !";
                isAdd = false;
            }
            return node;
        }
        public override void EnterEq(Token node)
        {
            isAdd = true;
        }
        public override Node ExitEq(Token node)
        {
            if (isAdd)
            {
                code += " = ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterComma(Token node)
        {
            isAdd = true;
        }
        public override Node ExitComma(Token node)
        {
            if (isAdd)
            {
                code += " + ";
                isSay = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterAt(Token node)
        {
            isAdd = true;
        }
        public override Node ExitAt(Token node)
        {
            if (isAdd)
            {
                code += ".";
                isAt = true;
                isAdd = false;
            }
            return node;
        }
        public override void EnterGeq(Token node)
        {
            isAdd = true;
        }
        public override Node ExitGeq(Token node)
        {
            if (isAdd)
            {
                code += " >= ";
                isAdd = false;
            }
            return node;
        }
        public override void EnterLeq(Token node)
        {
            isAdd = true;
        }
        public override Node ExitLeq(Token node)
        {
            if (isAdd)
            {
                code += " <= ";
                isAdd = false;
            }
            return node;
        }
        //END TOKENS



        public override Node ExitProdStartProgram(Production node)
        {
            return node;
        }

        public override void ChildProdStartProgram(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdProgram(Production node)
        {
        }

        public override Node ExitProdProgram(Production node)
        {
            runtime_error = false;
            return node;
        }

        public override void ChildProdProgram(Production node, Node child)
        {
            node.AddChild(child);
            if(child.GetName() == "Prod_lead")
            {
                code += "\nConsole.ReadKey();\n";
            }
        }

        public override void EnterProdGlobal(Production node)
        {
            currscope = "Global";
        }

        public override Node ExitProdGlobal(Production node)
        {
            currscope = "Lead";
            return node;
        }

        public override void ChildProdGlobal(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdGlobalChoice(Production node)
        {
        }

        public override Node ExitProdGlobalChoice(Production node)
        {
            return node;
        }

        public override void ChildProdGlobalChoice(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdDatatype(Production node)
        {
        }

        public override Node ExitProdDatatype(Production node)
        {
            return node;
        }

        public override void ChildProdDatatype(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdLetGlobal(Production node)
        {
        }

        public override Node ExitProdLetGlobal(Production node)
        {
            return node;
        }

        public override void ChildProdLetGlobal(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdValues(Production node)
        {
        }

        public override Node ExitProdValues(Production node)
        {
            return node;
        }

        public override void ChildProdValues(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVardec(Production node)
        {
        }

        public override Node ExitProdVardec(Production node)
        {
            isDec = false;
            return node;
        }

        public override void ChildProdVardec(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVardtype(Production node)
        {
        }

        public override Node ExitProdVardtype(Production node)
        {
            return node;
        }

        public override void ChildProdVardtype(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVarinitInt(Production node)
        {
        }

        public override Node ExitProdVarinitInt(Production node)
        {
            return node;
        }

        public override void ChildProdVarinitInt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVarinitDouble(Production node)
        {
        }

        public override Node ExitProdVarinitDouble(Production node)
        {
            return node;
        }

        public override void ChildProdVarinitDouble(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVarinitChar(Production node)
        {
        }

        public override Node ExitProdVarinitChar(Production node)
        {
            return node;
        }

        public override void ChildProdVarinitChar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVarinitString(Production node)
        {
        }

        public override Node ExitProdVarinitString(Production node)
        {
            return node;
        }

        public override void ChildProdVarinitString(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVarinitBoolean(Production node)
        {
        }

        public override Node ExitProdVarinitBoolean(Production node)
        {
            return node;
        }

        public override void ChildProdVarinitBoolean(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVartailInt(Production node)
        {
        }

        public override Node ExitProdVartailInt(Production node)
        {
            return node;
        }

        public override void ChildProdVartailInt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVartailDouble(Production node)
        {
        }

        public override Node ExitProdVartailDouble(Production node)
        {
            return node;
        }

        public override void ChildProdVartailDouble(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVartailChar(Production node)
        {
        }

        public override Node ExitProdVartailChar(Production node)
        {
            return node;
        }

        public override void ChildProdVartailChar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVartailString(Production node)
        {
        }

        public override Node ExitProdVartailString(Production node)
        {
            return node;
        }

        public override void ChildProdVartailString(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdVartailBoolean(Production node)
        {
        }

        public override Node ExitProdVartailBoolean(Production node)
        {
            return node;
        }

        public override void ChildProdVartailBoolean(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdValueChar(Production node)
        {
        }

        public override Node ExitProdValueChar(Production node)
        {
            return node;
        }

        public override void ChildProdValueChar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdValueString(Production node)
        {
        }

        public override Node ExitProdValueString(Production node)
        {
            return node;
        }

        public override void ChildProdValueString(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdValueBoolean(Production node)
        {
        }

        public override Node ExitProdValueBoolean(Production node)
        {
            return node;
        }

        public override void ChildProdValueBoolean(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIdTail(Production node)
        {
        }

        public override Node ExitProdIdTail(Production node)
        {
            return node;
        }

        public override void ChildProdIdTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIdsTail(Production node)
        {
        }

        public override Node ExitProdIdsTail(Production node)
        {
            return node;
        }

        public override void ChildProdIdsTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIdChoices(Production node)
        {
        }

        public override Node ExitProdIdChoices(Production node)
        {
            return node;
        }

        public override void ChildProdIdChoices(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdTaskParam(Production node)
        {
        }

        public override Node ExitProdTaskParam(Production node)
        {
            return node;
        }

        public override void ChildProdTaskParam(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdTaskParamTail(Production node)
        {
        }

        public override Node ExitProdTaskParamTail(Production node)
        {
            return node;
        }

        public override void ChildProdTaskParamTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdValue(Production node)
        {
        }

        public override Node ExitProdValue(Production node)
        {
            return node;
        }

        public override void ChildProdValue(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIndex(Production node)
        {
        }

        public override Node ExitProdIndex(Production node)
        {
            return node;
        }

        public override void ChildProdIndex(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIndexop(Production node)
        {
        }

        public override Node ExitProdIndexop(Production node)
        {
            return node;
        }

        public override void ChildProdIndexop(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdAddMin(Production node)
        {
        }

        public override Node ExitProdAddMin(Production node)
        {
            return node;
        }

        public override void ChildProdAddMin(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIndexValue(Production node)
        {
        }

        public override Node ExitProdIndexValue(Production node)
        {
            return node;
        }

        public override void ChildProdIndexValue(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIndexTail(Production node)
        {
        }

        public override Node ExitProdIndexTail(Production node)
        {
            return node;
        }

        public override void ChildProdIndexTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdElements(Production node)
        {
        }

        public override Node ExitProdElements(Production node)
        {
            return node;
        }

        public override void ChildProdElements(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdElementsTail(Production node)
        {
        }

        public override Node ExitProdElementsTail(Production node)
        {
            return node;
        }

        public override void ChildProdElementsTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdArray(Production node)
        {
            isArray = true;
        }

        public override Node ExitProdArray(Production node)
        {
            isArray = false;
            string ident = "";
            string dtype = "";
            string size1 = "";
            string size2 = "";
            bool isMultiD = false;
            if(node.GetChildCount() == 5)
            {
                isMultiD = true;
            }
            Node proddtype = node.GetChildAt(1).GetChildAt(0);
            Node prodident = node.GetChildAt(1).GetChildAt(1);
            Node size_1 = node.GetChildAt(3);
            Tokens t = new Tokens();
            t = GetTokens(prodident.GetStartLine(), prodident.GetStartColumn());
            ident = t.getLexemes();
            t = GetTokens(proddtype.GetStartLine(), proddtype.GetStartColumn());
            dtype = t.getLexemes();
            t = GetTokens(size_1.GetStartLine(), size_1.GetStartColumn());
            size1 = t.getLexemes();

            switch (dtype) {
                case "Int": dtype = "int"; break;
                case "Double": dtype = "double"; break;
                case "String": dtype = "string"; break;
                case "Char": dtype = "char"; break;
                case "Boolean": dtype = "bool"; break;
            }

            if (isMultiD)
            {
                Node size_2 = node.GetChildAt(4).GetChildAt(1);
                t = GetTokens(size_2.GetStartLine(), size_2.GetStartColumn());
                size2 = t.getLexemes();
                code += dtype + "[][] " + ident + " = new " + dtype + "["+size1+"][];\n";
                for(int i = 0; i < Int32.Parse(size1); i++)
                {
                    code += ident + "[" + i + "] = new "+ dtype + "["+ size2 +"];\n";
                }
                code = code.Remove(code.Length - 2, 2);
            }
            else
            {
                code += dtype + "[] " + ident + " = new " + dtype + "[" + size1 + "]";
            }
            
            return node;
        }

        public override void ChildProdArray(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdSizeTail(Production node)
        {
        }

        public override Node ExitProdSizeTail(Production node)
        {
            return node;
        }

        public override void ChildProdSizeTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdTask(Production node)
        {
        }

        public override Node ExitProdTask(Production node)
        {
            return node;
        }

        public override void ChildProdTask(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnType(Production node)
        {
        }

        public override Node ExitProdReturnType(Production node)
        {
            return node;
        }

        public override void ChildProdReturnType(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdParameters(Production node)
        {
        }

        public override Node ExitProdParameters(Production node)
        {
            return node;
        }

        public override void ChildProdParameters(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdParamTail(Production node)
        {
        }

        public override Node ExitProdParamTail(Production node)
        {
            return node;
        }

        public override void ChildProdParamTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdObject(Production node)
        {
        }

        public override Node ExitProdObject(Production node)
        {
            return node;
        }

        public override void ChildProdObject(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdObjectElem(Production node)
        {
        }

        public override Node ExitProdObjectElem(Production node)
        {
            return node;
        }

        public override void ChildProdObjectElem(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdObjectElemTail(Production node)
        {
        }

        public override Node ExitProdObjectElemTail(Production node)
        {
            return node;
        }

        public override void ChildProdObjectElemTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdObjectVar(Production node)
        {
        }

        public override Node ExitProdObjectVar(Production node)
        {
            return node;
        }

        public override void ChildProdObjectVar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdObjectVarTail(Production node)
        {
        }

        public override Node ExitProdObjectVarTail(Production node)
        {
            return node;
        }

        public override void ChildProdObjectVarTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdStatements(Production node)
        {
        }

        public override Node ExitProdStatements(Production node)
        {
            return node;
        }

        public override void ChildProdStatements(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdFunctions(Production node)
        {
        }

        public override Node ExitProdFunctions(Production node)
        {
            return node;
        }

        public override void ChildProdFunctions(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIoStatement(Production node)
        {
        }

        public override Node ExitProdIoStatement(Production node)
        {
            if (node.GetChildAt(0).GetName() == "SAY")
            {
                code += ")";
                isSay = false;
            }
            else
            {
                Tokens t = new Tokens();
                Node Ident = node.GetChildAt(1);
                t = GetTokens(Ident.GetStartLine(), Ident.GetStartColumn());
                t = tokens[t.getCode()];
                string input_datatype = "";

                foreach (var item in identifiers)
                {
                    if(item.getScope() == currscope)
                    {
                        if(item.getId() == t.getLexemes())
                        {
                            input_datatype = item.getDtype();
                        }
                    }
                }

                switch (input_datatype)
                {
                    case "Int": code += " = Int32.Parse(Console.ReadLine())"; break;
                    case "Double": code += " = Double.Parse(Console.ReadLine())"; break;
                    case "Char": code += " = Char.Parse(Console.ReadLine())"; break;
                    case "String": code += " = Console.ReadLine()"; break;
                    case "Boolean": code += " = Boolean.Parse(Console.ReadLine())"; break;
                    default:
                        break;
                }
            }
            //if (!runtime_error)
            //{
            //    Node isRead = node.GetChildAt(0);
            //    if (isRead.GetName() == "READ")
            //    {
            //        Node id = node.GetChildAt(1);
            //        int idcol = id.GetStartColumn();
            //        int idline = id.GetStartLine();
            //        Tokens token = GetTokens(idline, idcol);
            //        foreach (var item in identifiers)
            //        {
            //            if (item.getId() == token.getLexemes())
            //            {
            //                var input = (String)Console.ReadLine();
            //                if(String.IsNullOrEmpty(input))
            //                {
                                
            //                    input = Console.ReadLine();
            //                }
            //                string dtype = item.getDtype();
            //                bool isneg = false;
            //                switch (dtype)
            //                {
            //                    case "Int":
            //                        int input_int = 0;
            //                        if (input.Contains("~"))
            //                        {
            //                            isneg = true;
            //                            input = input.Remove(0, 1);
            //                        }
            //                        if (Int32.TryParse(input, out input_int))
            //                        {
            //                            if (isneg)
            //                            {
            //                                input_int *= -1;
            //                            }
            //                            item.setValue(input_int.ToString());
            //                        }
            //                        else
            //                        {
            //                            runtime_error = true;
            //                            Console.WriteLine("");
            //                            Console.WriteLine("Runtime error: Type mismatch!");

            //                        }
            //                        break;
            //                    case "Double":
            //                        double input_double = 0;
            //                        if (input.Contains("~"))
            //                        {
            //                            isneg = true;
            //                            input = input.Remove(0, 1);
            //                        }
            //                        if (Double.TryParse(input, out input_double))
            //                        {
            //                            if (isneg)
            //                            {
            //                                input_double *= -1;
            //                            }
            //                            item.setValue(input_double.ToString());
            //                        }
            //                        else
            //                        {
            //                            runtime_error = true;
            //                            Console.WriteLine("");
            //                            Console.WriteLine("Runtime error: Type mismatch!");
            //                        }

            //                        break;
            //                    case "Char":
            //                        if (input.Count() < 2)
            //                        {
            //                            item.setValue(input);
            //                        }
            //                        else
            //                        {
            //                            runtime_error = true;
            //                            Console.WriteLine("");
            //                            Console.WriteLine("Runtime error: invalid character input.");
            //                        }
            //                        break;
            //                    case "String":
            //                        item.setValue(input);
            //                        break;
            //                    case "Boolean":
            //                        if (input == "Yes" || input == "No")
            //                        {
            //                            item.setValue(input);
            //                        }
            //                        else
            //                        {
            //                            runtime_error = true;
            //                            Console.WriteLine("");
            //                            Console.WriteLine("Runtime error: invalid boolean input.");
            //                        }
            //                        break;
            //                    default:
            //                        break;
            //                }
            //            }
            //        }
            //    }
            //}
            return node;
        }

        public override void ChildProdIoStatement(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdOutputStatement(Production node)
        {
            if(isID)
            {
                code = code.Remove(code.Length - 3, 3);
                code += ".ToString() + ";
                isID = false;
            }
            string s = code;
        }

        public override Node ExitProdOutputStatement(Production node)
        {
            if (isID)
            {
                code = code.Remove(code.Length - 1, 1);
                code += ".ToString() ";
                isID = false;
            }
            return node;
        }

        public override void ChildProdOutputStatement(Production node, Node child)
        {
                        //if (!runtime_error)
            //{
            //    Node Output = child;
            //    Node Output_ID = Output;
            //    Tokens token;
            //    int count = Output.GetChildCount();
            //    if (Output_ID.GetName() == "STRINGLIT")
            //    {
            //        int idline = Output_ID.GetStartLine();
            //        int idcol = Output_ID.GetStartColumn();
            //        token = GetTokens(idline, idcol);
            //        string outs = token.getLexemes();
            //        outs = outs.Remove(0, 1);
            //        outs = outs.Remove(outs.Length - 1, 1);
            //        Console.Write(outs);
            //    }
            //    else if (Output_ID.GetName() == "ID")
            //    {
            //        int idline = Output_ID.GetStartLine();
            //        int idcol = Output_ID.GetStartColumn();
            //        token = GetTokens(idline, idcol);
            //        foreach (var item in identifiers)
            //        {
            //            if (item.getId() == token.getLexemes())
            //            {
            //                Console.Write(item.getValue());
            //            }
            //        }
            //    }
            //}
            node.AddChild(child);
            if(child.GetName() == "ID")
            {
                isID = true;
            }
            
        }

        public override void EnterProdConcat(Production node)
        {
        }

        public override Node ExitProdConcat(Production node)
        {
            return node;
        }

        public override void ChildProdConcat(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdPreIncdec(Production node)
        {
        }

        public override Node ExitProdPreIncdec(Production node)
        {
            return node;
        }

        public override void ChildProdPreIncdec(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdOption(Production node)
        {
            isOption = true;
        }

        public override Node ExitProdOption(Production node)
        {
            isOption = false;
            return node;
        }

        public override void ChildProdOption(Production node, Node child)
        {
            node.AddChild(child);
            if(child.GetName() == "Prod_elements")
            {
                code += ")";
            }
        }

        public override void EnterProdOptionChoices(Production node)
        {
        }

        public override Node ExitProdOptionChoices(Production node)
        {
            return node;
        }

        public override void ChildProdOptionChoices(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdOptionInt(Production node)
        {
        }

        public override Node ExitProdOptionInt(Production node)
        {
            return node;
        }

        public override void ChildProdOptionInt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdOptionChar(Production node)
        {
        }

        public override Node ExitProdOptionChar(Production node)
        {
            return node;
        }

        public override void ChildProdOptionChar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdOptionString(Production node)
        {
        }

        public override Node ExitProdOptionString(Production node)
        {
            return node;
        }

        public override void ChildProdOptionString(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdStateInt(Production node)
        {
        }

        public override Node ExitProdStateInt(Production node)
        {
            return node;
        }

        public override void ChildProdStateInt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdStateChar(Production node)
        {
        }

        public override Node ExitProdStateChar(Production node)
        {
            return node;
        }

        public override void ChildProdStateChar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdStateString(Production node)
        {
        }

        public override Node ExitProdStateString(Production node)
        {
            return node;
        }

        public override void ChildProdStateString(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdDefault(Production node)
        {
        }

        public override Node ExitProdDefault(Production node)
        {
            code += "\nbreak;\n";
            return node;
        }

        public override void ChildProdDefault(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdConditions(Production node)
        {
        }

        public override Node ExitProdConditions(Production node)
        {
            return node;
        }

        public override void ChildProdConditions(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdConditionChoices(Production node)
        {
        }

        public override Node ExitProdConditionChoices(Production node)
        {
            return node;
        }

        public override void ChildProdConditionChoices(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdConditionTail(Production node)
        {
        }

        public override Node ExitProdConditionTail(Production node)
        {
            return node;
        }

        public override void ChildProdConditionTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdConditionIds(Production node)
        {
        }

        public override Node ExitProdConditionIds(Production node)
        {
            return node;
        }

        public override void ChildProdConditionIds(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdLogOpTail(Production node)
        {
        }

        public override Node ExitProdLogOpTail(Production node)
        {
            return node;
        }

        public override void ChildProdLogOpTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdLogOpChoices(Production node)
        {
        }

        public override Node ExitProdLogOpChoices(Production node)
        {
            return node;
        }

        public override void ChildProdLogOpChoices(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdRelOp(Production node)
        {
        }

        public override Node ExitProdRelOp(Production node)
        {
            return node;
        }

        public override void ChildProdRelOp(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdLogOp(Production node)
        {
        }

        public override Node ExitProdLogOp(Production node)
        {
            return node;
        }

        public override void ChildProdLogOp(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdNegate(Production node)
        {
        }

        public override Node ExitProdNegate(Production node)
        {
            return node;
        }

        public override void ChildProdNegate(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIfOtherwise(Production node)
        {
        }

        public override Node ExitProdIfOtherwise(Production node)
        {
            return node;
        }

        public override void ChildProdIfOtherwise(Production node, Node child)
        {
            node.AddChild(child);
            if(node.GetChildCount() == 4)
            {
                code += "{\n";
            }
        }

        public override void EnterProdOr(Production node)
        {
        }

        public override Node ExitProdOr(Production node)
        {
            return node;
        }

        public override void ChildProdOr(Production node, Node child)
        {
            node.AddChild(child);
            if(node.GetChildCount() == 4)
            {
                code += "{\n";
            }
        }

        public override void EnterProdOtherwise(Production node)
        {
        }

        public override Node ExitProdOtherwise(Production node)
        {
            return node;
        }

        public override void ChildProdOtherwise(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdCondLoop(Production node)
        {
        }

        public override Node ExitProdCondLoop(Production node)
        {
            return node;
        }

        public override void ChildProdCondLoop(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdControl(Production node)
        {
        }

        public override Node ExitProdControl(Production node)
        {
            return node;
        }

        public override void ChildProdControl(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdLoopstate(Production node)
        {
        }

        public override Node ExitProdLoopstate(Production node)
        {
            return node;
        }

        public override void ChildProdLoopstate(Production node, Node child)
        {
            node.AddChild(child);
            Node loopstate = node.GetChildAt(0);
            if (loopstate.GetName() == "FOR" || loopstate.GetName() == "UNTIL")
            {
               if(child.GetName() == "CP")
                {
                    code += "\n{\n";
                }
            }
        }

        public override void EnterProdInitialize(Production node)
        {
        }

        public override Node ExitProdInitialize(Production node)
        {
            return node;
        }

        public override void ChildProdInitialize(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdInitChoices(Production node)
        {
        }

        public override Node ExitProdInitChoices(Production node)
        {
            return node;
        }

        public override void ChildProdInitChoices(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdCond(Production node)
        {
        }

        public override Node ExitProdCond(Production node)
        {
            return node;
        }

        public override void ChildProdCond(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIncdecvar(Production node)
        {
        }

        public override Node ExitProdIncdecvar(Production node)
        {
            return node;
        }

        public override void ChildProdIncdecvar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIdStmt(Production node)
        {
        }

        //public override Node ExitAdd(Token node)
        //{
        //    node.Values.Add("+");
        //    return node;
        //}

        //public override Node ExitMin(Token node)
        //{
        //    node.Values.Add("-");
        //    return node;
        //}
        //public override Node ExitDiv(Token node)
        //{
        //    node.Values.Add("/");
        //    return node;
        //}

        //public override Node ExitMul(Token node)
        //{
        //    node.Values.Add("*");
        //    return node;
        //}
        //public override Node ExitMod(Token node)
        //{
        //    node.Values.Add("%");
        //    return node;
        //}

        //public override Node ExitIntlit(Token node)
        //{
        //    //Tokens token = new Tokens();
        //    //token = GetTokens(node.GetStartLine(), node.GetStartColumn());
        //    //node.Values.Add(Int32.Parse(token.getLexemes()));
        //    return node;
        //}

        //public override Node ExitDoublelit(Token node)
        //{
        //    //Tokens token = new Tokens();
        //    //token = GetTokens(node.GetStartLine(), node.GetStartColumn());
        //    //node.Values.Add(Double.Parse(token.getLexemes()));
        //    return node;
        //}

        //public override Node ExitCharlit(Token node)
        //{
        //    //Tokens token = new Tokens();
        //    //token = GetTokens(node.GetStartLine(), node.GetStartColumn());
        //    //node.Values.Add(token.getLexemes());
        //    return node;
        //}

        //public override Node ExitStringlit(Token node)
        //{
        //    //Tokens token = new Tokens();
        //    //token = GetTokens(node.GetStartLine(), node.GetStartColumn());
        //    //node.Values.Add(token.getLexemes());
        //    return node;
        //}

        

        public override Node ExitProdIdStmt(Production node)
        {
            //Node ID = node.GetChildAt(0);
            //Tokens ident = new Tokens();
            //int idline = ID.GetStartLine();
            //int idcol = ID.GetStartColumn();
            //ident = GetTokens(idline, idcol);
            //string dtype = "";
            //SemanticsConstants.Identifiers id = new SemanticsConstants.Identifiers();
            //foreach (var item in identifiers)
            //{
            //    if (item.getId() == ident.getLexemes())
            //    {
            //        if (currscope == item.getScope())
            //        {
            //            dtype = item.getDtype();
            //        }
            //    }
            //}
            //Node id_stmt_tail = node.GetChildAt(1);
            //if (id_stmt_tail.GetChildCount() < 3)
            //{
            //    Node initvalues = id_stmt_tail.GetChildAt(1);
            //    if (initvalues.GetChildAt(0).GetName() != "Prod_mathopNUM")
            //    {
            //        Tokens t = new Tokens();
            //        t = GetTokens(initvalues.GetChildAt(0).GetStartLine(), initvalues.GetChildAt(0).GetStartColumn());
            //        if (initvalues.GetChildAt(0).GetName() == "STRINGLIT" && dtype == "String")
            //        {
            //            foreach (var item in identifiers)
            //            {
            //                if (item.getId() == ident.getLexemes())
            //                {
            //                    if (currscope == item.getScope())
            //                    {
            //                        string lex = t.getLexemes();
            //                        lex = lex.Remove(lex.Length - 1, 1);
            //                        lex = lex.Remove(0, 1);
            //                        t.setLexemes(lex);
            //                        item.setValue(t.getLexemes());
            //                    }
            //                }
            //            }
            //        }
            //        else if (initvalues.GetChildAt(0).GetName() == "CHARLIT" && dtype == "Char")
            //        {
            //            foreach (var item in identifiers)
            //            {
            //                if (item.getId() == ident.getLexemes())
            //                {
            //                    if (currscope == item.getScope())
            //                    {
            //                        string lex = t.getLexemes();
            //                        lex = lex.Remove(lex.Length - 1, 1);
            //                        lex = lex.Remove(0, 1);
            //                        t.setLexemes(lex);
            //                        item.setValue(t.getLexemes());
            //                    }
            //                }
            //            }
            //        }
            //        else if (initvalues.GetChildAt(0).GetName() == "BOOLLIT" && dtype == "BOOLEAN")
            //        {
            //            foreach (var item in identifiers)
            //            {
            //                if (item.getId() == ident.getLexemes())
            //                {
            //                    if (currscope == item.getScope())
            //                    {
            //                        item.setValue(t.getLexemes());
            //                    }
            //                }
            //            }
            //        }
            //        else
            //        {
            //            error += "Semantics Error: Type Mismatch at Ln(" + ident.getLines() + ")\n";
            //        }
            //    }
            //    else
            //    {
            //        Node mathop_NUM = initvalues.GetChildAt(0);
            //        foreach (var item in identifiers)
            //        {
            //            if (item.getId() == ident.getLexemes())
            //            {
            //                if (currscope == item.getScope())
            //                {
            //                    if (item.getDtype() == "Int")
            //                    {
            //                        string num = mathop_NUM.GetValue(0).ToString();
            //                        while (num.Contains("."))
            //                        {
            //                            num = num.Remove(num.Length - 1, 1);
            //                        }
            //                        mathop_NUM.Values.Clear();
            //                        mathop_NUM.Values.Add(num);
            //                    }
            //                        item.setValue(mathop_NUM.GetValue(0).ToString());
                                
            //                }
            //            }
            //        }
            //    }
            //}


            return node;
        }

        public override void ChildProdIdStmt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIdStmtTail(Production node)
        {
        }

        public override Node ExitProdIdStmtTail(Production node)
        {
            return node;
        }

        public override void ChildProdIdStmtTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdInitvalues(Production node)
        {
        }

        public override Node ExitProdInitvalues(Production node)
        {
            //node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override void ChildProdInitvalues(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdMathopInt(Production node)
        {
        }

        public override Node ExitProdMathopInt(Production node)
        {
            return node;
        }

        public override void ChildProdMathopInt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdMathopDouble(Production node)
        {
        }

        public override Node ExitProdMathopDouble(Production node)
        {
            return node;
        }

        public override void ChildProdMathopDouble(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdMathopNum(Production node)
        {
        }

        public override Node ExitProdMathopNum(Production node)
        {
            //node.Values.AddRange(GetChildValues(node));
            //if(node.GetValueCount() == 3)
            //{
            //    double result = Operate((string)node.GetValue(1),Double.Parse(node.GetValue(0).ToString()), Double.Parse(node.GetValue(2).ToString()));
            //    node.Values.Clear();
            //    node.Values.Add(result);
            //}
            return node;
        }

        public override void ChildProdMathopNum(Production node, Node child)
        {
            //Tokens t = new Tokens();
            //if (child.GetName() == "Prod_numvalue")
            //{
            //    Node value = child.GetChildAt(0);
            //    if (value.GetName() == "INTLIT" || value.GetName() == "DOUBLELIT")
            //    {
            //        t = GetTokens(value.GetStartLine(), value.GetStartColumn());
            //        child.Values.Add(t.getLexemes());
            //    }
            //    else
            //    {
            //        Node ident = value.GetChildAt(0);
            //        Tokens tok = new Tokens();
            //        tok = GetTokens(ident.GetStartLine(), ident.GetStartColumn());
            //        foreach (var item in identifiers)
            //        {
            //            if(item.getId() == tok.getLexemes())
            //            {
            //                if(item.getScope() == currscope)
            //                {
            //                    child.Values.Add(item.getValue());
            //                }
            //            }
            //        }
            //    }
            //}
            node.AddChild(child);
        }


        //private double Operate(string op, double value1, double value2)
        //{
        //    switch (op[0])
        //    {
        //        case '+':
        //            return value1 + value2;
        //        case '-':
        //            return value1 - value2;
        //        case '*':
        //            return value1 * value2;
        //        case '/':
        //            return value1 / value2;
        //        case '%':
        //            return value1 % value2;
        //        default:
        //            throw new Exception("unknown operator: " + op);
        //    }
        //}

        public override void EnterProdIntvalue(Production node)
        {
        }

        public override Node ExitProdIntvalue(Production node)
        {
            return node;
        }

        public override void ChildProdIntvalue(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdDoublevalue(Production node)
        {
        }

        public override Node ExitProdDoublevalue(Production node)
        {
            return node;
        }

        public override void ChildProdDoublevalue(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdNumvalue(Production node)
        {
        }

        public override Node ExitProdNumvalue(Production node)
        {
            //node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override void ChildProdNumvalue(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdExprId(Production node)
        {
        }

        public override Node ExitProdExprId(Production node)
        {
            return node;
        }

        public override void ChildProdExprId(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdMathopIntTail(Production node)
        {
        }

        public override Node ExitProdMathopIntTail(Production node)
        {
            return node;
        }

        public override void ChildProdMathopIntTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdMathopDoubleTail(Production node)
        {
        }

        public override Node ExitProdMathopDoubleTail(Production node)
        {
            return node;
        }

        public override void ChildProdMathopDoubleTail(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdMathopNumTail(Production node)
        {
        }

        public override Node ExitProdMathopNumTail(Production node)
        {
            //node.Values.AddRange(GetChildValues(node));
            return node;
        }

        public override void ChildProdMathopNumTail(Production node, Node child)
        {
            //Tokens t = new Tokens();
            //if (child.GetName() == "Prod_operators")
            //{
            //    Node op = child.GetChildAt(0);
            //    t = GetTokens(op.GetStartLine(), op.GetStartColumn());
            //    child.Values.Add(t.getLexemes());
            //}
            //else
            //{
                
            //}
            node.AddChild(child);
        }

        public override void EnterProdOperators(Production node)
        {
        }

        public override Node ExitProdOperators(Production node)
        {
            return node;
        }

        public override void ChildProdOperators(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIncdec(Production node)
        {
        }

        public override Node ExitProdIncdec(Production node)
        {
            return node;
        }
        public override void ChildProdIncdec(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdIncdecNull(Production node)
        {
        }

        public override Node ExitProdIncdecNull(Production node)
        {
            return node;
        }

        public override void ChildProdIncdecNull(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdTaskdef(Production node)
        {
        }

        public override Node ExitProdTaskdef(Production node)
        {
            return node;
        }

        public override void ChildProdTaskdef(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnId(Production node)
        {
        }

        public override Node ExitProdReturnId(Production node)
        {
            return node;
        }

        public override void ChildProdReturnId(Production node, Node child)
        {
            if (child.GetName() == "ID")
            {
                int idline = child.GetStartLine();
                int idcol = child.GetStartColumn();
                Tokens token = GetTokens(idline, idcol);
                currscope = "Task." + token.getLexemes();
            }
            node.AddChild(child);
        }

        public override void EnterProdTaskbody(Production node)
        {
        }

        public override Node ExitProdTaskbody(Production node)
        {
            return node;
        }

        public override void ChildProdTaskbody(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnInt(Production node)
        {
        }

        public override Node ExitProdReturnInt(Production node)
        {
            return node;
        }

        public override void ChildProdReturnInt(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnDouble(Production node)
        {
        }

        public override Node ExitProdReturnDouble(Production node)
        {
            return node;
        }

        public override void ChildProdReturnDouble(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnChar(Production node)
        {
        }

        public override Node ExitProdReturnChar(Production node)
        {
            return node;
        }

        public override void ChildProdReturnChar(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnString(Production node)
        {
        }

        public override Node ExitProdReturnString(Production node)
        {
            return node;
        }

        public override void ChildProdReturnString(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturnBoolean(Production node)
        {
        }

        public override Node ExitProdReturnBoolean(Production node)
        {
            return node;
        }

        public override void ChildProdReturnBoolean(Production node, Node child)
        {
            node.AddChild(child);
        }

        public override void EnterProdReturntail(Production node)
        {
        }

        public override Node ExitProdReturntail(Production node)
        {
            return node;
        }
    }
}
