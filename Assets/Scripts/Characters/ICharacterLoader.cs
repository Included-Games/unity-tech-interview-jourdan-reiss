namespace Characters
{
    public interface ICharacterLoader
    {
        public byte[] GetCurrentCharacter { get; }
        public void LoadCharacter(string playerId, byte[] data);
        public void UnloadCharacter(string playerId);
    }
}