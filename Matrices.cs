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

    public class Dataset 
    {

        public void loadData()
        {
         int c=0;
        string line ;
        System.IO.StreamReader file =new System.IO.StreamReader(@"D:\archivo.txt");
        int tamaño=0;

        while((line = file.ReadLine()) != null)  
       {  
         
        var values = (line.Split(' '));
        tamaño=int.Parse(line);
        System.Console.WriteLine(tamaño); 
         c++;  
       }  
  
       file.Close();  
       System.Console.WriteLine("There were {0} lines.", c);  
       // Suspend the screen.  
       System.Console.ReadLine(); 

        }
       
    }
}
