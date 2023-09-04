const string gameName = "~The Game~";
bool exitGame = false;
bool inIntro = true;
string? playerInput;

GameState gameState = new GameState();


//this loop runs the game
do{
    if(inIntro){
        Console.WriteLine($"Welcome to {gameName}");
        playerInput = Console.ReadLine();
        CreateCharacter();
    }

}while(exitGame == false);

void CreateCharacter(){
    Console.WriteLine("\n\rSelect your chracter race:");
    Console.WriteLine("1. Abarimon ~description here~");
    Console.WriteLine("2. Faun ~description here~");
    Console.WriteLine("3. Harpy ~description here~");
    Console.WriteLine("4. Human ~description here~");
    Console.WriteLine("5. Onocentaur ~description here~");

    playerInput = Console.ReadLine();

    switch(playerInput){    //might need to loop all inputs for valid options
        case "1":
            gameState.playerRaceType = GameState.PlayerRace.Abarimon;
            gameState.playerStats[0] += 1; //increase in agility
            gameState.playerStats[4] -= 1; //decrease in vitality
            break;
        case "2":
            gameState.playerRaceType = GameState.PlayerRace.Faun;
            gameState.playerStats[4] += 1; //increase in vitality
            gameState.playerStats[3] -= 1; //decrease in intuition
            break;
        case "3":
            gameState.playerRaceType = GameState.PlayerRace.Harpy;
            gameState.playerStats[1] += 1; //increase in brain-smarts
            gameState.playerStats[2] -= 1; //decrease in brawn
            break;
        case "4":
            gameState.playerRaceType = GameState.PlayerRace.Human;
            gameState.playerStats[3] += 1; //increase in intuition
            gameState.playerStats[0] -= 1; //decrease in agility
            break;
        case "5":
            gameState.playerRaceType = GameState.PlayerRace.Onocentaur;
            gameState.playerStats[2] += 1; //increase in brawn
            gameState.playerStats[1] -= 1; //decrease in brain-smarts
            break;
        default:
            break;
    }

    Console.WriteLine("\n\rSelect your chracter class:");
    Console.WriteLine("1. Bestiarius ~description here~");
    Console.WriteLine("2. Cestus ~description here~");
    Console.WriteLine("3. Dimachaerus ~description here~");
    Console.WriteLine("4. Murmillo ~description here~");
    Console.WriteLine("5. Retiarius ~description here~");

    playerInput = Console.ReadLine();

    switch(playerInput){    //might need to loop all inputs for valid options
        case "1":
            gameState.playerClassType = GameState.PlayerClass.Bestiarius;
            gameState.playerStats[1] += 2; //increase in brain-smarts
            break;
        case "2":
            gameState.playerClassType = GameState.PlayerClass.Cestus;
            gameState.playerStats[2] += 2; //increase in brawn
            break;
        case "3":
            gameState.playerClassType = GameState.PlayerClass.Dimachaerus;
            gameState.playerStats[3] += 2; //increase in intuition
            break;
        case "4":
            gameState.playerClassType = GameState.PlayerClass.Murmillo;
            gameState.playerStats[4] += 2; //increase in vitality
            break;
        case "5":
            gameState.playerClassType = GameState.PlayerClass.Retiarius;
            gameState.playerStats[0] += 2; //increase in agility
            break;
        default:
            break;
    }
    Console.WriteLine($"\n\rYou have selected a {gameState.playerRaceType} {gameState.playerClassType}.");
    Console.Write($"Agility: {gameState.playerStats[0]}   ");
    Console.Write($"Brain-Smarts: {gameState.playerStats[1]}   ");
    Console.Write($"Brawn: {gameState.playerStats[2]}   ");
    Console.Write($"Intuition: {gameState.playerStats[3]}   ");
    Console.WriteLine($"Vitality: {gameState.playerStats[4]}");
}

public class GameState
{
    public int[] playerStats = {4, 4, 4, 4, 4}; //[0] = agility, [1] = brain-smarts, [2] = brawn, [3] = intuition, [4] = vitality
    public int playerHealth;
    public int playerGold;
    public PlayerClass playerClassType;
    public PlayerRace playerRaceType; // Changed name to avoid conflict with enum

    public enum PlayerClass
    {
        Bestiarius,
        Cestus,
        Dimachaerus,
        Murmillo,
        Retiarius
    }

    public enum PlayerRace
    {
        Abarimon,
        Faun,
        Harpy,
        Human,
        Onocentaur
    }
}

