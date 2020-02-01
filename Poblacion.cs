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
            Individuo fitprueba= poblacion[0];
            for(int i=1; i<poblacion.Length; i++){
                if(poblacion[i].obtenerFitness() < fitprueba.obtenerFitness())
                fitprueba=poblacion[i];
            }
            return fitprueba;
        }

        public void calcularMejorFitness(algoritmoGenetico tipo)
        {
            foreach (Individuo v in poblacion)
              v.calcularMejorfitness(tipo);   
        }

        




    }
}
