using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public static class HandlerFactory
{
    public static ADataHandler CreateHandlerChain()
    {
        var stringHandler = new StringHandler();
        var intHandler = new IntHandler();
        var dateTimeHandler = new DateTimeHandler();

        stringHandler.SetNext(intHandler).SetNext(dateTimeHandler);
        return stringHandler;
    }
}
