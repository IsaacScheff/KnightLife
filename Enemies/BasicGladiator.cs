public class BasicGladiator : EnemyCombatant{
    public BasicGladiator(string name = "gladiator", int health = 10, string description = "description") 
        : base(name, health, description){
        Attacks = new AttackDelegate[]{
            SwingHigh,
            SwingLow,
            Stab
        };
    }

    private void SwingHigh(){
        Console.WriteLine("SwingHigh");
        this.PreviousAttack = 0;
    }

    private void SwingLow(){
        Console.WriteLine("SwingLow");
        this.PreviousAttack = 1;
    }

    private void Stab(){
        Console.WriteLine("Stab");
        this.PreviousAttack = 2;
    }
}
