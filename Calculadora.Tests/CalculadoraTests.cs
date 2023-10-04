using NUnit.Framework;
using Calculadora;

namespace Calculadora.Tests;

[TestFixture]
public class CalculadoraTests
{
    private Calculadora _calculadora;

    [SetUp]
    public void Setup()
    {
        _calculadora = new Calculadora();
    }

    [Test]
    public void testSomarNumerosSimples()
    {
        var num1 = 3;
        var num2 = 5;
        var resultadoEsperado = 8;

        var resultadoObtido = _calculadora.somarDoisNumeros(num1, num2);

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoObtido));

    }

    [TestCase(1, 1, 2)]
    [TestCase(5, 7, 12)]
    [TestCase(50, 5, 55)]
    public void testSomarTag(int num1, int num2, int resultadoEsperado)
    {
        var resultadoObtido = _calculadora.somarDoisNumeros(num1, num2);

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoObtido));
    }
    
    public static IEnumerable<TestCaseData> getTestData(int operacao)
    {
        String caminhoMassa = "";

        switch (operacao)
        {
            case 1:
                caminhoMassa = @"C:\testspace\nunit-projeto\Calculadora.Tests\fixtures\massaSomar.csv";
                break;
            case 2:
                caminhoMassa = @"C:\testspace\nunit-projeto\Calculadora.Tests\fixtures\massaSubtrair.csv";
                break;
            case 3:
                caminhoMassa = @"C:\testspace\nunit-projeto\Calculadora.Tests\fixtures\massaMultiplicar.csv";
                break;
            case 4:
                caminhoMassa = @"C:\testspace\nunit-projeto\Calculadora.Tests\fixtures\massaDividir.csv";
                break;
        }

        using (var reader = new StreamReader(caminhoMassa))
        {
            // Pula a primeira linha com os cabeçahos
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(",");

                yield return new TestCaseData(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
            }
        }

    }

    [Test, TestCaseSource("getTestData", new object[] { 1 })]
    public void testSomarMassa(int num1, int num2, int resultadoEsperado)
    {
        int resultadoObtido = _calculadora.somarDoisNumeros(num1, num2);
        Assert.That(resultadoObtido, Is.EqualTo(resultadoEsperado));
    }

    [Test, TestCaseSource("getTestData", new object[] { 2 })]
    public void testSubtrairMassa(int num1, int num2, int resultadoEsperado)
    {
        int resultadoObtido = _calculadora.subtrairDoisNumeros(num1, num2);
        Assert.That(resultadoObtido, Is.EqualTo(resultadoEsperado));
    }

    [Test, TestCaseSource("getTestData", new object[] { 3 })]
    public void testMultiplicarMassa(int num1, int num2, int resultadoEsperado)
    {
        int resultadoObtido = _calculadora.multiplicarDoisNumeros(num1, num2);
        Assert.That(resultadoObtido, Is.EqualTo(resultadoEsperado));
    }

    [Test, TestCaseSource("getTestData", new object[] { 4 })]
    public void testDividirMassa(int num1, int num2, int resultadoEsperado)
    {

        int resultadoObtido = _calculadora.dividirDoisNumeros(num1, num2);
        Assert.That(resultadoObtido, Is.EqualTo(resultadoEsperado));

    }

}