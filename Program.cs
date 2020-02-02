using System;

using System.IO;

namespace iac
{

    public class Program
    {

     
        static void Main(string[] args) {
        bool todoStandard = false;
        bool todoBaldwinian = false;
        bool todoLamarckian = true;

        long iniStandard, finStandard, iniBaldwinian, finBaldwinian, iniLamarckian, finLamarckian;

        AlgoritmoGenetico standard, baldwinian, lamarckian;

        Matrices.loadData();

        if (todoStandard) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building standard algorithm...");
            standard = new AlgoritmoGenetico(algoritmoGenetico.estándar);
            Console.WriteLine("Executing standard algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            standard.Ejecutar();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
        

            Console.WriteLine("STANDARD");
            Console.WriteLine("Time: " + (elapsedMs)+ " ms" );
            Console.WriteLine("Solution: " + string.Join(",", standard.obtenerFitness().obtenerSolucion));
            Console.WriteLine("Fitness: " + standard.obtenerFitness().obtenerFitness());
        }

        if (todoBaldwinian) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building baldwinian algorithm...");
            baldwinian = new AlgoritmoGenetico(algoritmoGenetico.baldwiniana);
            Console.WriteLine("Executing baldwinian algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            baldwinian.Ejecutar();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            

            Console.WriteLine("BALDWINIAN");
            Console.WriteLine("Time: " + (elapsedMs)+ " ms" );
            Console.WriteLine("Solution: " + string.Join(",", baldwinian.obtenerFitness().obtenerSolucion));
            Console.WriteLine("Fitness: " + baldwinian.obtenerFitness().obtenerFitness());
        }

        if (todoLamarckian) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building lamarckian algorithm...");
            lamarckian = new AlgoritmoGenetico(algoritmoGenetico.lamarckiana);
            Console.WriteLine("Executing lamarckian algorithm...");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            lamarckian.Ejecutar();
            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
                
              

            Console.WriteLine("LAMARCKIAN");
            Console.WriteLine("Time: " + (elapsedMs)+ " ms" );
            Console.WriteLine("Solution: " + string.Join(",", lamarckian.obtenerFitness().obtenerSolucion));
            Console.WriteLine("Fitness: " + lamarckian.obtenerFitness().obtenerFitness());
        }
    }
}

}


