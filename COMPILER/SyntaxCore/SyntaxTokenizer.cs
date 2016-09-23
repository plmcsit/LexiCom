using System.Collections.Generic;
using TokenLibrary;

namespace SyntaxCore
{
    public class Token : TokensClass
    {
        public int code;

        public void setCode(int code)
        {
            this.code = code;
        }
        public int getCode()
        {
            return code;
        }
    }

    public class SyntaxTokenizer
    {
        public List<Token> Tokenizer(List<Token> tokens)
        {
            List<Token> tokencodes = new List<Token>();
            Token tokencode = new Token();
            foreach (Token token in tokens)
            {
                tokencode = new Token();
                tokencode = token;
                switch (token.getTokens())
                {
                    case "Task":
                         tokencode.setCode((int)SyntaxConstants.TASK);
                         tokencodes.Add(tokencode);
                         break;
                    case "Lead":
                         tokencode.setCode((int)SyntaxConstants.LEAD);
                         tokencodes.Add(tokencode);
                        break;
                    case "Start":
                         tokencode.setCode((int)SyntaxConstants.START);
                         tokencodes.Add(tokencode);
                        break;
                    case "End":
                        tokencode.setCode((int)SyntaxConstants.END);
                        tokencodes.Add(tokencode);
                        break;
                    case "Var":
                         tokencode.setCode((int)SyntaxConstants.VAR);
                         tokencodes.Add(tokencode);
                        break;
                    case "id":
                         tokencode.setCode((int)SyntaxConstants.ID);
                         tokencodes.Add(tokencode);
                        break;
                    case "Let":
                         tokencode.setCode((int)SyntaxConstants.LET);
                         tokencodes.Add(tokencode);
                        break;
                    case "Object":
                         tokencode.setCode((int)SyntaxConstants.OBJECT);
                         tokencodes.Add(tokencode);
                        break;
                    case "of":
                         tokencode.setCode((int)SyntaxConstants.OF);
                         tokencodes.Add(tokencode);
                        break;
                    case "by":
                         tokencode.setCode((int)SyntaxConstants.BY);
                         tokencodes.Add(tokencode);
                        break;
                    case "is":
                         tokencode.setCode((int)SyntaxConstants.IS);
                         tokencodes.Add(tokencode);
                        break;
                    case "Clear":
                         tokencode.setCode((int)SyntaxConstants.CLEAR);
                         tokencodes.Add(tokencode);
                        break;
                    case "Read":
                         tokencode.setCode((int)SyntaxConstants.READ);
                         tokencodes.Add(tokencode);
                        break;
                    case "Say":
                         tokencode.setCode((int)SyntaxConstants.SAY);
                         tokencodes.Add(tokencode);
                        break;
                    case "Skip":
                         tokencode.setCode((int)SyntaxConstants.SKIP);
                         tokencodes.Add(tokencode);
                        break;
                    case "Stop":
                         tokencode.setCode((int)SyntaxConstants.STOP);
                         tokencodes.Add(tokencode);
                        break;
                    case "If":
                         tokencode.setCode((int)SyntaxConstants.IF);
                         tokencodes.Add(tokencode);
                        break;
                    case "Or":
                         tokencode.setCode((int)SyntaxConstants.OR);
                         tokencodes.Add(tokencode);
                        break;
                    case "Otherwise":
                         tokencode.setCode((int)SyntaxConstants.OTHERWISE);
                         tokencodes.Add(tokencode);
                        break;
                    case "Option":
                         tokencode.setCode((int)SyntaxConstants.OPTION);
                         tokencodes.Add(tokencode);
                        break;
                    case "State":
                         tokencode.setCode((int)SyntaxConstants.STATE);
                         tokencodes.Add(tokencode);
                        break;
                    case "Default":
                         tokencode.setCode((int)SyntaxConstants.DEFAULT);
                         tokencodes.Add(tokencode);
                        break;
                    case "Until":
                         tokencode.setCode((int)SyntaxConstants.UNTIL);
                         tokencodes.Add(tokencode);
                        break;
                    case "Loop":
                         tokencode.setCode((int)SyntaxConstants.LOOP);
                         tokencodes.Add(tokencode);
                        break;
                    case "LoopIf":
                         tokencode.setCode((int)SyntaxConstants.LOOPIF);
                         tokencodes.Add(tokencode);
                        break;
                    case "Do":
                         tokencode.setCode((int)SyntaxConstants.DO);
                         tokencodes.Add(tokencode);
                        break;
                    case "For":
                         tokencode.setCode((int)SyntaxConstants.FOR);
                         tokencodes.Add(tokencode);
                        break;
                    case "Response":
                         tokencode.setCode((int)SyntaxConstants.RESPONSE);
                         tokencodes.Add(tokencode);
                        break;
                    case "EndIf":
                         tokencode.setCode((int)SyntaxConstants.ENDIF);
                         tokencodes.Add(tokencode);
                        break;
                    case "Int":
                         tokencode.setCode((int)SyntaxConstants.INT);
                         tokencodes.Add(tokencode);
                        break;
                    case "Double":
                         tokencode.setCode((int)SyntaxConstants.DOUBLE);
                         tokencodes.Add(tokencode);
                        break;
                    case "Char":
                         tokencode.setCode((int)SyntaxConstants.CHAR);
                         tokencodes.Add(tokencode);
                        break;
                    case "String":
                         tokencode.setCode((int)SyntaxConstants.STRING);
                         tokencodes.Add(tokencode);
                        break;
                    case "Null":
                         tokencode.setCode((int)SyntaxConstants.NULL);
                         tokencodes.Add(tokencode);
                        break;
                    case "Array":
                         tokencode.setCode((int)SyntaxConstants.ARRAY);
                         tokencodes.Add(tokencode);
                        break;
                    case "Boolean":
                         tokencode.setCode((int)SyntaxConstants.BOOLEAN);
                         tokencodes.Add(tokencode);
                        break;
                    case "intlit":
                         tokencode.setCode((int)SyntaxConstants.INTLIT);
                         tokencodes.Add(tokencode);
                        break;
                    case "doublelit":
                         tokencode.setCode((int)SyntaxConstants.DOUBLELIT);
                         tokencodes.Add(tokencode);
                        break;
                    case "charlit":
                         tokencode.setCode((int)SyntaxConstants.CHARLIT);
                         tokencodes.Add(tokencode);
                        break;
                    case "stringlit":
                         tokencode.setCode((int)SyntaxConstants.STRINGLIT);
                         tokencodes.Add(tokencode);
                        break;
                    case "boollit":
                         tokencode.setCode((int)SyntaxConstants.BOOLLIT);
                         tokencodes.Add(tokencode);
                        break;
                    case ":":
                         tokencode.setCode((int)SyntaxConstants.COL);
                         tokencodes.Add(tokencode);
                        break;
                    case ";":
                         tokencode.setCode((int)SyntaxConstants.SEM);
                         tokencodes.Add(tokencode);
                        break;
                    case "#":
                         tokencode.setCode((int)SyntaxConstants.DIE);
                         tokencodes.Add(tokencode);
                        break;
                    case ".":
                         tokencode.setCode((int)SyntaxConstants.PER);
                         tokencodes.Add(tokencode);
                        break;
                    case "(":
                         tokencode.setCode((int)SyntaxConstants.OP);
                         tokencodes.Add(tokencode);
                        break;
                    case ")":
                         tokencode.setCode((int)SyntaxConstants.CP);
                         tokencodes.Add(tokencode);
                        break;
                    case "{":
                         tokencode.setCode((int)SyntaxConstants.OC);
                         tokencodes.Add(tokencode);
                        break;
                    case "}":
                         tokencode.setCode((int)SyntaxConstants.CC);
                         tokencodes.Add(tokencode);
                        break;
                    case "[":
                         tokencode.setCode((int)SyntaxConstants.OB);
                         tokencodes.Add(tokencode);
                        break;
                    case "]":
                         tokencode.setCode((int)SyntaxConstants.CB);
                         tokencodes.Add(tokencode);
                        break;
                    case "+":
                         tokencode.setCode((int)SyntaxConstants.ADD);
                         tokencodes.Add(tokencode);
                        break;
                    case "-":
                         tokencode.setCode((int)SyntaxConstants.MIN);
                         tokencodes.Add(tokencode);
                        break;
                    case "*":
                         tokencode.setCode((int)SyntaxConstants.MUL);
                         tokencodes.Add(tokencode);
                        break;
                    case "/":
                         tokencode.setCode((int)SyntaxConstants.DIV);
                         tokencodes.Add(tokencode);
                        break;
                    case "%":
                         tokencode.setCode((int)SyntaxConstants.MOD);
                         tokencodes.Add(tokencode);
                        break;
                    case "++":
                         tokencode.setCode((int)SyntaxConstants.INC);
                         tokencodes.Add(tokencode);
                        break;
                    case "--":
                         tokencode.setCode((int)SyntaxConstants.DEC);
                         tokencodes.Add(tokencode);
                        break;
                    case "==":
                         tokencode.setCode((int)SyntaxConstants.ISEQ);
                         tokencodes.Add(tokencode);
                        break;
                    case "!=":
                         tokencode.setCode((int)SyntaxConstants.NOTEQ);
                         tokencodes.Add(tokencode);
                        break;
                    case ">":
                         tokencode.setCode((int)SyntaxConstants.GREAT);
                         tokencodes.Add(tokencode);
                        break;
                    case "<":
                         tokencode.setCode((int)SyntaxConstants.LESS);
                         tokencodes.Add(tokencode);
                        break;
                    case "&&":
                         tokencode.setCode((int)SyntaxConstants.LOGAND);
                         tokencodes.Add(tokencode);
                        break;
                    case "||":
                         tokencode.setCode((int)SyntaxConstants.LOGOR);
                         tokencodes.Add(tokencode);
                        break;
                    case "!":
                         tokencode.setCode((int)SyntaxConstants.NOT);
                         tokencodes.Add(tokencode);
                        break;
                    case "=":
                         tokencode.setCode((int)SyntaxConstants.EQ);
                         tokencodes.Add(tokencode);
                        break;
                    case ",":
                         tokencode.setCode((int)SyntaxConstants.COMMA);
                         tokencodes.Add(tokencode);
                        break;
                    case "@":
                         tokencode.setCode((int)SyntaxConstants.AT);
                         tokencodes.Add(tokencode);
                        break;
                    case ">=":
                         tokencode.setCode((int)SyntaxConstants.GEQ);
                         tokencodes.Add(tokencode);
                        break;
                    case "<=":
                         tokencode.setCode((int)SyntaxConstants.LEQ);
                         tokencodes.Add(tokencode);
                        break;
                }
            }

            return tokencodes;
        }
    }
}
