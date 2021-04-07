using System;

namespace NQueensSimulatedAnnealing
{
    public static class SolverUtils
    {

        // Generate state that all queens have row # 0
        private static int[] GenerateAllOneState(int n)
        {

            return new int[n];
        }

        // Randomizes state
        private static int[] RandomizeState(int[] r)
        {
            var rnd = new Random();
            for (var i = 0; i < r.Length; i++)
                r[i] = rnd.Next(r.Length);

            return r;
        }

        // generates random initial state
        public static int[] GenerateRandomState(int n)
        {

            return RandomizeState(GenerateAllOneState(n));
        }

        // Returns heuristic cost
        public static int GetHeuristicCost(int[] r)
        {
            var h = 0;

            // increment cost if two queens are in same row or in same diagonal.
            for (var i = 0; i < r.Length; i++)
                for (var j = i + 1; j < r.Length; j++)
                    if (r[i] == r[j] || Math.Abs(r[i] - r[j]) == j - i)
                        h += 1;

            return h;
        }
    }
}