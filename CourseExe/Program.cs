using System.Globalization;
namespace CourseExe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var source = @"c:\curso\source.csv";
            var target = @"c:\curso\out\summary.csv";

            try
            {
                var newFolder = Directory.CreateDirectory(@"c:\curso\out");
                string[] itens = File.ReadAllLines(source);
                
                foreach (var item in itens)
                {
                    string[] splits = item.Split(',');

                    int quant = int.Parse(splits[2]);
                    double price = double.Parse(splits[1], CultureInfo.InvariantCulture);

                    double total = quant * price;

                    using (StreamWriter sw = File.AppendText(target)) 
                    { 
                        sw.WriteLine($"{splits[0]}, R${total.ToString("F2").Replace(',','.')}");
                    }
                }                
	    }
            catch (IOException e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
            finally 
            {
		Console.WriteLine("Programa Finalizado.");
            }
        }
    }
}
