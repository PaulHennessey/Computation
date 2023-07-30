using Semantics.SmallStepSemantics;
using Environment = Semantics.SmallStepSemantics.Environment;

namespace Semantics.SmallStepSemanticsTest;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void TestLessThanExpression()
    {
        var expected = new SmallStepSemantics.Boolean(false);

        Machine machine = new Machine
        (
            new LessThan
            (
                new Number(5),
                new Add
                (
                    new Number(2),
                    new Number(2)
                )
            )
        );

        Assert.AreEqual(expected, machine.RunExpression());
    }    

    [TestMethod]
    public void TestAddExpressionWithVariables()
    {
        var expected = new Number(7);

        Machine machine = new Machine
        (
            new Add
            (
                new Variable("x"),
                new Variable("y")
            ),
            new Environment()
            {
                {"x", new Number(3)},
                {"y", new Number(4)}
            }
        );

        Assert.AreEqual(expected, machine.RunExpression());
    }    

    [TestMethod]
    public void TestAssignStatement()
    {
        var expected = new Environment()
        {
            {"x", new Number(3)}
        };

        Machine machine = new Machine
        (
            new Assign
            (
                "x",
                new Add
                (
                    new Variable("x"),
                    new Number(1)
                )
            ),
            new Environment()
            {
                {"x", new Number(2)}
            }
        );

        machine.RunStatement();
        Assert.IsTrue(expected.SequenceEqual(machine.Environment));
    }    

    [TestMethod]
    public void TestIfStatement()
    {
        var expected = new Environment()
        {
            {"x", new SmallStepSemantics.Boolean(true)},
            {"y", new Number(1)}
        };

        Machine machine = new Machine
        (
            new If
            (
                new Variable("x"),
                new Assign
                (
                    "y",
                    new Number(1)
                ),
                new Assign
                (
                    "y",
                    new Number(2)
                )                
            ),
            new Environment()
            {
                {"x", new SmallStepSemantics.Boolean(true)}
            }
        );

        machine.RunStatement();
        Assert.IsTrue(expected.SequenceEqual(machine.Environment));
    }       


    [TestMethod]
    public void TestSequenceStatement()
    {
        var expected = new Environment()
        {
            {"x", new Number(2)},
            {"y", new Number(5)}
        };

        Machine machine = new Machine
        (
            new Sequence
            (
                new Assign
                (
                    "x",
                    new Add
                    (
                        new Number(1),
                        new Number(1)    
                    )
                ),
                new Assign
                (
                    "y",
                    new Add
                    (
                        new Variable("x"),
                        new Number(3)    
                    )
                )                
            ),
            new Environment()
            {}
        );

        machine.RunStatement();
        Assert.IsTrue(expected.SequenceEqual(machine.Environment));
    }            

    [TestMethod]
    public void TestWhileStatement()
    {
        var expected = new Environment()
        {
            {"x", new Number(9)},
        };

        Machine machine = new Machine
        (
            new While
            (
                new LessThan
                (
                    new Variable("x"),
                    new Number(5)
                ),
                new Assign
                (
                    "x",
                    new Multiply
                    (
                        new Variable("x"),
                        new Number(3)    
                    )
                )                
            ),
            new Environment()
            {
                {"x", new Number(1)}
            }
        );

        machine.RunStatement();
        Assert.IsTrue(expected.SequenceEqual(machine.Environment));
    }                
}