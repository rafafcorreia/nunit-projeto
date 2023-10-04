using System;

namespace Calculadora;

public class Calculadora
{

    public int somarDoisNumeros(int num1, int num2)
    {
        return num1 + num2;
    }

    public int subtrairDoisNumeros(int num1, int num2)
    {
        return num1 - num2;
    }

    public int multiplicarDoisNumeros(int num1, int num2)
    {
        return num1 * num2;
    }

    public int dividirDoisNumeros(int num1, int num2)
    {
        try
        {
            return num1 / num2;

        }
        catch (System.DivideByZeroException)
        {
            Console.WriteLine("Não foi possível dividir por zero");
            return 0;
        }
    }
}