namespace Assets.YundosArrow.Scripts.Player.Movement
{
    public abstract class Decision
    {
		public abstract bool Decide(PlayerState currentState);
	}
}