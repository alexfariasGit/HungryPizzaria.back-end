using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HungryPizzaria.SDK.Core
{
    public interface ICommand<IN, OUT>
    {

        List<string> Validate(IN parameter);
        OUT Run(IN paramter, IDbConnection _connection = null, IDbTransaction _transacation = null);


    }
}
