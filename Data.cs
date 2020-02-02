using System;

using System.IO;
namespace iac
{
    public class Data
    {
        private string path;

        public int[][] locations { get; set; }
        public int[][] fitnes { get; set; }
        public int lenght { get; set; }
        public Data()
        {
            //this.path = path;
            this.lenght = 0;
            this.path = @"qap.datos\tai80b.dat";
            loadData();
        }
        public void loadData()
        {
            string[] rows = File.ReadAllLines(path);//abre el archivo copia todas las lineas y cierra el archivo
            int count = 0; //contador de lineas
            bool first = true;// lo inicializo en true para rellenar la matriz de distancia primero
            int locationIndex = 0;//contador de las filas de la matriz de distancia
            int fitnexIndex = 0;//contador de las filas de la matriz de pesos
            int rowCount=0;

            foreach (string line in rows)
            {
                if (count == 0)//si es la primera linea es el tamaño
                {
                    lenght = int.Parse(line.Trim());
                    locations=new int[lenght][];
                    fitnes=new int[lenght][];
                }
                else
                {
                    string[] items = line.Split(' ');// divido la linea por espacio
                    if (items.Length >= lenght)
                    {

                        if (first && locationIndex<lenght)//si es la primera matrix
                        {
                            locations[locationIndex] = getIntValues(items);
                            locationIndex++;
                        }
                        else//si es la segunda matrix
                        {
                            fitnes[fitnexIndex] = getIntValues(items);
                            fitnexIndex++;
                        }
                        rowCount++;
                    }
                    else
                    {
                        if (rowCount==lenght){
                            first = false;
                             rowCount=0;
                        }
                             //la pongo en false cuando me encuentro la linea vacia despues de la primera matrix
                    }
                }
                count++;
            }
        }

        public int[] getIntValues(string[] line)
        {
            int[] data = new int[lenght];
            int index = 0;// contador de los numeros de la matriz
            for (int i = 0; i < line.Length; i++)
            {
                var isNumeric = int.TryParse(line[i], out int n);//retorna si es o no un numero, en caso de si lo guarda en la variable definida
                if (isNumeric && index < lenght)// compruebo si es un numero y valido que sea menor que la longitud del arreglo
                {
                    data[index] = n;// guardo el numero resultante de parsear el string
                    index++;
                }
            }
            return data;
        }
    }
  
}