namespace Semantics.BigStepSemantics;

public class While  : Statement
{
    public Expression Condition { get; }
    public Statement Body { get; }
    public While(Expression condition, Statement body)
    {
        Condition = condition;
        Body = body;
    }

    public override string ToString()
    {
        return $"while ({Condition}) {{ {Body} }}";
    }

    public override void Evaluate(Environment environment)
    {
        Boolean condition = (Boolean)Condition.Evaluate(environment);
        if(condition.Value)
        {
            Body.Evaluate(environment);
            this.Evaluate(environment);
        }
    }
}