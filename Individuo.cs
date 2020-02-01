using System;

namespace iac
{
    public class Individuo{

        public int[] solution { get; set; } //vector solucion

        private const int V = 0;
        private int[] mejorSolution;
        private int fitness;
        private Individuo individuo;

        public Individuo(int tamaño)
      {
       fitness=0;
       solution=new int[tamaño];
  
      }
        public Individuo(Individuo individuo)
        {
            solution=new int[individuo.solution.Length];
            individuo.solution.CopyTo(solution,0);
            fitness=individuo.fitness;
        }

        public int[] obtenerSolucion => solution;

        public void setValueIndex(int index,int value){
            solution[index]=value;
        }

        public int tamañoSolution
        {
            get
            {
                return NewMethod();

                int NewMethod()
                {
                    return solution.Length;
                }
            }
        }
        public int obtenerFitness() => fitness;

        public int[] busquedaLocal() {
        Individuo mejor;
        Individuo S = new Individuo(solution.Length);
        S.generateSolution();
        do {
            mejor = new Individuo(S); // save best solution by now
               
                for (int i = 0; i < tamañoSolution; i++) {
                for (int j = i + 1; j < tamañoSolution; j++) {
                    // Create T exchanging i and j gene
                    Individuo T = new Individuo(solution.Length);
                    T.solution[i]=S.solution[j];
                    T.solution[j]=S.solution[i];
                    T.updateWeight(i, j, S.obtenerSolucion); // calculate fitness of new solution
                    if (T.obtenerFitness() < S.obtenerFitness()) { // if new solution is better than older updates
                        S = new Individuo(T);
                    }
                }
            }
        } while (S.obtenerFitness() < mejor.obtenerFitness());
        return S.obtenerSolucion;
    }

        
        public void generateSolution()
       {//Calcular coste de cada individuo
          initializeSolution();
          for (int i = 0; i < tamañoSolution; i++)
          {
            for (int j = 0; j < tamañoSolution; j++)
            {
                int pos=new Random().Next( 0, tamañoSolution-1 );//x = generar numero aleatorio
                int pivot=solution[i];//{ IntercambiarPosicionVector(i,x)
                int aux=solution[pos];
                solution[i]=aux;
                solution[pos]=pivot;//}
                initializeMatrix(i,j);//aqui aprovecho el doble for para rellenar las matrices
            }
         }
       }

   private void initializeSolution()
   {//relleno el vector solucion comenzando en 0 hasta n-1
       for (int i = 0; i < tamañoSolution; i++)
           solution[i]=i;
   }

   public void calculateweight(){    
       //seudocodigo 5.1.2 Calcular coste de cada individuo
        for (int i = 0; i < tamañoSolution; i++)
        {
            for (int j = 0; j < tamañoSolution; j++)
            {
                if(i!=j)
                {
                    fitness+=Matrices.getweights[i][j]*Matrices.getdistance[solution[i]][solution[j]];
                }
            }
       }
   }

      public void calcularMejorfitness(algoritmoGenetico tipo)
       {
        if (tipo == algoritmoGenetico.baldwiniana || tipo == algoritmoGenetico.lamarckiana) {
            if (mejorSolution == null) {
                mejorSolution = busquedaLocal();
                if (tipo == algoritmoGenetico.lamarckiana) {
                    solution = mejorSolution;
                }
            }
            fitness = V;
            for (int i = 0; i < Matrices.getlocations; i++) {
                for (int j = 0; j < Matrices.getlocations; j++) {
                    fitness += Matrices.getweights[i][j] * Matrices.getdistance[mejorSolution[i]][mejorSolution[j]];
                }
            }
        } else {
            generateSolution();
        }
    }


        private void initializeMatrix(int i,int j){
        Random rand=new Random();
        Matrices.getweights[i][j]=rand.Next(0,100);//valor de peso aleatorio
        Matrices.getdistance[i][j]=rand.Next(0,100);//valor de distancia aleatoria
   }
   
     private void updateWeight(int pos1, int pos2, int[] oldSolution){
        fitness=0;
       //seudocodigo  Actualizar el coste de cada individuo
        for (int i = 0; i < Matrices.getlocations; i++)
        {
           
             fitness-= Matrices.getweights[pos1][i]*Matrices.getdistance[oldSolution[pos1]][oldSolution[i]];
             fitness+= Matrices.getweights[pos1][i]*Matrices.getdistance[solution[pos1]][solution[i]];

             fitness-= Matrices.getweights[pos2][i]*Matrices.getdistance[oldSolution[pos2]][oldSolution[i]];
            fitness+= Matrices.getweights[pos2][i]*Matrices.getdistance[solution[pos2]][solution[i]];
          

           if(i!=pos1 && i!=pos2){
             fitness-= Matrices.getweights[i][pos1]*Matrices.getdistance[oldSolution[i]][oldSolution[pos1]];
             fitness+= Matrices.getweights[i][pos1]*Matrices.getdistance[solution[i]][solution[pos1]];

             fitness-= Matrices.getweights[i][pos2]*Matrices.getdistance[oldSolution[i]][oldSolution[pos2]];
             fitness+= Matrices.getweights[i][pos2]*Matrices.getdistance[solution[i]][solution[pos2]];
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
