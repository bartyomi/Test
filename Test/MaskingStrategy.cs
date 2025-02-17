using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IMaskingStrategy
{
    public string Execute(string data);

}

public class ReverseMaskingStrategy : IMaskingStrategy
{
    public string Execute(string data)
    {
        string copy = "";
        for (int i = 0; i < data.Length; i++)
        {
            copy += data[data.Length - i - 1];
        }
        return copy;
    }
}

public class RandomMaskingStrategy : IMaskingStrategy
{
    private readonly IRandomStrategy _randomStrategy;
    public RandomMaskingStrategy(IRandomStrategy randomStrategy) { _randomStrategy = randomStrategy; }
    public string Execute(string data)
    {
        Random random = _randomStrategy.GetRandom();
        string copy = "";
        for (int i = 0; i < data.Length; i++)
        {
            if ((int)data[i] >= 48 && (int)data[i] <= 57)
            {
                copy += (char)random.Next(48, 57);
            }
            else
            {
                copy += (char)random.Next(33, 122);
            }
        }
        return copy;
    }
}


