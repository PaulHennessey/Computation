namespace Automata.NFA;
public class NFADesign
{
    public int StartState { get; set; }
    public List<int> AcceptStates { get; set; }
    public NFARulebook Rulebook { get; set; }
    public NFADesign(int startState, List<int> acceptStates, NFARulebook rulebook)
    {
        StartState = startState;
        AcceptStates = acceptStates;
        Rulebook = rulebook;
    }

    public NFA ToNFA()
    {
        return new NFA(new List<int>{StartState}, AcceptStates, Rulebook);
    }

    public bool Accepts(string s)
    {
        NFA nfa = ToNFA();
        nfa.ReadString(s);
        return nfa.Accepting();
    }
}
