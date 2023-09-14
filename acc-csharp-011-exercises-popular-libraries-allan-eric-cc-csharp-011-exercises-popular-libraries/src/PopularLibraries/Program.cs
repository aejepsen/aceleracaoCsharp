using PopularLibraries.Models;
// ok.
public class Program
{
    public static void Main(string[] args)
    {
         using(var context = new PopularLibrariesContext())
         {
             context.Database.EnsureCreated();
             Console.WriteLine("Providers:");
             foreach(var provider in context.Providers)
             {
                 Console.WriteLine($"{provider.Name}");
             }
             Console.WriteLine();
             Console.WriteLine();

             Console.WriteLine("Orms:");
             foreach(var orm in context.Orms)
             {
                 Console.WriteLine($"{orm.Name}");
             }
             Console.WriteLine();
             Console.WriteLine();

             Console.WriteLine("Databases:");
             foreach(var database in context.Databases)
             {
                 Console.WriteLine($"{database.Name}");
             }
             Console.WriteLine();
             Console.WriteLine();

             Console.WriteLine("Languages:");
             foreach(var language in context.Languages)
             {
                 Console.WriteLine($"{language.Name}");
             }
         }
    }
}
