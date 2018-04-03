namespace CAGameLife
{
    public class LiveGrid
    {
        public LiveState[,] CurrentState;
        private LiveState[,] nextState;

        // Живая сетка
        public LiveGrid()
        {
            CurrentState = new LiveState[5, 5];
            nextState = new LiveState[5, 5];

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    CurrentState[i, j] = LiveState.Dead;
                }
            }
        }

        //Обновляем состояние
        public void UpdateState()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var liveNeighbors = GetLiveNeighbors(i, j);
                    nextState[i, j] = Rules.GetNewState(CurrentState[i, j], liveNeighbors);
                }
            }

            CurrentState = nextState;
            nextState = new LiveState[5, 5];
        }

        //Получаем живых соседей
        private int GetLiveNeighbors(int positionX, int positionY)
        {
            int liveNeighbors = 0;
            for (int i = -1; i <= 1; i++)
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int neighborX = positionX + i;
                    int neighborY = positionY + j;

                    if (neighborX >= 0 && neighborX < 5 && neighborY >= 0 && neighborY < 5)
                    {
                        if (CurrentState[neighborX, neighborY] == LiveState.Alive)
                            liveNeighbors++;
                    }
                }

            return liveNeighbors;
        }
    }
}
