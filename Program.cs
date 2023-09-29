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

    HandleCombat(gladiator);


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
        playerSelection = HandleInput(Console.ReadLine());

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
        playerSelection = HandleInput(Console.ReadLine());

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

void HandleCombat(EnemyCombatant enemy){

    bool isPlayerAlive = true;
    bool isEnemyAlive = true;

    Console.WriteLine($"\n\rYou enter the arena to face a {enemy.Name}");

    while(isPlayerAlive && isEnemyAlive)
    {
        // Enemy selects an attack.
        enemy.SelectAttack();

        // (Optional) Display intended enemy attack. This depends on game mechanics.
        //Console.WriteLine($"Enemy is preparing to {enemy.CurrentAttackName}!");

        // Player makes their move.
        Console.WriteLine("Choose your move");
        playerInput = Console.ReadLine()?.ToLower();
        //method for player move selection

        //resolve player attack

        // 5. Check if player or enemy is defeated.
        if(!isEnemyAlive)
        {
            Console.WriteLine($"You defeated the {enemy.Name}!");
            // Add rewards, gold, etc.
            GivePlayerRewards();
            break;
        }

        if(!isPlayerAlive)
        {
            Console.WriteLine("You have been defeated.");
            // End game or other logic here.
            // EndGame();
            break;
        }
    }
}

string HandleInput(string? playerInput){
    return playerInput?.ToLower() ?? "No selection";
}

void GivePlayerRewards(){
    Console.WriteLine("Give Player rewards function");
}


