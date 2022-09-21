namespace EditorDeTexto;

public class EditorDeTexto
{
    static void Main()
    {
        Menu();
    }

    static void Menu()
    {
        
        Console.Clear();
        Console.WriteLine("O que você deseja fazer ?");
        Console.WriteLine("1 - Abrir arquivo");
        Console.WriteLine("2- Criar novo arquivo");
        Console.WriteLine("0-sair");

        short option = short.Parse(Console.ReadLine()!);

        switch (option)
        {

            case 0:
            { 
                Environment.Exit(0);
                break;
            }
            case 1:
            {
                Abrir();
                break;
            }
            case 2:
            {   
                Editar();
                break;
            }
            
        }


    }
    
    static void Abrir()
    {
            
        Console.Clear();
        Console.WriteLine("Qual o caminho para salvar o arquivo ?");
        string path = Console.ReadLine()!;


        using (var file = new StreamReader(path))
        {
            string text = file.ReadToEnd();
            Console.WriteLine(text);
        }
        
        
        Console.WriteLine("");
        Console.ReadLine();
        Menu();
    }

    static void Editar()
    {
        
        Console.Clear();
        Console.WriteLine("Digite seu texto abaixo (F4 para sair)");
        Console.WriteLine("----------------------------");

        string text = "";

        do
        {
            text += Console.ReadLine();
            text += Environment.NewLine;
        } while (Console.ReadKey().Key != ConsoleKey.F4);
        
        Salvar(text);
    }

    static void Salvar(string text)
    {
        
        Console.Clear();
        Console.WriteLine("Qual o caminho para salvar o arquivo ?");
        var path = Console.ReadLine();

        if (path != null)
        {
            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine($"Arquivo {path} salvo com sucesso !");
        }

        Console.ReadLine();
        Menu();
    }
}