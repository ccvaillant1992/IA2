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
