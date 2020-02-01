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

        Dataset obj= new Dataset();
        obj.loadData();

        if (todoStandard) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building standard algorithm...");
            standard = new AlgoritmoGenetico(algoritmoGenetico.estándar);
            Console.WriteLine("Executing standard algorithm...");
            iniStandard = Environment.TickCount;
            standard.Ejecutar();
            finStandard = Environment.TickCount;

            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("STANDARD");
            Console.WriteLine("Time: " + (finStandard - iniStandard) / 1000);
            Console.WriteLine("Solution: " + standard.obtenerFitness().obtenerSolucion.ToString());
            Console.WriteLine("Fitness: " + standard.obtenerFitness().obtenerFitness());
        }

        if (todoBaldwinian) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building baldwinian algorithm...");
            baldwinian = new AlgoritmoGenetico(algoritmoGenetico.baldwiniana);
            Console.WriteLine("Executing baldwinian algorithm...");
            iniBaldwinian = Environment.TickCount;
            baldwinian.Ejecutar();
            finBaldwinian = Environment.TickCount;

            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("BALDWINIAN");
            Console.WriteLine("Time: " + (finBaldwinian - iniBaldwinian) / 1000);
            Console.WriteLine("Solution: " + baldwinian.obtenerFitness().obtenerSolucion.ToString());
            Console.WriteLine("Fitness: " + baldwinian.obtenerFitness().obtenerFitness());
        }

        if (todoLamarckian) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building lamarckian algorithm...");
            lamarckian = new AlgoritmoGenetico(algoritmoGenetico.lamarckiana);
            Console.WriteLine("Executing lamarckian algorithm...");
            iniLamarckian = Environment.TickCount;
            lamarckian.Ejecutar();
            finLamarckian = Environment.TickCount;

            Console.WriteLine("LAMARCKIAN");
            Console.WriteLine("Time: " + (finLamarckian - iniLamarckian) / 1000);
            Console.WriteLine("Solution: " + lamarckian.obtenerFitness().obtenerSolucion.ToString());
            Console.WriteLine("Fitness: " + lamarckian.obtenerFitness().obtenerFitness());
        }
    }
}

}


