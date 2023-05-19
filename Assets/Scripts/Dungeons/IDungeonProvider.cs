using System.Collections.Generic;

namespace Dungeons
{
    public interface IDungeonProvider
    {
        public string SelectedDungeonId { get; }
        public List<string> DungeonIds { get; }
    }
}