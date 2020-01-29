﻿﻿using System;

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

        Console.WriteLine("Reading matrices...");
        Matrices.setInput(new File("data/qap/tai256c.dat"));

        if (todoStandard) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building standard algorithm...");
            standard = new AlgoritmoGenetico(algoritmoGenetico.estándar);
            Console.WriteLine("Executing standard algorithm...");
            iniStandard = System.currentTimeMillis();
            standard.Ejecutar();
            finStandard = System.currentTimeMillis();

            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("STANDARD");
            Console.WriteLine("Time: " + (finStandard - iniStandard) / 1000);
            Console.WriteLine("Solution: " + Arrays.toString(standard.getFittest().getSolution()));
            Console.WriteLine("Fitness: " + standard.getFittest().getFitness());
        }

        if (todoBaldwinian) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building baldwinian algorithm...");
            baldwinian = new AlgoritmoGenetico(algoritmoGenetico.baldwiniana);
            Console.WriteLine("Executing baldwinian algorithm...");
            iniBaldwinian = System.currentTimeMillis();
            baldwinian.Ejecutar();
            finBaldwinian = System.currentTimeMillis();

            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("BALDWINIAN");
            Console.WriteLine("Time: " + (finBaldwinian - iniBaldwinian) / 1000);
            Console.WriteLine("Solution: " + Arrays.toString(baldwinian.getFittest().getSolution()));
            Console.WriteLine("Fitness: " + baldwinian.getFittest().getFitness());
        }

        if (todoLamarckian) {
            Console.WriteLine("*****************************************************************************************");

            Console.WriteLine("Building lamarckian algorithm...");
            lamarckian = new AlgoritmoGenetico(algoritmoGenetico.lamarckiana);
            Console.WriteLine("Executing lamarckian algorithm...");
            iniLamarckian = System.currentTimeMillis();
            lamarckian.Ejecutar();
            finLamarckian = System.currentTimeMillis();

            Console.WriteLine("LAMARCKIAN");
            Console.WriteLine("Time: " + (finLamarckian - iniLamarckian) / 1000);
            Console.WriteLine("Solution: " + Arrays.toString(lamarckian.getFittest().getSolution()));
            Console.WriteLine("Fitness: " + lamarckian.getFittest().getFitness());
        }
    }
    }
}
