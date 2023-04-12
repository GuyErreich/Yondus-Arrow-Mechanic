namespace Assets.YundosArrow.Scripts.Enemy.Movement
{
    public abstract class Decision
    {
		public abstract bool Decide(EnemyState currentState);
	}
}