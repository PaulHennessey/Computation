namespace Semantics.SmallStepSemantics;

public class Sequence : Statement
{
    public Statement First { get; set; }
    public Statement Second { get; set; }
    
    public Sequence(Statement first, Statement second)
    {
        First = first;
        Second = second;
    }

    public override bool Reducible()
    {
        return true;
    }

    public override string ToString()
    {
        return $"{First}; {Second}";
    }

    public override Statement Reduce(Environment environment)
    {
        if(First is DoNothing)
        {
            return Second;
        }
        else
        {   
            First = First.Reduce(environment);
            return new Sequence(First, Second);
        }
    }
}