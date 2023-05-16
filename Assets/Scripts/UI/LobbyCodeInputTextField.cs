using UnityEngine;

namespace UI
{
    public class LobbyCodeInputTextField : MonoBehaviour, ITextInputFieldReader
    {
        public JoinLobbyButton _joinLobbyButton; 
        
        public void ValueChanged(string value)
        {
        }

        public void EditEnded(string value)
        {
            _joinLobbyButton.lobbyCode = value;
        }
    }
}