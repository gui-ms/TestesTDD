using Calculadora.Services;

namespace CalculadoraTestes;

public class CalculadoraTestes
{
    private CalculadoraImp _calculadora;

    public CalculadoraTestes()
    {
        _calculadora = new CalculadoraImp();
    }

    [Theory]
    [InlineData (1,2,3)]
    [InlineData (2,2,4)]
    public void TestedeSoma(int num1, int num2, int resultado)
    {
        var resultadoCalculadora = _calculadora.Somar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }


    [Theory]
    [InlineData (3,2,6)]
    public void TestedeMultiplicacao(int num1, int num2, int resultado)
    {
        var resultadoCalculadora = _calculadora.Multiplicar(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }


    [Theory]
    [InlineData (4,2,2)]
    public void TestedeDivisao(int num1, int num2, int resultado)
    {
        var resultadoCalculadora = _calculadora.Dividir(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }


    [Theory]
    [InlineData (5,2,3)]
    public void TestedeSubtracao(int num1, int num2, int resultado)
    {
        var resultadoCalculadora = _calculadora.Subtrair(num1, num2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Fact]
    public void TestedeDivisaoPorZero(){
        Assert.Throws<DivideByZeroException>(() => _calculadora.Dividir(3,0));
    }


    [Fact]
    public void TestedeHistorico(){
        _calculadora.Somar(1,2);
        _calculadora.Somar(3,2);
        _calculadora.Somar(3,3);
        _calculadora.Somar(5,2);

        var lista = _calculadora.Historico();
        Assert.NotEmpty(lista);
        Assert.Equal(3, lista.Count);
    }
}