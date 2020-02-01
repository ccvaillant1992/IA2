namespace iac
{

    public class Matrices
    {
        public static int locations; //numero de localizaciones
        public static int[,] distance;//matriz de distancias entre las localizaciones
        public static int[,] weights ;//matriz de flujo entre las localizaciones

        public static int getlocations => locations;

        public static int[,] getdistance => distance;

        public static int[,] getweights => weights;

        
    }
}
