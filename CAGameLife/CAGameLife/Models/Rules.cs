namespace CAGameLife
{
    // Енамы существующих и умерщих клеток
    public enum LiveState
    {
        Alive,
        Dead,
    }

    public class Rules : LiveGrid
    {
        // Правило для нового состояния
        public static LiveState GetNewState(LiveState currentState, int liveNeighbors)
        {
            switch (currentState)
            {
                case LiveState.Alive:
                    if (liveNeighbors < 2 || liveNeighbors > 3)
                        return LiveState.Dead;
                    break;
                case LiveState.Dead:
                    if (liveNeighbors == 3)
                        return LiveState.Alive;
                    break;
            }
            return currentState;
        }
    }
}
