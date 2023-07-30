namespace Semantics.BigStepSemantics;

public class LessThan : Expression
{
    Expression Left { get; }
    Expression Right { get; }
    public LessThan(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public override Expression Evaluate(Environment environment)
    {
        if(Left.GetType() != typeof(Number))    
        {
            return new LessThan(Left.Evaluate(environment), Right).Evaluate(environment);
        }
        else if (Right.GetType() != typeof(Number))    
        {
            return new LessThan(Left, Right.Evaluate(environment)).Evaluate(environment);
        }
        else
        {
            Number left = (Number)Left;
            Number right = (Number)Right;        
            return new Boolean(left.Value < right.Value);
        }
    }

    public override string ToString()
    {
        return $"{Left} < {Right}";
    }
}
