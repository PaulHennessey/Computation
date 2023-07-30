namespace Semantics.SmallStepSemantics;

public class GreaterThan : Expression
{
    Expression Left { get; }
    Expression Right { get; }
    public GreaterThan(Expression left, Expression right)
    {
        Left = left;
        Right = right;
    }

    public override bool Reducible()
    {
        return true;
    }

    public override string ToString()
    {
        return $"{Left} > {Right}";
    }

    public override Expression Reduce(Environment environment)
    {
        if(Left.Reducible())
        {
            return new LessThan(Left.Reduce(environment), Right);
        }
        else if(Right.Reducible())
        {
            return new LessThan(Left, Right.Reduce(environment));
        }        
        else
        {
            Number left = (Number)Left;
            Number right = (Number)Right;
            return new Boolean(left.Value > right.Value);
        }
    }

}
