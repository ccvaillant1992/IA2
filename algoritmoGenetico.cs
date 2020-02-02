using System;
using System.Collections.Generic;
namespace iac
{
    
    //Aqui empieza la clase que contiene el algoritmo genetico
    public class AlgoritmoGenetico
    {
        private double probMutacIndivid = 0.70; //probabilidad de mutacion por indiviuo despue del crossover
        private double probMutacGenes = 0.03; //probabilidad de mutacion por genes despues del crossover
        private int cantGeneraciones = 4; //Numero de Generaciones
        private int tamañoPoblacion = 26; //Tamaño de la Poblacion
        private int cantTorneo = 3; //Numero de participantes en el torneo
        private algoritmoGenetico algoritmo; //Tipo de Algoritmo Genetico
        private Poblacion poblacion; //Poblacion actual

        public AlgoritmoGenetico(algoritmoGenetico tipo)
        {
           
            algoritmo = tipo;
            poblacion = new Poblacion(tamañoPoblacion);
            poblacion.generarPoblacion(tamañoPoblacion);
            poblacion.calcularMejorFitness(tipo);
        }

        public Individuo obtenerFitness() => poblacion.obtenerMejorfitness();
        //Ejecutar el algoritmo durante el numero de generaciones establecido

        public void Ejecutar()
        {
            for (int i = 0; i < cantGeneraciones; i++)
            {
                Poblacion nuevapob = new Poblacion(tamañoPoblacion);
                for (int j = 0; j < tamañoPoblacion / 2; j++)
                {
                    //
                    Individuo padre1, padre2;
                    padre1 = seleccionarTorneo();
                    do
                    {
                        padre2 = seleccionarTorneo();
                    } while (padre1.obtenerSolucion == padre2.obtenerSolucion);

                    Individuo[] hijos = crossover(padre1, padre2);

                    mutate(hijos[0]);
                    mutate(hijos[1]);

                    nuevapob.obtnerPoblacion()[2 * j] = new Individuo(hijos[0]);
                    nuevapob.obtnerPoblacion()[2 * j + 1] = new Individuo(hijos[1]);
                }
                nuevapob.obtnerPoblacion()[0] = new Individuo(poblacion.obtenerMejorfitness());
                nuevapob.calcularMejorFitness(algoritmo);
                poblacion = nuevapob;
                Console.WriteLine("Generacio:" + (i + 1));
                Console.WriteLine("\tSolution:" + poblacion.obtenerMejorfitness().obtenerSolucion.ToString());
                Console.WriteLine("\tFitness:" + poblacion.obtenerMejorfitness().obtenerFitness());

            }
        }

        public Individuo seleccionarTorneo()
        {
            Random r = new Random();
            HashSet<int> participantes = new HashSet<int>();
            Poblacion torneo = new Poblacion(cantTorneo);
            for (int i = 0; i < cantTorneo; i++)
            {
                int participante;
                do
                {
                    participante = r.Next(tamañoPoblacion);
                } while (participantes.Contains(participante));
                torneo.obtnerPoblacion()[i] = new Individuo(poblacion.obtnerPoblacion()[participante]);
            }
            return torneo.obtenerMejorfitness();
        }

        private Individuo[] crossover(Individuo padre1, Individuo padre2)
        {
            Random r = new Random();
            Individuo[] hijos = new Individuo[2];
            hijos[0] = new Individuo(Matrices.getlocations);
            hijos[1] = new Individuo(Matrices.getlocations);

            int posicion1, posicion2;
            posicion1 = r.Next(Matrices.getlocations);
            do
            {
                posicion2 = r.Next(Matrices.getlocations);
            } while (posicion1 == posicion2);

            if (posicion2 < posicion1)
            {
                int swap = posicion1;
                posicion1=posicion2;
                posicion2 = swap;
            }

            HashSet<int> Individuohijo0 = new HashSet<int>(tamañoPoblacion);
            HashSet<int> Individuohijo1 = new HashSet<int>(tamañoPoblacion);
            

            for (int i = posicion1; i < posicion2; i++)
            {
                hijos[0].obtenerSolucion[i] = padre1.obtenerSolucion[i];
                Individuohijo0.Add(hijos[0].obtenerSolucion[i]);

                hijos[1].obtenerSolucion[i] = padre2.obtenerSolucion[i];
                Individuohijo1.Add(hijos[1].obtenerSolucion[i]);
            }
            for (int i = 0; i < Matrices.getlocations; i++)
            {
                if (i<posicion1 || i >= posicion2)
                {
                    int iterador = 0;
                    while ( Individuohijo0.Contains(padre2.obtenerSolucion[iterador]))
                    {
                        iterador++;
                    }
                    hijos[0].obtenerSolucion[i] = padre1.obtenerSolucion[iterador];
                    Individuohijo0.Add(padre1.obtenerSolucion[iterador]);

                    iterador = 0;
                    while ( Individuohijo1.Contains(padre1.obtenerSolucion[iterador]))
                    {
                        iterador++;
                    }
                    hijos[1].obtenerSolucion[i] = padre1.obtenerSolucion[iterador];
                    Individuohijo1.Add(padre1.obtenerSolucion[iterador]);
                }
            }
            return hijos;

        }

        private void mutate(Individuo individuo)
        {
            Random r = new Random();

            double prob = r.NextDouble();
            if (prob >= probMutacIndivid)
            {
                return;
            }
            for (int i = 0; i < Matrices.getlocations; i++)
            {
                prob = r.NextDouble();
                if (prob < probMutacGenes)
                {
                    int j;
                    do
                    {
                        j = r.Next(Matrices.getlocations);
                    } while (j == i);
                    individuo.mutate(i, j);
                }
            }

        }

    }

    public enum algoritmoGenetico
    {
        estándar, baldwiniana, lamarckiana
    }

}