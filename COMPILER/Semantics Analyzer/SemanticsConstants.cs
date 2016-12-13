namespace Semantics_Analyzer
{
    public class SemanticsConstants
    {
        //Identifier Structure
        public class Identifiers
        {
            string id;
            int lines;
            string attrib;
            string dtype;
            string scope;
            string value;
            string tokens;
            
            //SETS
            public void setId(string id)
            {
                this.id = id;
            }
            public void setLines(int lines)
            {
                this.lines = lines;
            }
            public void setAttrib(string attrib)
            {
                this.attrib = attrib;
            }
            public void setDtype(string dtype)
            {
                this.dtype = dtype;
            }
            public void setScope(string scope)
            {
                this.scope = scope;
            }
            public void setValue(string value)
            {
                this.value = value;
            }
            public void setTokens(string tokens)
            {
                this.tokens = tokens;
            }
            //GETS
            public string getId()
            {
                return this.id;
            }
            public int getLines()
            {
                return this.lines;
            }
            public string getAttrib()
            {
                return this.attrib;
            }
            public string getDtype()
            {
                return this.dtype;
            }
            public string getScope()
            {
                return this.scope;
            }
            public string getValue()
            {
                return this.value;
            }
            public string getTokens()
            {
                return this.tokens;
            }
        }
        public class Objects
        {
            public string id;
            public string dtype;

            //SETS
            public void setId(string id)
            {
                this.id = id;
            }
            public void setDtype(string dtype)
            {
                this.dtype = dtype;
            }
            //GETS
            public string getId()
            {
                return this.id;
            }
            public string getDtype()
            {
                return this.dtype;
            }
        }
        public class Arrays
        {
            public string id;
            public string dtype;
            public bool isMulti;
            public int size_1;
            public int size_2 = -1;

            //SETS
            public void setId(string id)
            {
                this.id = id;
            }
            public void setDtype(string dtype)
            {
                this.dtype = dtype;
            }
            public void setIsMulti(bool isMulti)
            {
                this.isMulti = isMulti;
            }
            public void setSize_1(int size_1)
            {
                this.size_1 = size_1;
            }
            public void setSize_2(int size_2)
            {
                this.size_2 = size_2;
            }
            //GETS
            public string getId()
            {
                return this.id;
            }
            public string getDtype()
            {
                return this.dtype;
            }
            public bool getIsMulti()
            {
                return this.isMulti;
            }
            public int getSize_1()
            {
                return this.size_1;
            }
            public int getSize_2()
            {
                return this.size_2;
            }
        }
        public class Index
        {
            public string id;
            public string value;
            public string datatype;
            public int index_1;
            public int index_2 = -1;

            //SETS
            public void setId(string id)
            {
                this.id = id;
            }
            public void setValue(string value)
            {
                this.value = value;
            }
            public void setDatatype(string datatype)
            {
                this.datatype = datatype;
            }
            public void setIndex_1(int index_1)
            {
                this.index_1 = index_1;
            }
            public void setIndex_2(int index_2)
            {
                this.index_2 = index_2;
            }
            //GETS
            public string getId()
            {
                return this.id;
            }
            public string getValue()
            {
                return this.value;
            }
            public string getDatatype()
            {
                return this.datatype;
            }
            public int getIndex_1()
            {
                return this.index_1;
            }
            public int getIndex_2()
            {
                return this.index_2;
            }
        }
        public class Task
        {
            public string id;
            public string dtype;
            public int parameters;

            //SETS
            public void setId(string id)
            {
                this.id = id;
            }
            public void setDtype(string dtype)
            {
                this.dtype = dtype;
            }
            public void setParameters(int parameters)
            {
                this.parameters = parameters;
            }
            //GETS
            public string getId()
            {
                return this.id;
            }
            public string getDtype()
            {
                return this.dtype;
            }
            public int getParamters()
            {
                return this.parameters;
            }
        }
    }
}
