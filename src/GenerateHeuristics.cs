using System;

namespace NQueensSimulatedAnnealing.src
{
    public static class GenerateHeuristics
    {
        private static int[] GenerateStateInitial(int nQueens) => new int[nQueens];

        public static int[] GenerateRandomState(int nQueens) => RandomState(GenerateStateInitial(nQueens));

        private static int[] RandomState(int[] randomState)
        {
            var random = new Random();
            for (var i = 0; i < randomState.Length; i++)
                randomState[i] = random.Next(randomState.Length);

            return randomState;
        }

        public static int GetHeuristicCost(int[] randomState)
        {
            var heuristicCost = 0;
            for (var i = 0; i < randomState.Length; i++)
                for (var j = i + 1; j < randomState.Length; j++)
                    if (randomState[i] == randomState[j] || Math.Abs(randomState[i] - randomState[j]) == j - i)
                        heuristicCost += 1;

            return heuristicCost;
        }
    }
}