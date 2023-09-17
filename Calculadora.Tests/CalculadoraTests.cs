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
    public void testSomarNumeros()
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
    public void testSomarVariosNumeros(int num1, int num2, int resultadoEsperado)
    {
        var resultadoObtido = _calculadora.somarDoisNumeros(num1, num2);

        Assert.That(resultadoEsperado, Is.EqualTo(resultadoObtido));
    }
    public static IEnumerable<TestCaseData> getTestData()
    {
        using (var reader = new StreamReader(@"C:\testspace\nunit-projeto\Calculadora.Tests\fixtures\massaSomar.csv"))
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

    [Test, TestCaseSource("getTestData")]
    public void testSomarMassa(int num1, int num2, int resultadoEsperado)
    {
        int resultadoObtido = _calculadora.somarDoisNumeros(num1, num2);
        Assert.That(resultadoObtido, Is.EqualTo(resultadoEsperado));
    }



}