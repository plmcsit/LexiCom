namespace TokenLibrary
{
    public abstract class TokensClass
    {
        int lines;
        string tokens;
        string lexemes;
        string attributes;

        public void setTokens(string token)
        {
            this.tokens = token;
        }
        public string getTokens()
        {
            return this.tokens;
        }
        public void setLexemes(string lexeme)
        {
            this.lexemes = lexeme;
        }
        public string getLexemes()
        {
            return this.lexemes;
        }
        public void setLines(int line)
        {
            this.lines = line;
        }
        public int getLines()
        {
            return this.lines;
        }
        public void setAttributes(string attribute)
        {
            this.attributes = attribute;
        }
        public string getAttributes()
        {
            return this.attributes;
        }
    }
}
