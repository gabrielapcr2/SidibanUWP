using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connection.Entities
{
    public interface Methods
    {
        Task<bool> RemoveTaskAsync(Card newCard);
    }
}
