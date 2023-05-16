using Lobby;
using UnityEngine;

namespace UI
{
    public class HostLobbyButton : MonoBehaviour, IButtonPressHandler
    {
        [SerializeField] private LobbyManager LobbyManager;
        
        public void ButtonPressed()
        {
            LobbyManager.CreateLobby();
        }
    }
}