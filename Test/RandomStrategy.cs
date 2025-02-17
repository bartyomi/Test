using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IRandomStrategy
{
    public Random GetRandom();
}

public class StaticRandomStrategy : IRandomStrategy
{
    private const int seed = 135792468;
    public Random GetRandom()
    {
        return new Random(seed);
    }
}

public class RandomStrategy : IRandomStrategy
{
    public Random GetRandom()
    {
        return new Random();
    }
}

