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