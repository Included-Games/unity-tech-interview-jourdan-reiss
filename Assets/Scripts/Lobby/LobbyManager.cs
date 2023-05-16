using System.Collections;
using Unity.Services.Lobbies;
using UnityEngine;
using UnityEngine.UI;

namespace Lobby
{
    public class LobbyManager : MonoBehaviour
    {
        [SerializeField] private Button playButton;
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
                if (lobby.Players.Count > 1)
                {
                    playButton.gameObject.SetActive(true);
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