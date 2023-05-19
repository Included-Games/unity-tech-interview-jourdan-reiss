using System;
using System.Collections.Generic;

namespace Matchmaking
{
    public interface IMatchmaker
    {
        public void StartMatchmaking(IEnumerable<string> playerIds, string dungeonId, Action<MatchmakingStatus> statusChanged);
    }
}