using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        string data1 = "Hello, world!";
        int data2 = 123456789;
        DateTime data3 = new DateTime(1999, 12, 31);
        object[] objects = { data1, data2, data3 };

        data1 = Masker.Mask(data1, new ReverseMaskingStrategy());
        Console.WriteLine(data1);

        data2 = Masker.Mask(data2, new ReverseMaskingStrategy());
        Console.WriteLine(data2);

        data3 = Masker.Mask(data3, new ReverseMaskingStrategy());
        Console.WriteLine(data3);

        Console.WriteLine();

        data1 = Masker.Mask(data1, new RandomMaskingStrategy(new StaticRandomStrategy()));
        Console.WriteLine(data1);

        data2 = Masker.Mask(data2, new RandomMaskingStrategy(new StaticRandomStrategy()));
        Console.WriteLine(data2);

        data3 = Masker.Mask(data3, new RandomMaskingStrategy(new StaticRandomStrategy()));
        Console.WriteLine(data3);

        Console.WriteLine();

        objects = Masker.Mask(objects, new RandomMaskingStrategy(new RandomStrategy()));
        foreach (object obj in objects) Console.WriteLine(obj);


    }
}