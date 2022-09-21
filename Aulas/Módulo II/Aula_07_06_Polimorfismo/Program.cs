Console.WriteLine("Digite o primeiro valor");
Console.WriteLine("Digite o segundo valor");
Console.WriteLine("Digite o operador");


Expression expression = new(Console.ReadLine());

System.Console.WriteLine(
    expression.Evaluate(expression.Left, expression.Right, expression.Operator)
);

enum Operators
{
    GreaterThan = 0,
    LessThan = 1,
    EqualTo = 2,
};

class Expression
{
    private readonly int _left;
    private readonly int _right;
    private readonly Operators _operator;

    public int Left => _left;

    public int Right => _right;

    public Operators Operator => _operator;

    public Expression(string value)
    {
        var values = value.Split(" ");

        _left = int.Parse(values[0]);
        _operator = values[1];
        _right = int.Parse(values[2]);
    }

    public bool Evaluate<T>(int left, int right) =>
        OperatorFactory.Create(_left, _right, );
}

class OperatorFactory
{
    public static bool Create<T>(int left, int right, Operators enummm)
    {
        switch (enummm)
        {
            case enummm.Gra:
                return new GreaterThan().Evaluate(left, right);
            case 1:
                return new EqualTo().Evaluate(left, right);
            case 2:
                return new LessThan().Evaluate(left, right);
            default:
                throw new ArgumentException($"{@operator} é um operador não suportado.");
        }
    }
}

class LessThan
{
    public bool Evaluate(int left, int right) => left < right;
}

class GreaterThan
{
    public bool Evaluate(int left, int right) => left > right;
}

class EqualTo
{
    public bool Evaluate(int left, int right) => left == right;
}
