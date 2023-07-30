namespace Semantics.DenotationalSemantics;

public class Sequence : Statement
{
    public Statement First { get; }
    public Statement Second { get; }
    
    public Sequence(Statement first, Statement second)
    {
        First = first;
        Second = second;
    }

    public override string ToString()
    {
        return $"{First}; {Second}";
    }

    public override string ToCSharp(Environment e)
    {
        return @"(e, exp) => { exp.Second.ToCSharp(exp.First.ToCSharp(e)) };";
    }
}