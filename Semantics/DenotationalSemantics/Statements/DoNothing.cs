namespace Semantics.DenotationalSemantics;

public class DoNothing : Statement
{
    public DoNothing()
    {}

    public override string ToString()
    {
        return "do-nothing";
    }

    public override string ToCSharp(Environment e)
    {
        return "(e, exp) => e;";
    }
}
