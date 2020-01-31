namespace iac
{

    public class Matrices
    {
        private static int locations; //numero de localizaciones
        public static int[,] distance;//matriz de distancias entre las localizaciones
        public static int[,] weights ;//matriz de flujo entre las localizaciones

        public static int getlocations => locations;

        public static int[,] getdistance => distance;

        public static int[,] getweights => weights;

        public static void setInput(string file)
        {
            Scanner scanner=new Scanner(file);
            locations= scanner.nextInt();
            distance=new int[locations,locations];
            weights=new int[locations,locations];

            for(int i=0; i<locations; i++)
            {
                for(int j=0; j<locations; j++)
                {
                    distance[i,j]=scanner.nextInt();
                }
            }
            
            for(int i=0; i<locations; i++)
            {
                for(int j=0; j<locations; j++)
                {
                    weights[i,j]= scanner.nextInt();
                }
            }
        }
    }
}
