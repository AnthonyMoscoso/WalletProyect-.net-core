using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Utilities.IdGenerator.Abstracts
{
    public interface IIDGeneratorConfig
    {
        IIDGeneratorConfig Autoincrement(bool auto=true);
    }
}
