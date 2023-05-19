namespace Characters
{
    public interface ICharacterLoader
    {
        public void LoadCharacter(string playerId, byte[] data);
        public void UnloadCharacter(string playerId);
    }
}