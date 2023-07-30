using Automata.Common;
using Automata.DFA;

namespace AutomataTest.DFATest;

[TestClass]
public class UnitTest
{
    DFARulebook rulebook = new DFARulebook(
        new List<FARule>()
        {
            new FARule(1, 'a', 2),
            new FARule(2, 'a', 2),
            new FARule(3, 'a', 3),
            new FARule(1, 'b', 1),
            new FARule(2, 'b', 3),
            new FARule(3, 'b', 3)
        }
    );

    [TestMethod]
    public void TestMethod1()
    {        
        Assert.AreEqual(2, rulebook.NextState(1, 'a'));
        Assert.AreEqual(1, rulebook.NextState(1, 'b'));
        Assert.AreEqual(3, rulebook.NextState(2, 'b'));
    }


    [TestMethod]
    public void TestMethod2()
    {        
        Assert.AreEqual(true, new DFA(1, new List<int>{1, 3}, rulebook).Accepting());
        Assert.AreEqual(false, new DFA(1, new List<int>{3}, rulebook).Accepting());
    }

    [TestMethod]
    public void TestMethod3()
    {        
        Assert.AreEqual(true, new DFA(1, new List<int>{1, 3}, rulebook).Accepting());
        Assert.AreEqual(false, new DFA(1, new List<int>{3}, rulebook).Accepting());
    }

    [TestMethod]
    public void TestMethod4()
    {        
        DFA dfa = new DFA(1, new List<int>{3}, rulebook);
        Assert.AreEqual(false, dfa.Accepting());

        dfa.ReadCharacter('b');
        Assert.AreEqual(false, dfa.Accepting());

        dfa.ReadCharacter('a');
        dfa.ReadCharacter('a');
        dfa.ReadCharacter('a');
        Assert.AreEqual(false, dfa.Accepting());

        dfa.ReadCharacter('b');
        Assert.AreEqual(true, dfa.Accepting());
    }

    [TestMethod]
    public void TestMethod5()
    {        
        DFA dfa = new DFA(1, new List<int>{3}, rulebook);
        Assert.AreEqual(false, dfa.Accepting());

        dfa.ReadString("baaab");
        Assert.AreEqual(true, dfa.Accepting());
    }

    [TestMethod]
    public void TestMethod6()
    {        
        DFADesign design = new DFADesign(1, new List<int>{3}, rulebook);

        Assert.AreEqual(false, design.Accepts("a"));
        Assert.AreEqual(false, design.Accepts("baa"));
        Assert.AreEqual(true, design.Accepts("baba"));
    }

}