using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syntax_Analyzer;
using TokenLibrary;
using PerCederberg.Grammatica.Runtime;
using System.IO;

namespace Semantics_Analyzer
{
    public class SemanticsInitializer : SyntaxAnalyzer
    {
        public class Tokens : TokensClass
        {
            public List<string> attribute = new List<string>();

            public void addAttribute(string attribute)
            {
                this.attribute.Add(attribute);
            }

            public List<string> getAttribute()
            {
                return this.attribute;
            }
        }

        public string error = "";
        public List<Tokens> tokens;
        public List<Tokens> ID = new List<Tokens>();
        public List<Tokens> globalID = new List<Tokens>();

        public SemanticsInitializer()
            : this(new List<Tokens>()) { }

        public SemanticsInitializer(List<Tokens> tokens)
        {
            this.tokens = tokens;
        }

        public string Start()
        {
            string tokenstream = "";
            string result = "Semantics Analyzer Failed...\n";
            int line = 1;
            int linejump = 0;
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
                tokenstream += t.getTokens() + " ";
            }
            tokenstream = tokenstream.TrimEnd();

            Parser p;
            p = CreateParser(tokenstream);

            try
            {
                p.Parse();
                if (error == "")
                    result = "Semantics Analyzer Succeeded...";
            }
            catch (ParserCreationException e)
            {
                result = "Semantics Analyzer Halted due to Syntax Analyzer Error...";
            }
            catch (ParserLogException e)
            {
                result = "Semantics Analyzer Halted due to Syntax Log Error...";
            }
            return result;
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

        private void hasGlobalID(Tokens token)
        {
            Boolean isdeclared = false;
            if (globalID.Count != 0)
            {
                foreach (var item in globalID)
                {
                    if (token.getLexemes() == item.getLexemes())
                    {
                        error += "Semantics Error (Ln" + token.getLines() + "): " + token.getLexemes() + " is already declared.\n";
                        isdeclared = true;
                        break;
                    }
                }
            }

            if (!isdeclared)
            {
                globalID.Add(token);
            }
        }

        private string getDtype(string dtype)
        {
            switch (dtype)
            {
                case "INT":
                    dtype = "Int";
                    break;
                case "DOUBLE":
                    dtype = "Double";
                    break;
                case "CHAR":
                    dtype = "Char";
                    break;
                case "STRING":
                    dtype = "String";
                    break;
                case "BOOLEAN":
                    dtype = "Boolean";
                    break;
                case "NULL":
                    dtype = "Null";
                    break;

            }
            return dtype;
        }


        public override Node ExitProdStartProgram(Production node)
        {
            return node;
        }
        public override Node ExitProdProgram(Production node)
        {
            return node;
        }
        public override Node ExitProdGlobal(Production node)
        {
            return node;
        }
        public override Node ExitProdGlobalChoice(Production node)
        {

            if (node.GetChildAt(0).GetName() == "Prod_varlet")
            {
                Boolean isdeclared = false;
                int line, col;
                string varlet = node.GetChildAt(0).GetChildAt(0).GetName();
                if (varlet == "VAR")
                    varlet = "Var";
                else varlet = "Let";
                
                string dtype = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(0).GetName();
                int idline = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetStartLine();
                int idcol = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(1).GetStartColumn();
                dtype = getDtype(dtype);
                Tokens token = GetTokens(idline, idcol);
                Tokens ids = new Tokens();
                token.addAttribute(dtype);
                token.addAttribute(varlet);
                //If has a 3rd children
                if (node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2) != null)
                {
                    if (dtype == "Int")
                        if (node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetName() == "Prod_initINT")
                        {
                            if(node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetChildAt(0).GetName() == "IS")
                            {
                                line = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetChildAt(1).GetStartLine();
                                col = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetChildAt(1).GetStartColumn();
                                Tokens value = GetTokens(line, col);
                                token.addAttribute(value.getLexemes());   
                            }
                            //else
                            //{
                            //    ids = new Tokens();
                            //    line = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetStartLine();
                            //    col = node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetChildAt(0).GetChildAt(0).GetChildAt(1).GetStartColumn();
                            //    ids = GetTokens(line, col);
                            //    hasGlobalID(ids);
                            //}
                        }
                    if (dtype == "Double")
                        if (node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetName() == "Prod_initDOUBLE")
                        {

                        }
                    if (dtype == "Char")
                        if (node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetName() == "Prod_initCHAR")
                        {

                        }
                    if (dtype == "String")
                        if (node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetName() == "Prod_initSTRING")
                        {

                        }
                    if (dtype == "Boolean")
                        if (node.GetChildAt(0).GetChildAt(1).GetChildAt(0).GetChildAt(2).GetName() == "Prod_initBOOLEAN")
                        {

                        }
                }
                hasGlobalID(token);
            }
            return node;
        }
        public override Node ExitProdDtype(Production node)
        {
            return node;
        }
        public override Node ExitProdObject(Production node)
        {
            return node;
        }
        public override Node ExitProdObjdecChoice(Production node)
        {
            return node;
        }
        public override Node ExitProdVar(Production node)
        {
            return node;
        }
        public override Node ExitProdObjvar(Production node)
        {
            return node;
        }

