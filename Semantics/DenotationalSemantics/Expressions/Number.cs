namespace Semantics.DenotationalSemantics;

public class Number : Expression
{
    public int Value { get; }
    public Number(int value)
    {
        Value = value;
    }
    public override string ToCSharp(Environment e)
    {
        return "(e, n) => {return n.Value;}";
    }
}   