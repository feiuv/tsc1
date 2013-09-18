using System; 
namespace ExtensionMetodo
{

    /// <summary>
    /// Clase para extensión
    /// </summary>
    public static class Extensions
    {
        public static int Adicion(this int x)
        {
            return x + 1;
        }

        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
           StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}


