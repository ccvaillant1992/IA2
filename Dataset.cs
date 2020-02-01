namespace iac
{
    public class Dataset
    {
       
        public void loadData()
        {
            int c = 0;
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader(@"D:\archivo.txt");
            int tamaño = 0;

            while ((line = file.ReadLine()) != null)
            {

                var values = (line.Split(' '));
                tamaño = int.Parse(line);
                System.Console.WriteLine(tamaño);
                c++;
            }

            file.Close();
            System.Console.WriteLine("There were {0} lines.", c);
            // Suspend the screen.  
            System.Console.ReadLine();

        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
