using System.Collections.Generic;
using System.Linq;
using System.Text;
using Characters;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using UnityEngine;

namespace Lobby
{
    public class PlayerLobby : MonoBehaviour
    {
        private const string CHARACTER_DATA = "CharacterData";
        private const string DUNGEON_MAP = "DungeonMap";

        private ICharacterLoader _characterLoader;
        
        private string _currentLobbyId;
        private string _lobbyCode;

        public async void CreateLobby(byte[] characterData, string dungeonName)
        {
            var options = new CreateLobbyOptions
            {
                Data = new Dictionary<string, DataObject>()
                {
                    { DUNGEON_MAP, new DataObject(DataObject.VisibilityOptions.Member, dungeonName) }
                },
                Player = new Player
                {
                    Data = new Dictionary<string, PlayerDataObject>
                    {
                        { CHARACTER_DATA, new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, Encoding.UTF8.GetString(characterData)) }
                    }
                }
            };
            var result = await Lobbies.Instance.CreateLobbyAsync(string.Empty, 4, options);
            _currentLobbyId = result.Id;
            _lobbyCode = result.LobbyCode;
        }

        public async void JoinLobby(string inviteCode, byte[] characterData)
        {
            var options = new JoinLobbyByCodeOptions
            {
                Player = new Player
                {
                    Data = new Dictionary<string, PlayerDataObject>
                    {
                        { CHARACTER_DATA, new PlayerDataObject(PlayerDataObject.VisibilityOptions.Member, Encoding.UTF8.GetString(characterData)) }
                    }
                }
            };
            var result = await Lobbies.Instance.JoinLobbyByCodeAsync(inviteCode, options);
            _currentLobbyId = result.Id;
            UpdateVisuals(result.Players);
        }

        public async void UpdateLobby(string dungeonName = null)
        {
            var result = await Lobbies.Instance.GetLobbyAsync(_currentLobbyId);
            UpdateVisuals(result.Players);
        }

        private void UpdateVisuals(List<Player> players)
        {
            foreach (var player in players)
            {
                _characterLoader.LoadCharacter(player.Id, Encoding.UTF8.GetBytes(player.Data[CHARACTER_DATA].Value));
            }
        }
    }
}