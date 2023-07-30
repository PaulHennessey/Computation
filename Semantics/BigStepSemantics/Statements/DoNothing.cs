namespace Semantics.BigStepSemantics;

public class DoNothing : Statement
{
    public override string ToString()
    {
        return "do-nothing";
    }

    public override void Evaluate(Environment environment)
    {}
}