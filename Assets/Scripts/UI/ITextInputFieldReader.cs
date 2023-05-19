namespace UI
{
    public interface ITextInputFieldReader
    {
        public void ValueChanged(string value);
        public void EditEnded(string value);
    }
}