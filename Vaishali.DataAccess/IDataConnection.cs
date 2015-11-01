using System.Collections.Generic;
using Vaishali.DataModel;

namespace Vaishali.DataAccess
{
    public interface IDataConnection
    {
        IList<Number> Read();
        void Write(IList<Number> numbers);
    }
}