        public override Node ExitProdVarname(Production node)
        {
            return node;
        }
        public override Node ExitProdVarnames(Production node)
        {
            return node;
        }
        public override Node ExitProdTask(Production node)
        {
            return node;
        }
        public override Node ExitProdReturn(Production node)
        {
            return node;
        }
        public override Node ExitProdTparam(Production node)
        {
            return node;
        }
        public override Node ExitProdTparams(Production node)
        {
            return node;
        }
        public override Node ExitProdArray(Production node)
        {
            return node;
        }
        public override Node ExitProdSize(Production node)
        {
            return node;
        }
        public override Node ExitProdSizes(Production node)
        {
            return node;
        }
        public override Node ExitProdVarlet(Production node)
        {
            return node;
        }

        public override Node ExitProdVardec(Production node)
        {
            return node;
        }
        public override Node ExitProdVarInt(Production node)
        {
            return node;
        }
        public override Node ExitProdInitInt(Production node)
        {
            return node;
        }
        public override Node ExitProdVarDouble(Production node)
        {
            return node;
        }
        public override Node ExitProdInitDouble(Production node)
        {
            return node;
        }
        public override Node ExitProdVarChar(Production node)
        {
            return node;
        }
        public override Node ExitProdInitChar(Production node)
        {
            return node;
        }
        public override Node ExitProdVarString(Production node)
        {
            return node;
        }
        public override Node ExitProdInitString(Production node)
        {
            return node;
        }
        public override Node ExitProdVarBoolean(Production node)
        {
            return node;
        }
        public override Node ExitProdInitBoolean(Production node)
        {
            return node;
        }
        public override Node ExitProdIds1(Production node)
        {
            return node;
        }
        public override Node ExitProdIds2(Production node)
        {
            return node;
        }
        public override Node ExitProdIds3(Production node)
        {
            return node;
        }
        public override Node ExitProdIds4(Production node)
        {
            return node;
        }
        public override Node ExitProdIds5(Production node)
        {
            return node;
        }
        public override Node ExitProdIds1Tail(Production node)
        {
            return node;
        }
        public override Node ExitProdIds2Tail(Production node)
        {
            return node;
        }
        public override Node ExitProdIds3Tail(Production node)
        {
            return node;
        }
        public override Node ExitProdIds4Tail(Production node)
        {
            return node;
        }
        public override Node ExitProdIds5Tail(Production node)
        {
            return node;
        }
        public override Node ExitProdValue1(Production node)
        {
            return node;
        }
        public override Node ExitProdValue2(Production node)
        {
            return node;
        }
        public override Node ExitProdValue3(Production node)
        {
            return node;
        }
        public override Node ExitProdValue4(Production node)
        {
            return node;
        }
        public override Node ExitProdValue5(Production node)
        {
            return node;
        }
        public override Node ExitProdNumvalue(Production node)
        {
            return node;
        }
        public override Node ExitProdNumelement(Production node)
        {
            return node;
        }
        public override Node ExitProdOperations1(Production node)
        {
            return node;
        }
        public override Node ExitProdOpInt(Production node)
        {
            return node;
        }
        public override Node ExitProdOp1(Production node)
        {
            return node;
        }
        public override Node ExitProdDoublevalue(Production node)
        {
            return node;
        }
        public override Node ExitProdOperations2(Production node)
        {
            return node;
        }
        public override Node ExitProdOpDouble(Production node)
        {
            return node;
        }
        public override Node ExitProdOp2(Production node)
        {
            return node;
        }
        public override Node ExitProdMathOp(Production node)
        {
            return node;
        }
        public override Node ExitProdIncdec(Production node)
        {
            return node;
        }
        public override Node ExitProdRelop1(Production node)
        {
            return node;
        }
        public override Node ExitProdLogop1(Production node)
        {
            return node;
        }
        public override Node ExitProdLogop2(Production node)
        {
            return node;
        }
        public override Node ExitProdBody(Production node)
        {
            return node;
        }
        public override Node ExitProdStatements(Production node)
        {
            return node;
        }
        public override Node ExitProdFunctions(Production node)
        {
            return node;
        }
        public override Node ExitProdIdChoices(Production node)
        {
            return node;
        }
        public override Node ExitProdSubelementChoice(Production node)
        {
            return node;
        }
        public override Node ExitProdVarinit(Production node)
        {
            return node;
        }
        public override Node ExitProdVarinitInt(Production node)
        {
            return node;
        }
        public override Node ExitProdVarinitDouble(Production node)
        {
            return node;
        }
        public override Node ExitProdVarinitChar(Production node)
        {
            return node;
        }
        public override Node ExitProdVarinitString(Production node)
        {
            return node;
        }
        public override Node ExitProdVarinitBoolean(Production node)
        {
            return node;
        }
        public override Node ExitProdInt(Production node)
        {
            return node;
        }
        public override Node ExitProdDouble(Production node)
        {
            return node;
        }
        public override Node ExitProdChar(Production node)
        {
            return node;
        }
        public override Node ExitProdString(Production node)
        {
            return node;
        }
        public override Node ExitProdBoolean(Production node)
        {
            return node;
        }
        public override Node ExitProdTaskId(Production node)
        {
            return node;
        }
        public override Node ExitProdParam(Production node)
        {
            return node;
        }
        public override Node ExitProdParams(Production node)
        {
            return node;
        }
        public override Node ExitProdValue(Production node)
        {
            return node;
        }
        public override Node ExitProdIoStatement(Production node)
        {
            return node;
        }
        public override Node ExitProdInput(Production node)
        {
            return node;
        }
        public override Node ExitProdOutput(Production node)
        {
            return node;
        }
        public override Node ExitProdInputStatement(Production node)
        {
            return node;
        }
        public override Node ExitProdConcat(Production node)
        {
            return node;
        }
        public override Node ExitProdConcatValue(Production node)
        {
            return node;
        }
        public override Node ExitProdSubelement(Production node)
        {
            return node;
        }
        public override Node ExitProdInputId(Production node)
        {
            return node;
        }
        public override Node ExitProdMulti(Production node)
        {
            return node;
        }
        public override Node ExitProdIndex(Production node)
        {
            return node;
        }
        public override Node ExitProdIfOtherwise(Production node)
        {
            return node;
        }
        public override Node ExitProdOr(Production node)
        {
            return node;
        }
        public override Node ExitProdOtherwise(Production node)
        {
            return node;
        }
        public override Node ExitProdCondLoop(Production node)
        {
            return node;
        }
        public override Node ExitProdControl(Production node)
        {
            return node;
        }
        public override Node ExitProdConditions(Production node)
        {
            return node;
        }
        public override Node ExitProdMulticonds(Production node)
        {
            return node;
        }
        public override Node ExitProdCondsTail(Production node)
        {
            return node;
        }
        public override Node ExitProdLogOps(Production node)
        {
            return node;
        }
        public override Node ExitProdRelOps(Production node)
        {
            return node;
        }
        public override Node ExitProdRelopNum(Production node)
        {
            return node;
        }
        public override Node ExitProdRelopText(Production node)
        {
            return node;
        }
        public override Node ExitProdNumval(Production node)
        {
            return node;
        }
        public override Node ExitProdOption(Production node)
        {
            return node;
        }
        public override Node ExitProdOptiontails(Production node)
        {
            return node;
        }
        public override Node ExitProdOptiontail1(Production node)
        {
            return node;
        }
        public override Node ExitProdOptiontail2(Production node)
        {
            return node;
        }
        public override Node ExitProdOptiontail3(Production node)
        {
            return node;
        }
        public override Node ExitProdState1(Production node)
        {
            return node;
        }
        public override Node ExitProdState2(Production node)
        {
            return node;
        }
        public override Node ExitProdState3(Production node)
        {
            return node;
        }
        public override Node ExitProdDefault(Production node)
        {
            return node;
        }
        public override Node ExitProdIncdecvar(Production node)
        {
            return node;
        }
        public override Node ExitProdLoopstate(Production node)
        {
            return node;
        }
        public override Node ExitProdInitialize(Production node)
        {
            return node;
        }
        public override Node ExitProdCond(Production node)
        {
            return node;
        }
        public override Node ExitProdTaskdef(Production node)
        {
            return node;
        }
        public override Node ExitProdReturntype(Production node)
        {
            return node;
        }
        public override Node ExitProdTaskbody(Production node)
        {
            return node;
        }
        public override Node ExitProdReturnInt(Production node)
        {
            return node;
        }
        public override Node ExitProdReturnDouble(Production node)
        {
            return node;
        }
        public override Node ExitProdReturnChar(Production node)
        {
            return node;
        }
        public override Node ExitProdReturnString(Production node)
        {
            return node;
        }
        public override Node ExitProdReturnBoolean(Production node)
        {
            return node;
        }
        public override Node ExitProdReturntail(Production node)
        {
            return node;
        }
    }
}
