using System.Collections.Generic;
using NLog;

namespace SB
{
    public interface Parser
    {
        void Parse(Bank bank, string pathToCvs);
    }
}