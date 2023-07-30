namespace Semantics.BigStepSemantics;
public abstract class Expression
{
    public abstract Expression Evaluate(Environment environment);
}
