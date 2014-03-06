using System; 

class C : IDisposable
{
    public void UseLimitedResource()
    {
        Console.WriteLine("Utilizando recurso limitado...");
    }

    void IDisposable.Dispose()
    {
        Console.WriteLine("Liberando recurso limitado...");
    }
}

class Program
{
    static void Main()
    {
        using (C c = new C())
        {
            c.UseLimitedResource();
        }

        Console.WriteLine("Ahora esta fuera de using.");
        Console.ReadLine();
    }
}