namespace Automata.DFA;
public class DFADesign
{
    public int StartState { get; set; }
    public List<int> AcceptStates { get; set; }
    public DFARulebook Rulebook { get; set; }
    public DFADesign(int startState, List<int> acceptStates, DFARulebook rulebook)
    {
        StartState = startState;
        AcceptStates = acceptStates;
        Rulebook = rulebook;
    }

    public DFA ToDFA()
    {
        return new DFA(StartState, AcceptStates, Rulebook);
    }

    public bool Accepts(string s)
    {
        DFA dfa = ToDFA();
        dfa.ReadString(s);
        return dfa.Accepting();
    }
}
