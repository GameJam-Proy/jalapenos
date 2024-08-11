public interface IPlayerCommand<T> where T : Player
{
    void Execute(T player, double delta);
}
