using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace HungryPizzaria.SDK.Core
{
    public interface IRepositorioBase<T>
    {
        T Inserir(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        Task<T> InserirAsync(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        T Alterar(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        Task<T> AlterarAsync(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        bool Deletar(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        Task<bool> DeletarAsync(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        IEnumerable<T> Obter(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        Task<IEnumerable<T>> ObterAsync(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        T ObterPorID(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
        Task<T> ObterPorIDAsync(T entidade, IDbConnection _connection = null, IDbTransaction _transacation = null);
    }
}
