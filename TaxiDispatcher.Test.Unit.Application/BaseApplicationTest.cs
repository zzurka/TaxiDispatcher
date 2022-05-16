using Mapster;
using MapsterMapper;
using System.Collections.Generic;
using System.Reflection;

namespace TaxiDispatcher.Test.Unit.Application
{
    public abstract class BaseApplicationTest
    {
        protected Mapper mapper;

        protected BaseApplicationTest()
        {
            var config = TypeAdapterConfig.GlobalSettings;
            IList<IRegister> registers = config.Scan(Assembly.GetExecutingAssembly());
            config.Apply(registers);
            mapper = new Mapper(config);
        }
    }
}
