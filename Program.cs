using System;

using System.IO;

namespace iac
{

    public class Program
    {

        static void Main() {
        bool esEstandar = true;
        bool esBaldwiniano = false;
        bool esLamarckiano = false;

        AlgoritmoGenetico estandar, baldwiniano, lamarckiano;

        Matrices.loadData();

        if (esEstandar) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Construyendo un algoritmo estándar");
            estandar = new AlgoritmoGenetico(algoritmoGenetico.standar);
            Console.WriteLine("Executando un algoritmo estándar");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            estandar.Ejecutar();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
        

            Console.WriteLine("Estándar");
            Console.WriteLine("Tiempo: " + (elapsedMs)+ " ms" );
            Console.WriteLine("Solución: " + string.Join(",", estandar.obtenerFitness().obtenerSolucion));
            Console.WriteLine("Fitness: " + estandar.obtenerFitness().obtenerFitness());
        }

        if (esBaldwiniano) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Construyendo un algoritmo baldwiniano");
            baldwiniano = new AlgoritmoGenetico(algoritmoGenetico.baldwiniana);
            Console.WriteLine("Executando un algoritmo baldwiniano");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            baldwiniano.Ejecutar();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            

            Console.WriteLine("Baldwiniano");
            Console.WriteLine("Tiempo: " + (elapsedMs)+ " ms" );
            Console.WriteLine("Solución: " + string.Join(",", baldwiniano.obtenerFitness().obtenerSolucion));
            Console.WriteLine("Fitness: " + baldwiniano.obtenerFitness().obtenerFitness());
        }

        if (esLamarckiano) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Construyendo un algoritmo lamarckiano ");
            lamarckiano = new AlgoritmoGenetico(algoritmoGenetico.lamarckiana);
            Console.WriteLine("Executando un algoritmo lamarckiano");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            lamarckiano.Ejecutar();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
                
              

            Console.WriteLine("Lamarckiano");
            Console.WriteLine("Tiempo: " + (elapsedMs)+ " ms" );
            Console.WriteLine("Solución: " + string.Join(",", lamarckiano.obtenerFitness().obtenerSolucion));
            Console.WriteLine("Fitness: " + lamarckiano.obtenerFitness().obtenerFitness());
        }
    }
}

}


