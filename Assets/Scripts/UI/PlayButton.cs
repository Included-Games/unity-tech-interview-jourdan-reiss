using System.Collections.Generic;
using System.Linq;
using Dungeons;
using Matchmaking;
using UnityEngine;

namespace UI
{
    public class PlayButton : MonoBehaviour, IButtonPressHandler
    {
        private IMatchmaker _matchmaker;
        public IDungeonProvider _dungeonProvider;
        public List<string> PlayerIds { get; set; }

        public void ButtonPressed()
        {
            _matchmaker.StartMatchmaking(PlayerIds, _dungeonProvider.DungeonIds.First(), status =>
            {
                Debug.Log("Matchmaking Status: " + status);
            });
        }
    }
}