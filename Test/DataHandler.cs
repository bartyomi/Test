using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class ADataHandler
{
    private ADataHandler _nextHandler;

    public ADataHandler SetNext(ADataHandler handler)
    {
        _nextHandler = handler;
        return handler;
    }

    public virtual object Handle(object data, IMaskingStrategy strategy)
    {
        if (_nextHandler != null)
        {
            return _nextHandler.Handle(data, strategy);
        }
        return default;
    }
}

public class StringHandler : ADataHandler
{
    public override object Handle(object data, IMaskingStrategy strategy)
    {
        if (data is string) return strategy.Execute(data.ToString());
        return base.Handle(data, strategy);
    }
}

public class IntHandler : ADataHandler
{
    public override object Handle(object data, IMaskingStrategy strategy)
    {
        if (data is int)
        {
            string masked = strategy.Execute(data.ToString());
            return int.Parse(masked);
        }
        return base.Handle(data, strategy);
    }
}

public class DateTimeHandler : ADataHandler
{
    public override object Handle(object data, IMaskingStrategy strategy)
    {
        if (data is DateTime)
        {

            string masked = strategy.Execute(data.ToString().Substring(0, 10).Replace(".", ""));

            int day = int.Parse(masked.Substring(0, 2));
            int month = int.Parse(masked.Substring(2, 2));
            int year = int.Parse(masked.Substring(4, 4));

            if (day < 1 || day > 31) day = 1;
            if (month < 1 || month > 12) month = 1;
            if (year < DateTime.MinValue.Year || year > DateTime.MaxValue.Year) year = 1999;

            return new DateTime(year, month, day);
        }
        return base.Handle(data, strategy);
    }
}
