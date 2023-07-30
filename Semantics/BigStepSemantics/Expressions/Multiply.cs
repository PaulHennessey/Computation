namespace Semantics.BigStepSemantics;

public class Multiply : Expression
{
    Expression Left { get; }
    Expression Right { get; }
    public Multiply(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public override Expression Evaluate(Environment environment)
    {
        if(Left.GetType() != typeof(Number))    
        {
            return new Multiply(Left.Evaluate(environment), Right).Evaluate(environment);
        }
        else if (Right.GetType() != typeof(Number))    
        {
            return new Multiply(Left, Right.Evaluate(environment)).Evaluate(environment);
        }
        else
        {
            Number left = (Number)Left;
            Number right = (Number)Right;
               
            return new Number(left.Value * right.Value);
        }
    }

    public override string ToString()
    {
        return $"{Left} * {Right}";
    }

}
