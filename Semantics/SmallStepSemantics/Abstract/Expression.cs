namespace Semantics.SmallStepSemantics;
public abstract class Expression : Rule
{
    public abstract Expression Reduce(Environment environment);
}
