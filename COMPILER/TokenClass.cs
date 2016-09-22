using System;

public class Tokens
{
    List<string> attributes = new List<string>();
    string tokens;
    string lexemes;
    int lines;
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
    public void addAttributes(string attribute)
    {
        this.attributes.Add(attribute);
    }
    public List<string> getAttributes()
    {
        return this.attributes;
    }

}
