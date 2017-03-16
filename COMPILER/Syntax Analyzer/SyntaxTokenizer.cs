using System.IO;

using Core.Library;

namespace Syntax_Analyzer {

    /**
     * <remarks>A character stream tokenizer.</remarks>
     */
    public class SyntaxTokenizer : Tokenizer {

        /**
         * <summary>Creates a new tokenizer for the specified input
         * stream.</summary>
         *
         * <param name='input'>the input stream to read</param>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        public SyntaxTokenizer(TextReader input)
            : base(input, false) {

            CreatePatterns();
        }

        /**
         * <summary>Initializes the tokenizer by creating all the token
         * patterns.</summary>
         *
         * <exception cref='ParserCreationException'>if the tokenizer
         * couldn't be initialized correctly</exception>
         */
        private void CreatePatterns() {
            TokenPattern  pattern;

            pattern = new TokenPattern((int) SyntaxConstants.TASK,
                                       "TASK",
                                       TokenPattern.PatternType.STRING,
                                       "Task");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LEAD,
                                       "LEAD",
                                       TokenPattern.PatternType.STRING,
                                       "Lead");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.START,
                                       "START",
                                       TokenPattern.PatternType.STRING,
                                       "Start");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.END,
                                       "END",
                                       TokenPattern.PatternType.STRING,
                                       "End");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.VAR,
                                       "VAR",
                                       TokenPattern.PatternType.STRING,
                                       "Var");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ID,
                                       "ID",
                                       TokenPattern.PatternType.STRING,
                                       "id");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.AS,
                                       "AS",
                                       TokenPattern.PatternType.STRING,
                                       "as");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LET,
                                       "LET",
                                       TokenPattern.PatternType.STRING,
                                       "Let");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OBJECT,
                                       "OBJECT",
                                       TokenPattern.PatternType.STRING,
                                       "Object");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OF,
                                       "OF",
                                       TokenPattern.PatternType.STRING,
                                       "of");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.BY,
                                       "BY",
                                       TokenPattern.PatternType.STRING,
                                       "by");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.IS,
                                       "IS",
                                       TokenPattern.PatternType.STRING,
                                       "is");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CLEAR,
                                       "CLEAR",
                                       TokenPattern.PatternType.STRING,
                                       "Clear");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.READ,
                                       "READ",
                                       TokenPattern.PatternType.STRING,
                                       "Read");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.SAY,
                                       "SAY",
                                       TokenPattern.PatternType.STRING,
                                       "Say");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.SKIP,
                                       "SKIP",
                                       TokenPattern.PatternType.STRING,
                                       "Skip");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.STOP,
                                       "STOP",
                                       TokenPattern.PatternType.STRING,
                                       "Stop");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.IF,
                                       "IF",
                                       TokenPattern.PatternType.STRING,
                                       "If");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OR,
                                       "OR",
                                       TokenPattern.PatternType.STRING,
                                       "Or");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OTHERWISE,
                                       "OTHERWISE",
                                       TokenPattern.PatternType.STRING,
                                       "Otherwise");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OPTION,
                                       "OPTION",
                                       TokenPattern.PatternType.STRING,
                                       "Option");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.STATE,
                                       "STATE",
                                       TokenPattern.PatternType.STRING,
                                       "State");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DEFAULT,
                                       "DEFAULT",
                                       TokenPattern.PatternType.STRING,
                                       "Default");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.UNTIL,
                                       "UNTIL",
                                       TokenPattern.PatternType.STRING,
                                       "Until");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LOOP,
                                       "LOOP",
                                       TokenPattern.PatternType.STRING,
                                       "Loop");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LOOPIF,
                                       "LOOPIF",
                                       TokenPattern.PatternType.STRING,
                                       "LoopIf");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DO,
                                       "DO",
                                       TokenPattern.PatternType.STRING,
                                       "Do");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.FOR,
                                       "FOR",
                                       TokenPattern.PatternType.STRING,
                                       "For");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.RESPONSE,
                                       "RESPONSE",
                                       TokenPattern.PatternType.STRING,
                                       "Response");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ENDIF,
                                       "ENDIF",
                                       TokenPattern.PatternType.STRING,
                                       "EndIf");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.INT,
                                       "INT",
                                       TokenPattern.PatternType.STRING,
                                       "Int");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DOUBLE,
                                       "DOUBLE",
                                       TokenPattern.PatternType.STRING,
                                       "Double");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CHAR,
                                       "CHAR",
                                       TokenPattern.PatternType.STRING,
                                       "Char");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.STRING,
                                       "STRING",
                                       TokenPattern.PatternType.STRING,
                                       "String");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NULL,
                                       "NULL",
                                       TokenPattern.PatternType.STRING,
                                       "Null");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ARRAY,
                                       "ARRAY",
                                       TokenPattern.PatternType.STRING,
                                       "Array");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.BOOLEAN,
                                       "BOOLEAN",
                                       TokenPattern.PatternType.STRING,
                                       "Boolean");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.INTLIT,
                                       "INTLIT",
                                       TokenPattern.PatternType.STRING,
                                       "intlit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DOUBLELIT,
                                       "DOUBLELIT",
                                       TokenPattern.PatternType.STRING,
                                       "doublelit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CHARLIT,
                                       "CHARLIT",
                                       TokenPattern.PatternType.STRING,
                                       "charlit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.STRINGLIT,
                                       "STRINGLIT",
                                       TokenPattern.PatternType.STRING,
                                       "stringlit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.BOOLLIT,
                                       "BOOLLIT",
                                       TokenPattern.PatternType.STRING,
                                       "boollit");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.COL,
                                       "COL",
                                       TokenPattern.PatternType.STRING,
                                       ":");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.SEM,
                                       "SEM",
                                       TokenPattern.PatternType.STRING,
                                       ";");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DIE,
                                       "DIE",
                                       TokenPattern.PatternType.STRING,
                                       "#");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.PER,
                                       "PER",
                                       TokenPattern.PatternType.STRING,
                                       ".");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OP,
                                       "OP",
                                       TokenPattern.PatternType.STRING,
                                       "(");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CP,
                                       "CP",
                                       TokenPattern.PatternType.STRING,
                                       ")");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.OB,
                                       "OB",
                                       TokenPattern.PatternType.STRING,
                                       "[");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.CB,
                                       "CB",
                                       TokenPattern.PatternType.STRING,
                                       "]");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ADD,
                                       "ADD",
                                       TokenPattern.PatternType.STRING,
                                       "+");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MIN,
                                       "MIN",
                                       TokenPattern.PatternType.STRING,
                                       "-");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MUL,
                                       "MUL",
                                       TokenPattern.PatternType.STRING,
                                       "*");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DIV,
                                       "DIV",
                                       TokenPattern.PatternType.STRING,
                                       "/");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.MOD,
                                       "MOD",
                                       TokenPattern.PatternType.STRING,
                                       "%");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.INC,
                                       "INC",
                                       TokenPattern.PatternType.STRING,
                                       "++");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.DEC,
                                       "DEC",
                                       TokenPattern.PatternType.STRING,
                                       "--");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.ISEQ,
                                       "ISEQ",
                                       TokenPattern.PatternType.STRING,
                                       "==");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NOTEQ,
                                       "NOTEQ",
                                       TokenPattern.PatternType.STRING,
                                       "!=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GREAT,
                                       "GREAT",
                                       TokenPattern.PatternType.STRING,
                                       ">");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LESS,
                                       "LESS",
                                       TokenPattern.PatternType.STRING,
                                       "<");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LOGAND,
                                       "LOGAND",
                                       TokenPattern.PatternType.STRING,
                                       "&&");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LOGOR,
                                       "LOGOR",
                                       TokenPattern.PatternType.STRING,
                                       "||");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.NOT,
                                       "NOT",
                                       TokenPattern.PatternType.STRING,
                                       "!");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.EQ,
                                       "EQ",
                                       TokenPattern.PatternType.STRING,
                                       "=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.COMMA,
                                       "COMMA",
                                       TokenPattern.PatternType.STRING,
                                       ",");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.AT,
                                       "AT",
                                       TokenPattern.PatternType.STRING,
                                       "@");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.GEQ,
                                       "GEQ",
                                       TokenPattern.PatternType.STRING,
                                       ">=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.LEQ,
                                       "LEQ",
                                       TokenPattern.PatternType.STRING,
                                       "<=");
            AddPattern(pattern);

            pattern = new TokenPattern((int) SyntaxConstants.WHITESPACE,
                                       "WHITESPACE",
                                       TokenPattern.PatternType.REGEXP,
                                       "[ \\t\\n\\r]+");
            pattern.Ignore = true;
            AddPattern(pattern);
        }
    }
}
