using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Exceptions
{
    public class OperacaoNaoPermitidaException : Exception
    {
        public OperacaoNaoPermitidaException()
        {
            
        }

        public OperacaoNaoPermitidaException(string mensagem) : base(mensagem)
        {
            
        }

        public OperacaoNaoPermitidaException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna)
        {
            
        }
    }
}
