using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class Masker
{
    private static readonly ADataHandler _handlerChain = HandlerFactory.CreateHandlerChain();

    public static T Mask<T>(T obj, IMaskingStrategy strategy)
    {
        if (obj == null) return default;

        return (T)_handlerChain.Handle(obj, strategy);

    }

    public static T[] Mask<T>(T[]? obj, IMaskingStrategy strategy)
    {
        T[] copy = new T[obj.Length];
        for (int i = 0; obj.Length > i; i++)
        {
            copy[i] = (T)_handlerChain.Handle(obj[i], strategy);
        }
        return copy;
    }

}
