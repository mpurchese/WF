using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WF.Domain.Entities;

namespace WF.Domain.Interfaces
{
    public interface ITransactionRepository
    {
        IReadOnlyCollection<Transaction> Get();
    }
}
