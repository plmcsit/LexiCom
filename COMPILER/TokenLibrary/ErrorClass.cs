using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TokenLibrary
{
    public class ErrorClass
    {
        int lines;
        int column;
        string type;
        string ErrorMessage;
        
        public void setErrorMessage(string ErrorMessage)
        {
            this.ErrorMessage = ErrorMessage;
        }
        public string getErrorMessage()
        {
            return this.ErrorMessage;
        }
        public void setLines(int line)
        {
            this.lines = line;
        }
        public int getLines()
        {
            return this.lines;
        }
        public void setColumn(int column)
        {
            this.column = column;
        }
        public int getColumn()
        {
            return this.column;
        }

        public void setType(string type)
        {
            this.type = type;
        }
        public string getType()
        {
            return this.type;
        }
    }
}
