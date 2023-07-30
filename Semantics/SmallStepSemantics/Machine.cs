namespace Semantics.SmallStepSemantics;

// The job of the machine is to repeatedly call Reducible() and Reduce() on an expression until it can no longer be reduced. 
public class Machine
{
    Expression? Expression { get; set; }
    Statement? Statement { get; set; }
    public Environment? Environment { get; set; }

    public Machine(Expression expression)
    {
        Expression = expression;
    }

    public Machine(Expression expression, Environment environment)
    {
        Expression = expression;
        Environment = environment;
    }

    public Machine(Statement statement, Environment environment)
    {
        Statement = statement;
        Environment = environment;
    }

    public void RunStatement()
    {        
        while(Statement.Reducible())
        {
            DisplayStatement();
            Statement = Statement.Reduce(Environment);
        }
        DisplayStatement();
    }

    public Expression RunExpression()
    {
        while(Expression.Reducible())
        {
            Console.WriteLine(Expression);
            Expression = Expression.Reduce(Environment);
        }
        Console.WriteLine(Expression);
        return Expression;
    }

    private void DisplayStatement()
    {
        Console.Write($"{Statement}, ");
        Environment.Display();
    }
}