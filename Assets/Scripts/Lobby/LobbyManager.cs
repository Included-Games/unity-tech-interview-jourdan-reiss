using Unity.Services.Lobbies;

namespace Lobby
{
    public class LobbyManager
    {
        public Unity.Services.Lobbies.Models.Lobby CreateLobby()
        {
            var task = Lobbies.Instance.CreateLobbyAsync("MyLobby", 4, new CreateLobbyOptions()
            {
                IsPrivate = true
            });
            return task.GetAwaiter().GetResult();
        }

        public Unity.Services.Lobbies.Models.Lobby JoinLobby(string lobbyCode)
        {
            var task = Lobbies.Instance.JoinLobbyByCodeAsync(lobbyCode);
            return task.GetAwaiter().GetResult();
        }
    }
}