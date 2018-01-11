namespace FGLib.InputHandling
{
    public interface IInputMapper<T>
    {
        int MapInput(T input);
    }
}
