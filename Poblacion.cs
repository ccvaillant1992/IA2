<<<<<<< HEAD
namespace iac
{
    public class Poblacion{

        private Individuo[] poblacion;  //crear la poblacion de individuos
       
        public Poblacion(int tamaño)   //constructor de la poblacion 
        {
            poblacion=new Individuo[tamaño];
        }

         public Individuo[] obtnerPoblacion(){    //Obtener la poblacion 
            return poblacion;
        }

        public void generarPoblacion(int tamaño){           //generar una poblacion de individuos al azar
            for (int i = 0; i < poblacion.Length; i++)
            {
                poblacion[i]=new Individuo(tamaño);
            }
        }

           public Individuo obtenerMejorfitness()      
        {
            Individuo fitprueba= new Individuo(poblacion[0]);
            for(int i=1; i<poblacion.Length; i++){
                if(poblacion[i].obtenerFitness< fitprueba.obtenerFitness)
                fitprueba=individuos[i];
            }
            return fitprueba;
            
        }

        public void calcularMejorfitness(AlgoritmoGenetico tipo)
        {
            foreach(Individuo v in poblacion)
            v.calcularMejorfitness(tipo);
        }

      
    
     

       

    }
}
=======
namespace iac
{
    public class Poblacion{

        private Individuo[] individuos;
        private int canti;
        private int cants;
        public Poblacion(int pcanti,int pcants )
        {
            canti=pcanti;//cantidad de individuos
            cants=pcants;//cantidad de soluciones
            individuos=new Individuo[canti];
        }

        public void generarPoblacion(){
            for (int i = 0; i < canti; i++)
            {
                individuos[i]=new Individuo(cants);//generando los individuos de la poblacion
            }
        }
       public void calcularMejorfitness(algoritmoGenetico tipo) 
       {
           for(int i=0; i< individuos.Length; i++)
           {
               individuos[i].calcularMejorfitness(tipo);
           }

       }
    
        public Individuo obtenerFitness()
        {
            Individuo fitprueba= new Individuo(individuos[0]);
            for(int i=1; i<individuos.Length; i++){
                if(individuos[i].obtenerFitness()< fitprueba.obtenerFitness())
                fitprueba=individuos[i];
            }
            return fitprueba;
            
        }

        public Individuo[] obtnerPoblacion(){
            return individuos;
        }

    }
     
    //Aqui empieza la clase que contiene el algoritmo genetico
    public class algoritmoGenetico
    {
        private double probMutacIndivid = 0.70; //probabilidad de mutacion por indiviuo despue del crossover
        private double probMutacGenes = 0.03; //probabilidad de mutacion por genes despue del crossover
        private int cantGeneraciones= 200; //Numero de Generaciones
        private int cantPoblacion= 100; //Tamaño de la Poblacion
        private int cantTorneo=10; //Numero de participantes en el torneo
        private algoritmoGenetico tipo; //Tipo de Algoritmo Genetico
        private Poblacion poblacion; //Poblacion actual

        public algoritmoGenetico( algoritmoGenetico tipo){
            this.tipo=tipo;
            poblacion= new Poblacion(cantPoblacion);
            poblacion.generarPoblacion(); 
            poblacion.calcularMejorfitness(tipo);

        }

        //Ejecutar el algoritmo durante el numero de generaciones establecido

        public void Ejecutar()
        {
           for(int i=0; i<cantGeneraciones; i++)
           {
             Poblacion pob = new Poblacion(cantPoblacion);
             for(int j=0; j<cantPoblacion/2; j++)
             {
             //
             Individuo padre1, padre2;
             padre1=seleccionarTorneo();
             do{
                 padre2=seleccionarTorneo();
               } while(padre1.obtenerSolucion()==padre2.obtenerSolucion());
          
            Individuo[] hijos=crossover(padre1,padre2);

            mutate(hijos[0]);
            mutate(hijos[1]);
          
          pob.obtnerPoblacion()[2*j]=new Individuo(hijos[0]);
          pob.obtnerPoblacion()[2*j+1]=new Individuo(hijos[1]);
           } 
          pob.obtnerPoblacion()[0]=new Individuo(poblacion.obtenerFitness());
          pob.calcularMejorfitness(tipo);
          poblacion= pob;
        }
     }

        public void seleccionarTorneo()
        {
            Random r= new Random();
            Set<Integer> participantes= new HashSet<>(); 
            Poblacion torneo=new Poblacion(cantTorneo);
            for(int i=0; i<cantTorneo; i++)
            {
                int participantes;
                do{
                    participantes=r.nextInt(cantPoblacion);
                }while(participantes.contiene(participantes));
                torneo.obtnerPoblacion()[i]=new Individuo(poblacion.obtnerPoblacion()[participantes]);
            }
            return torneo.obtenerFitness;
        }

        private Individuo[] crossover(Individuo padre1, Individuo padre2)
        {

        }

        private void mutate(Individuo individuo)
        {
            Random r=new Random();
            double prob=r.nextDouble();
            
        }

    }
}
>>>>>>> 885ce6df3a5824ee99f50d739bb39f20094757d2
