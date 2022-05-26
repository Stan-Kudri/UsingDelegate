

Console.WriteLine("Hello, World!");

static float Number() => 33;

Func<float> func = Number;

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

var res = Calculate(Substract, 10, 3);
Console.WriteLine(res);




// Action<Func<float>, bool, List<float>>


Console.WriteLine();
Action<Func<float>, bool, List<float>> action = (params1, params2, params3) =>
{
    Console.WriteLine(params2);
    Console.WriteLine("Массив :{0}", string.Join(";", params3));
    if (params2 == true)
    {
        params3 = params3.Select(x => x * params1.Invoke()).ToList();
        Console.WriteLine("Массив :{0}", string.Join(";", params3));
    }
};

action(Number, true, new List<float> { 1, 2, 3, 4, 5 });








//Func<Action<char>, bool, double, double>


Console.WriteLine();
static void ToChar(char t1) => Console.WriteLine(t1.ToString());

Func<Action<char>, bool, double, double> func1 = (params1, params2, params3) =>
{
    params1('F');
    var value = (double)33.2;
    if (params2 == true)
    {
        value += params3;
    }
    return value;
};

var valueFunc = func1(ToChar, true, 23);
Console.WriteLine(valueFunc);



Console.WriteLine();
//Func<Action<T>, float, float> : T object

static void Activ(object T) => Console.WriteLine(T.ToString());

static float FuncAction(Action<object> action, float value)
{
    var str = "SAAADDDDD";
    action(value);
    action(str);

    return value + str.Length;
}

var funcAction = FuncAction(Activ, 33);
Console.WriteLine(funcAction);






Console.WriteLine();
//Action<Func<int>, char, char>

static int funcActiv() => -5;

static void ActivThree(Func<int> t1, char t2, char t3)
{
    if (t1() <= 0)
        Console.WriteLine(t2.ToString());
    else
        Console.WriteLine(t3.ToString());
}

ActivThree(funcActiv, 'A', 'B');


//Action<Func<char, int>, List<string>>


Func<char, int> function = (t) =>
{
    if (char.IsDigit(t))
        return 1;
    if (char.IsLetter(t))
        return -1;
    else
        return 0;
};

Action<Func<char, int>, List<string>> actionFunc = (params1, params2) =>
{
    var numberSymbol = params1('-');
    var collection = new List<string>();
    if (numberSymbol == 1)
    {
        params2.AddRange(new List<string>() { "Числооо", "Числоо", "Число" });
    }
    else if (numberSymbol == -1)
    {
        params2.AddRange(new List<string>() { "Буквааа", "Букваа", "Буква" });
    }
    else
    {
        params2.AddRange(new List<string>() { "Что-тооо", "Что-тоо", "Что-то" });
    }
    Console.WriteLine("Массив :{0}", string.Join("; ", params2));
};

actionFunc(function, new List<string>() { "ХОООХ", "ХООХ", "ХОХ" });


