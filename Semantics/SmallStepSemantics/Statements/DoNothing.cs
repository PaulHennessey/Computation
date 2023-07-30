namespace Semantics.SmallStepSemantics;

public class DoNothing : Statement
{
    public override bool Reducible()
    {
        return false;
    }

    public override string ToString()
    {
        return "do-nothing";
    }

    public override Statement Reduce(Environment environment)
    {
        return null;
    }
}