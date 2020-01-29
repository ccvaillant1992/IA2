<<<<<<< HEAD
using System;

namespace iac
{
    public class Individuo{

    private int[] solution { get; set; } //vector solucion
    private int[] mejorSolution;
    private int fitness;
   public Individuo(int tamaño)
   {
       fitness=0;
       solution=new int[tamaño];
       fitness=0;
      
   }

        public int[] GetobtenerSolucion => solution;

        public int tamañoSolution
        {
            get
            {
                return solution.Length();
            }
        }
        public int obtenerFitness() => fitness;
        
        public void generateSolution()
   {//seudocodigo 5.1.2 Calcular coste de cada individuo
       initializeSolution();
       for (int i = 0; i < tamañoSolution; i++)
       {
            for (int j = 0; j < tamañoSolution; j++)
            {
                int pos=new Random().Next( 0, count-1 );//x = generar numero aleatorio
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
            for (int j = 0; j < count; j++)
            {
                if(i!=j)
                {
                    weight+=Matrices.getweights[i,j]*Matrices.getdistance[solution[i],solution[j]];
                }
            }
       }
   }

   private void initializeMatrix(int i,int j){
        Random rand=new Random();
        Matrices.getweights[i,j]=rand.Next(0,100);//valor de peso aleatorio
        Matrices.getdistance[i,j]=rand.Next(0,100);//valor de distancia aleatoria
   }
   
     private void updateWeight(int pos1, int pos2, int[] oldSolution){
        
       //seudocodigo  Actualizar el coste de cada individuo
        for (int i = 0; i < Matrices.getlocations; i++)
        {
           
             weight-= Matrices.getweights[pos1,i]*Matrices.getdistance[oldsolution[pos1],oldsolution[i]];
             weight+= Matrices.getweights[pos1,i]*Matrices.getdistance[solution[pos1],solution[i]];

             weight-= Matrices.getweights[pos2,i]*Matrices.getdistance[oldsolution[pos2],oldsolution[i]];
             weight+= Matrices.getweights[pos2,i]*Matrices.getdistance[solution[pos2],solution[k]];
          

           if(i!=pos1 && i!=pos2){
             weight-= Matrices.getweights[i,pos1]*Matrices.getdistance[oldsolution[i],oldsolution[pos1]];
             weight+= Matrices.getweights[i,pos1]*Matrices.getdistance[solution[i],solution[pos1]];

             weight-= Matrices.getweights[i,pos2]*Matrices.getdistance[oldsolution[i],oldsolution[pos2]];
             weight+= Matrices.getweights[i,pos2]*Matrices.getdistance[solution[i],solution[pos2]];
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
=======
using System;

namespace iac
{
    public class Individuo{

    public int[] solution { get; set; } //vector solucion
    public int count { get; set; }//cantidad de fabricas y posiciones (n)

    public int weight { get; set; }//peso de la solucion

    private int[,] weights ;//matriz de flujo entre las fabricas
    private int[,] distance;//matriz de distancias entre las posiciones
   
   public Individuo(int pcount)
   {
       weight=0;
       count=pcount;
       solution=new int[pcount];
       weights=new int[pcount,pcount];
       distance=new int[pcount,pcount];
       generateSolution();//generamos el vector solucion
       calculateweight();//calculamos el peso de nuestra solucion
   }

   private void generateSolution()
   {//seudocodigo 5.1.2 Calcular coste de cada individuo
       initializeSolution();
       for (int i = 0; i < count; i++)
       {
            for (int j = 0; j < count; j++)
            {
                int pos=new Random().Next( 0, count-1 );//x = generar numero aleatorio
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
       for (int i = 0; i < count; i++)
           solution[i]=i;
   }

   public void calculateweight(){
       //seudocodigo 5.1.2 Calcular coste de cada individuo
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < count; j++)
            {
                if(i!=j)
                {
                    weight+=weights[i,j]*distance[solution[i],solution[j]];
                }
            }
       }
   }

   private void initializeMatrix(int i,int j){
        Random rand=new Random();
        weights[i,j]=rand.Next(0,100);//valor de peso aleatorio
        distance[i,j]=rand.Next(0,100);//valor de distancia aleatoria
   }
   
     public void updateWeight(int pos1, int pos2){
        weight=0;
       //seudocodigo  Actualizar el coste de cada individuo
        for (int i = 0; i < count; i++)
        {
           if(i!=pos1 && i!=pos2){
             weight+= weights[pos1,i]*distance[solution[pos2],solution[i]] - distance [solution[pos1],solution[i]];
             weight+= weights[pos2,i]*distance[solution[pos1],solution[i]] - distance [solution[pos2],solution[i]];

             weight+= weights[i,pos1]*distance[solution[i],solution[pos2]] - distance [solution[i],solution[pos1]];
             weight+= weights[i,pos2]*distance[solution[i],solution[pos1]] - distance [solution[i],solution[pos2]];
           }

       }
   }

        private static void obtenerSolucion()
        {
            return solution; 
        }



    }
}
>>>>>>> 885ce6df3a5824ee99f50d739bb39f20094757d2
