using System;
using System.Collections.Generic;
using Syntax_Analyzer;
using TokenLibrary;
using Core.Library;
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
        //public List<Tokens> ID = new List<Tokens>();
        private List<Tokens> globalID = new List<Tokens>();

        //List of Identifiers
        public List<SemanticsConstants.Identifiers> identifiers = new List<SemanticsConstants.Identifiers>();
        public List<SemanticsConstants.Arrays> arrays = new List<SemanticsConstants.Arrays>();
        public List<SemanticsConstants.Index> indexes = new List<SemanticsConstants.Index>();
        public List<SemanticsConstants.Objects> objects = new List<SemanticsConstants.Objects>();
        public List<SemanticsConstants.Task> tasks = new List<SemanticsConstants.Task>();
        private string currscope = "Lead";
        public List<SemanticsConstants.Identifiers> Identifiers
        {
            get
            {
                return identifiers;
            }

            set
            {
                identifiers = value;
            }
        }

        public List<SemanticsConstants.Arrays> Arrays
        {
            get
            {
                return arrays;
            }

            set
            {
                arrays = value;
            }
        }

        public List<SemanticsConstants.Index> Indexes
        {
            get
            {
                return indexes;
            }

            set
            {
                indexes = value;
            }
        }

        public List<SemanticsConstants.Objects> Objects
        {
            get
            {
                return objects;
            }

            set
            {
                objects = value;
            }
        }

        public List<SemanticsConstants.Task> Tasks
        {
            get
            {
                return tasks;
            }

            set
            {
                tasks = value;
            }
        }

        public List<Tokens> GlobalID
        {
            get
            {
                return globalID;
            }

            set
            {
                globalID = value;
            }
        }

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
            catch (ParserCreationException)
            {
                result = "Semantics Analyzer Halted due to Syntax Analyzer Error...";
            }
            catch (ParserLogException)
            {
                result = "Semantics Analyzer Halted due to Syntax Log Error...";
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

        private Boolean isDeclaredID(SemanticsConstants.Identifiers id)
        {
            Boolean isdeclared = false;
            if (Identifiers.Count != 0)
            {
                foreach (var item in Identifiers)
                {
                    if (item.getScope() == "Global" || item.getScope() == currscope)
                    {
                        if (item.getAttrib() == "Variable" || item.getAttrib() == "Let" || item.getAttrib() == "Array")
                        {
                            if (item.getId() == id.getId())
                            {
                                error += "Semantics Error (Ln" + id.getLines() + "): " + id.getId() + " is already declared.\n";
                                isdeclared = true;
                                break;
                            }
                        }
                    }
                }
            }

            if (!isdeclared)
            {
                Identifiers.Add(id);
            }
            return isdeclared;
        }

        private void hasMULTIID(Node node, string datatype, string scope, string attrib, string default_value)
        {
            SemanticsConstants.Identifiers id = new SemanticsConstants.Identifiers();
            int idline = node.GetChildAt(1).GetStartLine();
            int idcol = node.GetChildAt(1).GetStartColumn();
            Tokens token = GetTokens(idline, idcol);
            string identifier = token.getLexemes();
            
            if (node.GetChildCount() > 2)
            {
                //If no initialization but has vartail
                if (node.GetChildAt(2).GetName() == ("Prod_vartail" + datatype.ToUpper()))
                {
                    id = setIdentifier(identifier, attrib, datatype, scope, default_value, idline, token.getLexemes());
                    isDeclaredID(id);
                    hasMULTIID(node.GetChildAt(2), datatype, scope, attrib, default_value);
                }
                //If has initialization and vartail
                else if (node.GetChildCount() == 4)
                {
                    Node val = null;
                    if (datatype == "Boolean" || datatype == "String" || datatype == "Char")
                    {
                        val = node.GetChildAt(2).GetChildAt(1).GetChildAt(0);
                    }
                    else
                    {
                        val = node.GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(0);
                    }
                    Tokens valT = GetTokens(val.GetStartLine(), val.GetStartColumn());
                    id = setIdentifier(identifier, attrib, datatype, scope, valT.getLexemes(), idline, token.getLexemes());
                    isDeclaredID(id);
                    hasMULTIID(node.GetChildAt(3), datatype, scope, attrib, default_value);
                }
                else
                {
                    Node val = null;
                    if (datatype == "Boolean" || datatype == "String" || datatype == "Char")
                    {
                        val = node.GetChildAt(2).GetChildAt(1).GetChildAt(0);
                    }
                    else
                    {
                        val = node.GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(0);
                    }
                    Tokens valT = GetTokens(val.GetStartLine(), val.GetStartColumn());
                    id = setIdentifier(identifier, attrib, datatype, scope, valT.getLexemes(), idline, token.getLexemes());
                    isDeclaredID(id);
                }
            }
            else
            {
                id = setIdentifier(identifier, attrib, datatype, scope, default_value, idline, token.getLexemes());
                isDeclaredID(id);
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

        private void populateArray(string id, string datatype, Boolean isMulti, int size_1, int size_2)
        {
            string value = "";
            switch (datatype)
            {
                case "Int":
                    datatype = "Int";
                    value = "0"; break;
                case "Double":
                    datatype = "Double";
                    value = "0.0"; break;
                case "Char":
                    datatype = "Char";
                    value = "''"; break;
                case "String":
                    datatype = "String";
                    value = "\"\""; break;
                case "Boolean":
                    datatype = "Boolean";
                    value = "Yes"; break;
            }
            if(isMulti)
            {
                for (int i = 0; i < size_1; i++)
                {
                    for (int j = 0; j < size_2; j++)
                    {
                        SemanticsConstants.Index index = new SemanticsConstants.Index();
                        index = setIndex(id, datatype, i, j, value);
                        Indexes.Add(index);
                    }
                }
            }
            else
            {
                for (int k = 0; k < size_1; k++)
                {
                    SemanticsConstants.Index index = new SemanticsConstants.Index();
                    index = setIndex(id, datatype, k, 0, value);
                    Indexes.Add(index);
                }
            }
        }

        private SemanticsConstants.Identifiers setIdentifier
        (string identifier, string attrib, string dtype, string scope, string value, int lines, string token)
        {
            SemanticsConstants.Identifiers ID = new SemanticsConstants.Identifiers();
            ID.setAttrib(attrib);
            ID.setDtype(dtype);
            ID.setId(identifier);
            ID.setLines(lines);
            ID.setScope(scope);
            ID.setTokens(token);
            ID.setValue(value);
            return ID;
        }

        private SemanticsConstants.Arrays setArray
        (string identifier, string dtype, bool isMulti, int size_1, int size_2)
        {
            SemanticsConstants.Arrays Array = new SemanticsConstants.Arrays();
            Array.setDtype(dtype);
            Array.setId(identifier);
            Array.setIsMulti(isMulti);
            Array.setSize_1(size_1);
            Array.setSize_2(size_2);
            return Array;
        }

        private SemanticsConstants.Objects setObject
        (string identifier, string dtype)
        {
            SemanticsConstants.Objects Object = new SemanticsConstants.Objects();
            Object.setDtype(dtype);
            Object.setId(identifier);
            return Object;
        }

        private SemanticsConstants.Task setTask
        (string identifier, string dtype, int parameters)
        {
            SemanticsConstants.Task Task = new SemanticsConstants.Task();
            Task.setDtype(dtype);
            Task.setId(identifier);
            Task.setParameters(parameters);
            return Task;
        }

        private SemanticsConstants.Index setIndex
        (string identifier, string datatype, int index_1, int index_2, string value)
        {
            SemanticsConstants.Index Index = new SemanticsConstants.Index();
            Index.setId(identifier);
            Index.setDatatype(identifier + "." + datatype);
            Index.setIndex_1(index_1);
            Index.setIndex_2(index_2);
            Index.setValue(value);
            return Index;
        }

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
            return node;
        }
        
        public override void ChildProdProgram(Production node, Node child)
        {
            node.AddChild(child);
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
            SemanticsConstants.Identifiers id = new SemanticsConstants.Identifiers();
            Node GlobalChoice = node;
            
            if (GlobalChoice.GetChildAt(0).GetName() == "Prod_let_global")
            {
                Node Let_Global = GlobalChoice.GetChildAt(0);
                Node valueInfo = Let_Global.GetChildAt(3).GetChildAt(0);
                int idline = Let_Global.GetChildAt(1).GetStartLine();
                int idcol = Let_Global.GetChildAt(1).GetStartColumn();
                Tokens token = GetTokens(idline, idcol);
                string identifier = token.getLexemes();
                string scope = "Global";
                string attrib = "Let";
                string datatype = "";
                string value = valueInfo.GetName();
                switch (value)
                {
                    case "INTLIT":
                        datatype = "Int"; break;
                    case "DOUBLELIT":
                        datatype = "Double"; break;
                    case "STRINGLIT":
                        datatype = "String"; break;
                    case "CHARLIT":
                        datatype = "Char"; break;
                    case "BOOLLIT":
                        datatype = "Boolean"; break;
                }

                Tokens token_value = GetTokens(valueInfo.GetStartLine(), valueInfo.GetStartColumn());
                value = token_value.getLexemes();

                id = setIdentifier(identifier, attrib, datatype, scope, value, idline, token.getLexemes());
                isDeclaredID(id);
            }
            else if (GlobalChoice.GetChildAt(0).GetName() == "Prod_vardec")
            {
                Node vardtype = GlobalChoice.GetChildAt(0).GetChildAt(1);
                int idline = vardtype.GetChildAt(1).GetStartLine();
                int idcol = vardtype.GetChildAt(1).GetStartColumn();
                Tokens token = GetTokens(idline, idcol);
                string identifier = token.getLexemes();
                string datatype = vardtype.GetChildAt(0).GetName();
                string scope = "Global", value = "", attrib = "Variable";
                datatype = getDtype(datatype);

                switch (datatype)
                {
                    case "Int":
                        value = "0"; break;
                    case "Double":
                        value = "0.0"; break;
                    case "String":
                        value = "\"\""; break;
                    case "Char":
                        value = "''"; break;
                    case "Boolean":
                        value = "Yes"; break;
                }

                id = setIdentifier(identifier, attrib, datatype, scope, value, idline, token.getLexemes());
                isDeclaredID(id);
                if(vardtype.GetChildCount() > 2)
                {
                    //If no initialization but has vartail
                    if (vardtype.GetChildAt(2).GetName() == ("Prod_vartail" + datatype.ToUpper()))
                    {
                        hasMULTIID(vardtype.GetChildAt(2), datatype, scope, attrib, value);
                    }
                    //If has initialization and vartail
                    else if (vardtype.GetChildCount() == 4)
                    {
                        hasMULTIID(vardtype.GetChildAt(3), datatype, scope, attrib, value);
                    }
                }
            }
            else if (GlobalChoice.GetChildAt(0).GetName() == "Prod_array")
            {
                SemanticsConstants.Arrays array = new SemanticsConstants.Arrays();
                Node Array = GlobalChoice.GetChildAt(0);
                Node dataInfo = Array.GetChildAt(1);
                string datatype = dataInfo.GetChildAt(0).GetName();
                datatype = getDtype(datatype);
                int dtypeline = dataInfo.GetChildAt(0).GetStartLine();
                int dtypecol = dataInfo.GetChildAt(0).GetStartColumn();
                int idline = dataInfo.GetChildAt(1).GetStartLine();
                int idcol = dataInfo.GetChildAt(1).GetStartColumn();
                string scope = "Global";
                string attrib = "Array";
                Boolean isMulti = false;
                Tokens id_token = GetTokens(idline, idcol);
                Tokens dtype_token = GetTokens(dtypeline, dtypecol);
                Tokens size_1_token = GetTokens(Array.GetChildAt(3).GetStartLine(), Array.GetChildAt(3).GetStartColumn());
                int size_1 = Int32.Parse(size_1_token.getLexemes());
                int size_2 = -1;
                string identifier = id_token.getLexemes();
                if(Array.GetChildCount() > 4)
                {
                    Node size_tail = Array.GetChildAt(4);
                    Tokens size_2_token = GetTokens(size_tail.GetChildAt(1).GetStartLine(), size_tail.GetChildAt(1).GetStartColumn());
                    size_2 = Int32.Parse(size_2_token.getLexemes());
                    isMulti = true;
                }
                id = setIdentifier(identifier, attrib, datatype, scope, "-", idline, id_token.getLexemes());
                Boolean array_add = isDeclaredID(id);
                if(!array_add)
                {
                    array = setArray(identifier, datatype, isMulti, size_1, size_2);
                    Arrays.Add(array);
                    populateArray(identifier, datatype, isMulti, size_1, size_2);
                }
            }
            else if (GlobalChoice.GetChildAt(0).GetName() == "Prod_task")
            {

            }
            else
            {

            }
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
        }

        public override Node ExitProdArray(Production node)
        {
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
            currscope = "Global";
            return node;
        }

        public override void ChildProdObject(Production node, Node child)
        {
            node.AddChild(child);
            if (child.GetName() == "ID")
            {
                Tokens t = new Tokens();
                t = GetTokens(child.GetStartLine(), child.GetStartColumn());
                currscope = "Object." + t.getLexemes();
            }
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
            Node Functions = node;
            string function = Functions.GetChildAt(0).GetName();
            SemanticsConstants.Identifiers id = new SemanticsConstants.Identifiers();
            if (function == "Prod_vardec")
            {
                Node vardtype = Functions.GetChildAt(0).GetChildAt(1);
                int idline = vardtype.GetChildAt(1).GetStartLine();
                int idcol = vardtype.GetChildAt(1).GetStartColumn();
                Tokens token = GetTokens(idline, idcol);
                string identifier = token.getLexemes();
                string datatype = vardtype.GetChildAt(0).GetName();
                string scope = currscope, value = "", attrib = "Variable";
                datatype = getDtype(datatype);

                switch (datatype)
                {
                    case "Int":
                        value = "0"; break;
                    case "Double":
                        value = "0.0"; break;
                    case "String":
                        value = "\"\""; break;
                    case "Char":
                        value = "''"; break;
                    case "Boolean":
                        value = "Yes"; break;
                }


                if (vardtype.GetChildCount() > 2)
                {
                    //If no initialization but has vartail
                    if (vardtype.GetChildAt(2).GetName() == ("Prod_vartail" + datatype.ToUpper()))
                    {
                        id = setIdentifier(identifier, attrib, datatype, scope, value, idline, token.getLexemes());
                        isDeclaredID(id);
                        hasMULTIID(vardtype.GetChildAt(2), datatype, scope, attrib, value);
                    }
                    //If has initialization and vartail
                    else if (vardtype.GetChildCount() == 4)
                    {
                        Node val = null;
                        if (vardtype.GetChildAt(0).GetName() == "BOOLEAN" || vardtype.GetChildAt(0).GetName() == "STRING" || vardtype.GetChildAt(0).GetName() == "CHAR")
                        {
                            val = vardtype.GetChildAt(2).GetChildAt(1).GetChildAt(0);
                        }
                        else
                        {
                            val = vardtype.GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(0);
                        }
                        Tokens valT = GetTokens(val.GetStartLine(), val.GetStartColumn());
                        id = setIdentifier(identifier, attrib, datatype, scope, valT.getLexemes(), idline, token.getLexemes());
                        isDeclaredID(id);
                        hasMULTIID(vardtype.GetChildAt(3), datatype, scope, attrib, value);
                    }
                    else
                    {

                        Node val = null;
                        if(vardtype.GetChildAt(0).GetName() == "BOOLEAN" || vardtype.GetChildAt(0).GetName() == "STRING" || vardtype.GetChildAt(0).GetName() == "CHAR")
                        {
                            val = vardtype.GetChildAt(2).GetChildAt(1).GetChildAt(0);
                        }
                        else
                        {
                            val = vardtype.GetChildAt(2).GetChildAt(1).GetChildAt(0).GetChildAt(0);
                        }
                        Tokens valT = GetTokens(val.GetStartLine(), val.GetStartColumn());
                        id = setIdentifier(identifier, attrib, datatype, scope, valT.getLexemes(), idline, token.getLexemes());
                        isDeclaredID(id);
                    }
                }
                else
                {
                    id = setIdentifier(identifier, attrib, datatype, scope, value, idline, token.getLexemes());
                    isDeclaredID(id);
                }
            }
            else if (function == "Prod_array")
            {
                SemanticsConstants.Arrays array = new SemanticsConstants.Arrays();
                Node Array = Functions.GetChildAt(0);
                Node dataInfo = Array.GetChildAt(1);
                string datatype = dataInfo.GetChildAt(0).GetName();
                datatype = getDtype(datatype);
                int dtypeline = dataInfo.GetChildAt(0).GetStartLine();
                int dtypecol = dataInfo.GetChildAt(0).GetStartColumn();
                int idline = dataInfo.GetChildAt(1).GetStartLine();
                int idcol = dataInfo.GetChildAt(1).GetStartColumn();
                string scope = currscope;
                string attrib = "Array";
                Boolean isMulti = false;
                Tokens id_token = GetTokens(idline, idcol);
                Tokens dtype_token = GetTokens(dtypeline, dtypecol);
                Tokens size_1_token = GetTokens(Array.GetChildAt(3).GetStartLine(), Array.GetChildAt(3).GetStartColumn());
                int size_1 = Int32.Parse(size_1_token.getLexemes());
                int size_2 = -1;
                string identifier = id_token.getLexemes();
                if (Array.GetChildCount() > 4)
                {
                    Node size_tail = Array.GetChildAt(4);
                    Tokens size_2_token = GetTokens(size_tail.GetChildAt(1).GetStartLine(), size_tail.GetChildAt(1).GetStartColumn());
                    size_2 = Int32.Parse(size_2_token.getLexemes());
                    isMulti = true;
                }
                id = setIdentifier(identifier, attrib, datatype, scope, "-", idline, id_token.getLexemes());
                Boolean array_add = isDeclaredID(id);
                if (!array_add)
                {
                    array = setArray(identifier, datatype, isMulti, size_1, size_2);
                    Arrays.Add(array);
                    populateArray(identifier, datatype, isMulti, size_1, size_2);
                }
            }
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

            return node;
        }

        public override void ChildProdIoStatement(Production node, Node child)
        {
            node.AddChild(child);
        }
        
        public override void EnterProdOutputStatement(Production node)
        {
        }

        public override Node ExitProdOutputStatement(Production node)
        {
            return node;
        }

        public override void ChildProdOutputStatement(Production node, Node child)
        {
            node.AddChild(child);
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
        }

        public override Node ExitProdOption(Production node)
        {
            return node;
        }

        public override void ChildProdOption(Production node, Node child)
        {
            node.AddChild(child);
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

        public override Node ExitProdIdStmt(Production node)
        {
            Node ID = node.GetChildAt(0);
            Tokens ident = new Tokens();
            int idline = ID.GetStartLine();
            int idcol = ID.GetStartColumn();
            ident = GetTokens(idline, idcol);
            string dtype = "";
            SemanticsConstants.Identifiers id = new SemanticsConstants.Identifiers();
            foreach (var item in identifiers)
            {
                if (item.getId() == ident.getLexemes())
                {
                    if (currscope == item.getScope())
                    {
                        dtype = item.getDtype();
                    }
                }
            }
            Node id_stmt_tail = node.GetChildAt(1);
            if (id_stmt_tail.GetChildCount() < 3)
            {
                Node initvalues = id_stmt_tail.GetChildAt(1);
                
            }
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
            return node;
        }

        public override void ChildProdMathopNum(Production node, Node child)
        {
            node.AddChild(child);
        }

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
            return node;
        }
        
        public override void ChildProdMathopNumTail(Production node, Node child)
        {
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
            node.AddChild(child);
            if(child.GetName() == "ID")
            {
                int idline = child.GetStartLine();
                int idcol = child.GetStartColumn();
                Tokens token = GetTokens(idline, idcol);
                currscope = "Task." + token.getLexemes();
            }
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
