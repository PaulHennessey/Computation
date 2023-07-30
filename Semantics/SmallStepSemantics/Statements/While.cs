namespace Semantics.SmallStepSemantics;

public class While  : Statement
{
    public Expression Condition { get; }
    public Statement Body { get; }
    public While(Expression condition, Statement body)
    {
        Condition = condition;
        Body = body;
    }

    public override bool Reducible()
    {
        return true;
    }

    public override string ToString()
    {
        return $"while ({Condition}) {{ {Body} }}";
    }

    public override Statement Reduce(Environment environment)
    {
        return new If(Condition, new Sequence(Body, this), new DoNothing());
    }
}