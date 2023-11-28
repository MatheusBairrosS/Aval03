using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Matheus Bairros Silva
        string textoCifrado = File.ReadAllText("provinhaBarbadinha.txt");

        string textoDecifrado = DecifrarTexto(textoCifrado);

        textoDecifrado = textoDecifrado.Replace("@", "\n");

        string[] palindromos = EncontrarPalindromos(textoDecifrado);
        textoDecifrado = SubstituirPalindromos(textoDecifrado, palindromos);

        Console.WriteLine($"Conteúdo do texto cifrado: {textoCifrado}");
        Console.WriteLine($"Palíndromos encontrados: {string.Join(", ", palindromos)}");
        Console.WriteLine($"Número de caracteres do texto decifrado: {textoDecifrado.Length}");
        Console.WriteLine($"Quantidade de palavras no texto decifrado: {ContarPalavras(textoDecifrado)}");
        Console.WriteLine($"Texto decifrado em maiúsculo: {textoDecifrado.ToUpper()}");

        Console.ReadLine();
    }

    static string DecifrarTexto(string textoCifrado)
    {
        char[] caracteresCifrados = textoCifrado.ToCharArray();
        for (int i = 0; i < caracteresCifrados.Length; i++)
        {
            int chave = (i % 5 == 0) ? 8 : 16;
            caracteresCifrados[i] = (char)(caracteresCifrados[i] - chave);
        }
        return new string(caracteresCifrados);
    }

    static string[] EncontrarPalindromos(string texto)
    {
        string[] palavras = texto.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        return palavras.Where(p => EhPalindromo(p)).ToArray();
    }

    static bool EhPalindromo(string palavra)
    {
        char[] caracteres = palavra.ToCharArray();
        Array.Reverse(caracteres);
        return palavra.Equals(new string(caracteres), StringComparison.OrdinalIgnoreCase);
    }

    static string SubstituirPalindromos(string texto, string[] palindromos)
    {
        foreach (var palindromo in palindromos)
        {
            texto = texto.Replace(palindromo, ObterSubstituicao(palindromo));
        }
        return texto;
    }

    static string ObterSubstituicao(string palindromo)
    {
        switch (palindromo.ToLower())
        {
            case "amora":
                return "gloriosa";
            case "ovo":
                return "bondade";
            case "osso":
                return "passam";
            default:
                return palindromo;
        }
    }

    static int ContarPalavras(string texto)
    {
        return texto.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
    }
}