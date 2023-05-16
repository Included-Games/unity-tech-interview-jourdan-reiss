using System.Collections;
using System.Linq;
using Characters;
using UI;
using Unity.Services.Lobbies;
using UnityEngine;

namespace Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] private PlayButton playButton;
        private ICharacterLoader _characterLoader;
        private Unity.Services.Lobbies.Models.Lobby CurrentLobby { get; set; }
        private string lobbyId;
        
        public Unity.Services.Lobbies.Models.Lobby CreateLobby()
        {
            var task = Lobbies.Instance.CreateLobbyAsync("MyLobby", 4, new CreateLobbyOptions()
            {
                IsPrivate = true
            });
            var lobby = task.GetAwaiter().GetResult();
            CurrentLobby = lobby;
            lobbyId = lobby.Id;
            StartCoroutine(GetLobby(2.5f));
            return lobby;
        }

        public Unity.Services.Lobbies.Models.Lobby JoinLobby(string lobbyCode)
        {
            var task = Lobbies.Instance.JoinLobbyByCodeAsync(lobbyCode);
            var lobby = task.GetAwaiter().GetResult();
            CurrentLobby = lobby;
            lobbyId = lobby.Id;
            StartCoroutine(GetLobby(0.1f));
            return lobby;
        }
        
        private void GetLobby()
        {
            var task = Lobbies.Instance.GetLobbyAsync(lobbyId);
            var lobby = task.GetAwaiter().GetResult();
            if (lobby != CurrentLobby)
            {
                var playerIds = new string[4];
                var index = 0;
                foreach (var player in lobby.Players)
                {
                    playerIds[index] = player.Id;
                    index++;
                }
                if (lobby.Players.Count > 1)
                {
                    playButton.gameObject.SetActive(true);
                    playButton.PlayerIds = playerIds.ToList();
                }

                foreach (var player in lobby.Players)
                {
                    var characterData = (byte[]) player.Data["Character_Data"].Value;
                    _characterLoader.LoadCharacter(player.Id, characterData);
                }
            }
            StartCoroutine(GetLobby(0.0001f));
        }
        
        private IEnumerator GetLobby(float delay)
        {
            yield return new WaitForSeconds(delay);

            GetLobby();
        }
    }
}