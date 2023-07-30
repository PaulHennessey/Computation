namespace Semantics.SmallStepSemantics;
public abstract class Statement : Rule
{
    public abstract Statement Reduce(Environment environment);
}
