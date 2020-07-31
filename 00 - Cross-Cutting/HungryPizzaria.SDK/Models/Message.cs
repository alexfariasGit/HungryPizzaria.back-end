using System;
using System.Collections.Generic;
using System.Text;

namespace HungryPizzaria.SDK.Models
{
    public class Message<T>
    {
        /// <summary>
        /// 200 - OK
        /// 500 - ERRO
        /// 300 - Validacao
        /// </summary>
        public int? Code { get; private set; }
        public string Description { get; private set; }

        public T Result { get; private set; }
        public Exception Exception { get; private set; }
        public string FriendlyException { get; private set; }
        public List<string> Validations { get; set; }

        public void CreateMessageSuccess(string description, T result)
        {
            this.Code = 200;
            this.Description = description;
            this.Result = result;
        }

        public void CreateMessageError(string description, Exception exception, string friendlyException)
        {
            this.Code = 500;
            this.Description = description;
            this.Exception = exception;
            this.FriendlyException = friendlyException;

        }

        public void CreateMessageAlert(string description, List<string> lsValidations)
        {
            this.Code = 300;
            this.Description = description;
            this.Validations = lsValidations;

        }

    }
}
