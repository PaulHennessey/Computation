namespace Semantics.SmallStepSemantics;
public class Boolean : Expression
{
    public bool Value { get; }
    public Boolean(bool value)
    {
        Value = value;
    }

    public override bool Reducible()
    {
        return false;
    }

    public override bool Equals(Object obj)
    {
        if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else {
            Boolean b = (Boolean) obj;
            return (Value == b.Value);
        }
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return Value.ToString();
    }

    public override Expression Reduce(Environment environment)
    {
        return this;
    }

}
