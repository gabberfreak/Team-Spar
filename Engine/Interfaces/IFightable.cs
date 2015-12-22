namespace Engine.Interfaces
{
    public interface IFightable
    {
        int CurrentHealth { get; set; }
        int MaxHealth { get; }
        int Defence { get; }
        int Damage { get; }
        void Attack(IFightable target);

    }
}
