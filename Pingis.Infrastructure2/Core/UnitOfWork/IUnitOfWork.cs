using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pingis.DataModel.Core.Repository;
using Pingis.DataModel.Core.Service;
using Pingis.DataModel.Service;

namespace Pingis.DataModel.Core.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IPlayerRepository Players { get; }
        IGameRepository Games { get; }
        IGameService GamesService { get; }
        IPlayerService PlayerService { get; }

        int Complete();
    }
}
