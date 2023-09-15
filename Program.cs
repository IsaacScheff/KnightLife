using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

const string gameName = "~The Game~";
const string invalidEntry = "Selection not understood. Please type either the number or title of your selection and press Enter.";
bool exitGame = false;
bool inIntro = true;
string? playerInput;
string playerSelection;

GameState gameState = new GameState();


//this loop runs the game
do{
    if(inIntro){
        Console.WriteLine($"\t\tWelcome to {gameName}\n\rPress Enter to continue");
        playerInput = Console.ReadLine();
        CreateCharacter();
    }

    BasicGladiator gladiator = new BasicGladiator("GladiatorName", 150, "A fierce gladiator");


}while(exitGame == false);

void CreateCharacter(){
    Console.WriteLine("\n\rSelect your chracter race:");
    Console.WriteLine("1. Abarimon: ~description here~");
    Console.WriteLine("2. Faun: ~description here~");
    Console.WriteLine("3. Harpy: ~description here~");
    Console.WriteLine("4. Human: ~description here~");
    Console.WriteLine("5. Onocentaur: ~description here~");

    bool raceSelected = false;
    while(raceSelected == false){
        playerSelection = PlayerSelection(Console.ReadLine());

        raceSelected = true;
        switch(playerSelection){   
            case "1": case "abarimon": 
                gameState.playerRaceType = GameState.PlayerRace.Abarimon;
                gameState.playerStats[0] += 1; //increase in agility
                gameState.playerStats[2] -= 1; //decrease in brawn
                break;
            case "2": case "faun":
                gameState.playerRaceType = GameState.PlayerRace.Faun;
                gameState.playerStats[4] += 1; //increase in vitality
                gameState.playerStats[3] -= 1; //decrease in intuition
                break;
            case "3": case "harpy":
                gameState.playerRaceType = GameState.PlayerRace.Harpy;
                gameState.playerStats[1] += 1; //increase in brain-smarts
                gameState.playerStats[4] -= 1; //decrease in vitality
                break;
            case "4": case "human":
                gameState.playerRaceType = GameState.PlayerRace.Human;
                gameState.playerStats[3] += 1; //increase in intuition
                gameState.playerStats[0] -= 1; //decrease in agility
                break;
            case "5": case "onocentaur":
                gameState.playerRaceType = GameState.PlayerRace.Onocentaur;
                gameState.playerStats[2] += 1; //increase in brawn
                gameState.playerStats[1] -= 1; //decrease in brain-smarts
                break;
            default:
                Console.WriteLine(invalidEntry);
                raceSelected = false;
                break;
        }
    }

    Console.WriteLine("\n\rSelect your chracter class:");
    Console.WriteLine("1. Bestiarius ~description here~");
    Console.WriteLine("2. Cestus ~description here~");
    Console.WriteLine("3. Dimachaerus ~description here~");
    Console.WriteLine("4. Murmillo ~description here~");
    Console.WriteLine("5. Retiarius ~description here~");

    bool classSelected = false;
    while(classSelected == false){
        playerSelection = PlayerSelection(Console.ReadLine());

        classSelected = true;
        switch(playerSelection){    
            case "1": case "bestiarius":
                gameState.playerClassType = GameState.PlayerClass.Bestiarius;
                gameState.playerStats[1] += 2; //increase in brain-smarts
                break;
            case "2": case "cestus":
                gameState.playerClassType = GameState.PlayerClass.Cestus;
                gameState.playerStats[2] += 2; //increase in brawn
                break;
            case "3": case "dimachaerus":
                gameState.playerClassType = GameState.PlayerClass.Dimachaerus;
                gameState.playerStats[3] += 2; //increase in intuition
                break;
            case "4": case "murmillo":
                gameState.playerClassType = GameState.PlayerClass.Murmillo;
                gameState.playerStats[4] += 2; //increase in vitality
                break;
            case "5": case "retiarius":
                gameState.playerClassType = GameState.PlayerClass.Retiarius;
                gameState.playerStats[0] += 2; //increase in agility
                break;
            default:
                Console.WriteLine(invalidEntry);
                classSelected = false;
                break;
        }
    }
    Console.WriteLine($"\n\rYou have selected a {gameState.playerRaceType} {gameState.playerClassType}.");
    Console.Write($"Agility: {gameState.playerStats[0]}   ");
    Console.Write($"Brain-Smarts: {gameState.playerStats[1]}   ");
    Console.Write($"Brawn: {gameState.playerStats[2]}   ");
    Console.Write($"Intuition: {gameState.playerStats[3]}   ");
    Console.WriteLine($"Vitality: {gameState.playerStats[4]}");
}

void HandleCombat(){
    //takes in enemy as argument

    //randomly select attack from list of enemy options
    //display intended enemy attack 
    //player makes choice
    //loop

    //if player dies ends the run
    //on a win get gold or other rewards
}

string PlayerSelection(string? playerInput){
    return playerInput?.ToLower() ?? "No selection";
}

public class GameState{
    public int[] playerStats = {4, 4, 4, 4, 4}; //[0] = agility, [1] = brain-smarts, [2] = brawn, [3] = intuition, [4] = vitality
    public int playerHealth;
    public int playerGold;
    public int renown;
    public PlayerClass playerClassType;
    public PlayerRace playerRaceType; // Changed name to avoid conflict with enum

    public enum PlayerClass{
        Bestiarius,
        Cestus,
        Dimachaerus,
        Murmillo,
        Retiarius
    }

    public enum PlayerRace{
        Abarimon,
        Faun,
        Harpy,
        Human,
        Onocentaur
    }
}

public class EnemyCombatant{
    public string? Name { get; set; }
    public int Health { get; set; }
    public string? Description { get; set; }
    public EnemyCombatant(string name, int health, string description){
    }
    public int previousAttack;
    public delegate void AttackDelegate();
    protected AttackDelegate[]? Attacks;
    private static readonly Random attackRoll = new Random();

    public void SelectAttack(){
        int attack;
        do {
            attack = attackRoll.Next(0, Attacks?.Length ?? 0);  // Assuming 3 possible attacks indexed 1, 2, 3
        } while (attack == this.previousAttack);
        Attacks?[attack]();
    }
    //could also define some default attacks here? like stab and swing high/low 
}

public class BasicGladiator : EnemyCombatant{
    public BasicGladiator(string name, int health, string description) : base(name, health, description) {
        Attacks = new AttackDelegate[]{
            SwingHigh,
            SwingLow,
            Stab
        };
    }
    public void SwingHigh(){
        Console.WriteLine("SwingHigh");
        this.previousAttack = 0;
    }
    public void SwingLow(){
        Console.WriteLine("SwingLow");
        this.previousAttack = 1;
    }
    public void Stab(){
        Console.WriteLine("Stab");
        this.previousAttack = 2;
    }
}

