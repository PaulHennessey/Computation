namespace Semantics.SmallStepSemantics;

public class Multiply : Expression
{
    Expression Left { get; }
    Expression Right { get; }
    public Multiply(Expression left, Expression right)
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
        return $"{Left} * {Right}";
    }

    public override Expression Reduce(Environment environment)
    {
        if(Left.Reducible())
        {
            return new Multiply(Left.Reduce(environment), Right);
        }
        else if(Right.Reducible())
        {
            return new Multiply(Left, Right.Reduce(environment));
        }        
        else
        {
            Number left = (Number)Left;
            Number right = (Number)Right;
            return new Number(left.Value * right.Value);
        }
    }

}
