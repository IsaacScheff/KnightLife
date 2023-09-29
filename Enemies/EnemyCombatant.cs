public class EnemyCombatant{
    public string Name { get; }
    public int Health { get; protected set; } 
    public string Description { get; }

    protected int PreviousAttack { get; set; }
    public delegate void AttackDelegate();
    protected AttackDelegate[] Attacks;
    private static readonly Random AttackRoll = new Random();

    public EnemyCombatant(string name, int health, string description){
        Name = name;
        Health = health;
        Description = description;
    }

    public virtual void SelectAttack(){
        int attack;
        do{
            attack = AttackRoll.Next(0, Attacks.Length);
        } while (attack == this.PreviousAttack);

        Attacks[attack]();
    }
}