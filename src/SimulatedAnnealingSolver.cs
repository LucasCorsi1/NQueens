using System;
using System.Collections.Generic;

namespace NQueensSimulatedAnnealing.src
{
    public static class SimulatedAnnealingSolver
    {

        /*
           annealing = processo de aquecimento de metais, vidros, etc. seguido de resfriamento lento e gradual, com objetivo de tornar o material mais duro;
           simulated =reproduzido por meio de um modelo, simulado;
           scheduling =arranjo de eventos no tempo, escalonamento.
        */

        public static IEnumerable<int> Solve(int nQueens, int maxIterations, double temperature, double variableCoolingFactor)
        {
            var randomState = GenerateHeuristics.GenerateRandomState(nQueens);

            var heuristicCost = GenerateHeuristics.GetHeuristicCost(randomState);
            var count = 0;
            for (var x = 0; x < maxIterations && heuristicCost > 0; x++)
            {
                randomState = MoveQueens(randomState, heuristicCost, temperature);
                heuristicCost = GenerateHeuristics.GetHeuristicCost(randomState);
                temperature = Math.Max(temperature * variableCoolingFactor, 0.01);
                count++;
                Console.WriteLine("Custo da Heuristica : " + heuristicCost);
            }
            Console.WriteLine("Numero de Iterações: " + count);
            return heuristicCost == 0 ? randomState : null;
        }

        private static int[] MoveQueens(int[] randomState, int costToSolverHeuristic, double temperature)
        {
            var random = new Random();
            var randomStateLength = randomState.Length;

            while (true)
            {
                var randomCol = random.Next(randomStateLength);
                var randomRow = random.Next(randomStateLength);
                var temporaryRow = randomState[randomCol];
                randomState[randomCol] = randomRow;

                var heuristicCost = GenerateHeuristics.GetHeuristicCost(randomState);
                if (heuristicCost < costToSolverHeuristic)
                    return randomState;

                var distanceToSolver = costToSolverHeuristic - heuristicCost;
                var probabilityAccepted = Math.Min(1, Math.Exp(distanceToSolver / temperature));

                if (random.NextDouble() < probabilityAccepted)
                    return randomState;

                randomState[randomCol] = temporaryRow;
            }
        }
    }
}