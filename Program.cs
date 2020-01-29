<<<<<<< HEAD
﻿using System;

namespace iac
{

    public class Program
    {
        static void Main(string[] args)
        {
            
      

            algoritmoGenetico estandar, baldwiniana, lamarckiana;

            Console.WriteLine("Leyendo matrices...");
            Matrices.setInput(new File("D:/qap.datos/bur26a.dat"));

           Console.WriteLine("Construyendo un algoritmo estandar");
           estandar=new algoritmoGenetico(algoritmoGenetico.estandar);
           Console.WriteLine("Ejecutando el algoritmo estandar");
           estandar.Ejecutar();  
           
         
            



        }
    }
}
=======
﻿using System;

namespace iac
{

    public class Program
    {
        static void Main(string[] args)
        {
            Individuo ind=new Individuo(10);//creo un individuo
            ind.updateWeight(7, 9); //Para la mutacion 
            Poblacion poblacion=new Poblacion(10,20); //Creo una poblacion
            Console.WriteLine("Hello World!");
        }
    }
}
>>>>>>> 885ce6df3a5824ee99f50d739bb39f20094757d2
