using Lobby;
using UnityEngine;

namespace UI
{
    public class JoinLobbyButton : MonoBehaviour, IButtonPressHandler
    {
        [SerializeField] private LobbyManager LobbyManager;
        public string lobbyCode;

        public void ButtonPressed()
        {
            LobbyManager.JoinLobby(lobbyCode);
        }
    }
}