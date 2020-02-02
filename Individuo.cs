using System;

namespace iac
{
    public class Individuo
    {

        public int[] solution { get; set; } //vector solucion
        private const int V = 0;
        private int[] mejorSolution;  //vector con la mejor solucion
        private int fitness;  //Peso de la solucion 


        public Individuo(int tamaño)  //Constructor que recibe el tamaño del vector como parametro
        {
            fitness = 0;
            solution = new int[tamaño];
        }
        public Individuo(Individuo individuo) //Otro constructor que recibe un individuo como parametro 
        {
            solution = new int[individuo.solution.Length];
            individuo.solution.CopyTo(solution, 0);
            fitness = individuo.fitness;
        }

        public int[] obtenerSolucion => solution; //Obtener la solucion de un individuo

        public int tamañoSolution => solution.Length;  //Obtener el tamaño del arreglo solución

        public int obtenerFitness() => fitness;  //Obtener el pesoF

        private void solucionAleatoria()
        {

            for (int i = 0; i < tamañoSolution; i++)
            {
                int pos = new Random().Next(0, tamañoSolution - 1); //x = generar numero aleatorio
                int pivot = solution[i];   //{ IntercambiarPosicionVector(i,x)
                int aux = solution[pos];
                solution[i] = aux;
                solution[pos] = pivot;//}
            }
        }

        private void calculateFitness()   //Calcular coste de cada individuo
        {
          fitness=0;
            for (int i = 0; i < tamañoSolution; i++)
            {
                for (int j = 0; j < tamañoSolution; j++)
                {
                        fitness += Matrices.getweights[i][j] * Matrices.getdistance[solution[i]][solution[j]];
                }
            }
        }

        public void generateSolution()
        {
            for (int i = 0; i < tamañoSolution; i++)
            {
                solution[i] = i;
            }
            solucionAleatoria();

            calculateFitness();
        }

        public int[] busquedaLocal()
        {
            Individuo mejor;
            Individuo S = new Individuo(this);
            S.calculateFitness();
            do
            {
                mejor = new Individuo(S); // save best solution by now
                for (int i = 0; i < tamañoSolution; i++)
                {
                    for (int j = i + 1; j < tamañoSolution; j++)
                    {
                        // Create T exchanging i and j gene
                        Individuo T = new Individuo(S);
                        T.solution[i] = S.solution[j];
                        T.solution[j] = S.solution[i];
                        T.updateWeight(i, j, S.obtenerSolucion); // calculate fitness of new solution
                        if (T.obtenerFitness() < S.obtenerFitness())
                        { // if new solution is better than older updates
                            S = new Individuo(T);
                        }
                    }
                }
            } while (S.obtenerFitness() < mejor.obtenerFitness());
            return S.obtenerSolucion;
        }

        public void calcularMejorfitness(algoritmoGenetico tipo)
        {
            if (tipo == algoritmoGenetico.baldwiniana || tipo == algoritmoGenetico.lamarckiana)
            {
                if (mejorSolution == null)
                {
                    mejorSolution = busquedaLocal();
                    if (tipo == algoritmoGenetico.lamarckiana)
                    {
                        solution = mejorSolution;
                    }
                }
                fitness = V;
                for (int i = 0; i < Matrices.getlocations; i++)
                {
                    for (int j = 0; j < Matrices.getlocations; j++)
                    {
                        fitness += Matrices.getweights[i][j] * Matrices.getdistance[mejorSolution[i]][mejorSolution[j]];
                    }
                }
            }
            else
            {
                calculateFitness();
            }
        }

        private void updateWeight(int pos1, int pos2, int[] oldSolution)   //Actualizar el coste de cada individuo
        {
            fitness = 0;

            for (int i = 0; i < Matrices.getlocations; i++)
            {

                fitness -= Matrices.getweights[pos1][i] * Matrices.getdistance[oldSolution[pos1]][oldSolution[i]];
                fitness += Matrices.getweights[pos1][i] * Matrices.getdistance[solution[pos1]][solution[i]];

                fitness -= Matrices.getweights[pos2][i] * Matrices.getdistance[oldSolution[pos2]][oldSolution[i]];
                fitness += Matrices.getweights[pos2][i] * Matrices.getdistance[solution[pos2]][solution[i]];


                if (i != pos1 && i != pos2)
                {
                    fitness -= Matrices.getweights[i][pos1] * Matrices.getdistance[oldSolution[i]][oldSolution[pos1]];
                    fitness += Matrices.getweights[i][pos1] * Matrices.getdistance[solution[i]][solution[pos1]];

                    fitness -= Matrices.getweights[i][pos2] * Matrices.getdistance[oldSolution[i]][oldSolution[pos2]];
                    fitness += Matrices.getweights[i][pos2] * Matrices.getdistance[solution[i]][solution[pos2]];
                }

            }
        }

        public void mutate(int pos1, int pos2)
        {
            int swap = solution[pos1];
            solution[pos1] = solution[pos2];
            solution[pos2] = swap;
        }
    }
}