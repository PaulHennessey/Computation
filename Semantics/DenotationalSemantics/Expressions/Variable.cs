namespace Semantics.DenotationalSemantics;

public class Variable : Expression
{
    public string Name { get; }
    public Variable(string name)
    {
        Name = name;
    }

    public override string ToString()
    {
        return Name.ToString();
    }

    public override string ToCSharp(Environment e)
    {
        return "(e, v) => {return e[v.Name];}";
    }
}   