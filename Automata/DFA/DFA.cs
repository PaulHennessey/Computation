namespace Automata.DFA;
public class DFA
{
    public int CurrentState { get; set; }
    public List<int> AcceptStates { get; set; }
    public DFARulebook Rulebook { get; set; }
    public DFA(int currentState, List<int> acceptStates, DFARulebook rulebook)
    {
        CurrentState = currentState;
        AcceptStates = acceptStates;
        Rulebook = rulebook;
    }

    public bool Accepting()
    {
        return AcceptStates.Contains(CurrentState);
    }

    public void ReadCharacter(char c)
    {
        CurrentState = Rulebook.NextState(CurrentState, c);
    }

    public void ReadString(string s)
    {
        foreach(char c in s)
            ReadCharacter(c);
    }    
}
