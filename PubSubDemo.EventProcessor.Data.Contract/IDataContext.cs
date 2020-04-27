using System;
using System.Threading.Tasks;

namespace PubSubDemo.EventProcessor.Data.Contract
{
    public interface IDataContext
    {
        void EnsureDbCreated();
    }
}
