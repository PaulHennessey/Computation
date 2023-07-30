namespace Semantics.DenotationalSemantics;

public class Boolean : Expression
{
    public bool Value { get; }
    public Boolean(bool value)
    {
        Value = value;
    }
    public override string ToCSharp(Environment e)
    {
        return "(e, b) => {return b.Value;}";
    }
}   