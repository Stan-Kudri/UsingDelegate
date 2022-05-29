



Calculater calcul = Calculate;
var valueRes = calcul(Substract, 10, 3);
Console.WriteLine(valueRes);


Func<float> func = Number;
static float Number() => 33;


static double Substract(double v1, double v2)
{
    Console.WriteLine("Substract[{0} ; {1}]", v1, v2);
    return v1 - v2;
}



static double Calculate(Func<double, double, double> func, double v1, double v2)
{
    var value = func(v1, v2);
    Console.WriteLine("v1 = {0} ; v2 = {1} ; res = {2}", v1, v2, value);
    return value;
}






// Action<Func<float>, bool, List<float>>

Console.WriteLine();



Action<Func<float>, bool, List<float>> PrintChangedArrayIfTrue = (constValue, addValue, value) =>
{
    Console.WriteLine(addValue);
    Console.WriteLine("Массив :{0}", string.Join(";", value));
    if (addValue == true)
    {
        value = value.Select(x => x * constValue.Invoke()).ToList();
        Console.WriteLine("Массив :{0}", string.Join(";", value));
    }
};

PrintChangedArrayIfTrue(Number, true, new List<float> { 1, 2, 3, 4, 5 });








//Func<Action<char>, bool, double, double>


Console.WriteLine();
static void PrintSymbol(char symbo) => Console.WriteLine(symbo);

Func<Action<char>, bool, double, double> SumValue = (printChar, addValue, value) =>
{
    printChar('F');
    var constValue = 33.2;
    if (addValue == true)
    {
        constValue += value;
    }
    return constValue;
};

var valueFunc = SumValue(PrintSymbol, true, 23);
Console.WriteLine(valueFunc);



Console.WriteLine();
//Func<Action<T>, float, float> : T object

static void PrintT(object T) => Console.WriteLine(T.ToString());

static float SumOfValueAndParameterLength(Action<object> action, float value)
{
    var str = "SAAADDDDD";
    action(value);
    action(str);

    return value + str.Length;
}

var funcAction = SumOfValueAndParameterLength(PrintT, 33);
Console.WriteLine(funcAction);






Console.WriteLine();
//Action<Func<int>, char, char>

static int ConstValue() => -5;

static void SymbolOutputDependingOnValue(Func<int> constValue, char firstSymbol, char secondSymbol)
{
    if (constValue() <= 0)
        Console.WriteLine(firstSymbol.ToString());
    else
        Console.WriteLine(secondSymbol.ToString());
}

SymbolOutputDependingOnValue(ConstValue, 'A', 'B');


//Action<Func<char, int>, List<string>>


Func<char, int> ValueFromSymbol = (t) =>
{
    if (char.IsDigit(t))
        return 1;
    else if (char.IsLetter(t))
        return -1;
    else
        return 0;
};

Action<Func<char, int>, List<string>> ActionFunc = (value, line) =>
{
    var numberSymbol = value('-');
    var collection = new List<string>();
    if (numberSymbol == 1)
    {
        line.AddRange(new List<string>() { "Числооо", "Числоо", "Число" });
    }
    else if (numberSymbol == -1)
    {
        line.AddRange(new List<string>() { "Буквааа", "Букваа", "Буква" });
    }
    else
    {
        line.AddRange(new List<string>() { "Что-тооо", "Что-тоо", "Что-то" });
    }
    Console.WriteLine("Массив :{0}", string.Join("; ", line));
};

ActionFunc(ValueFromSymbol, new List<string>() { "ХОООХ", "ХООХ", "ХОХ" });


delegate double Calculater(Func<double, double, double> func, double v1, double v2);