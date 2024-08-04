namespace CSharpCrossZeroSolution
{
    public interface IMoveAbstract
    {
        IAbstractMove NextMove();
    }
    public class PlayerMove : IMoveAbstract
    {
        public IAbstractMove NextMove()
        {
            return new HumanMove();
        }
    }

    public class ComputerMove : IMoveAbstract
    {
        public IAbstractMove NextMove()
        {
            return new AILogicMove();
        }
    }
}