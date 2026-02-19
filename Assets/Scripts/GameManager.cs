using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum Difficulty { Tutorial, Easy, Medium, Hard, Hell }

    public static Difficulty selectedDifficulty = Difficulty.Easy;
    public static float GetTreeSpeed()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 3f;
            case Difficulty.Easy:     return 6f;
            case Difficulty.Medium:   return 10f;
            case Difficulty.Hard:     return 15f;
            case Difficulty.Hell:     return 20f;
            default:                  return 6f;
        }
    }

    public static float GetAppleDropDelay()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 2.5f;
            case Difficulty.Easy:     return 1.5f;
            case Difficulty.Medium:   return 1.0f;
            case Difficulty.Hard:     return 0.7f;
            case Difficulty.Hell:     return 0.4f;
            default:                  return 1.5f;
        }
    }

    public static float GetChangeDirChance()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 0.005f;
            case Difficulty.Easy:     return 0.01f;
            case Difficulty.Medium:   return 0.02f;
            case Difficulty.Hard:     return 0.035f;
            case Difficulty.Hell:     return 0.05f;
            default:                  return 0.01f;
        }
    }

    public static int GetNumBaskets()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 5;
            case Difficulty.Easy:     return 3;
            case Difficulty.Medium:   return 3;
            case Difficulty.Hard:     return 2;
            case Difficulty.Hell:     return 1;
            default:                  return 3;
        }
    }

    public static float GetBasketWidth()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 6f;
            case Difficulty.Easy:     return 4f;
            case Difficulty.Medium:   return 3.5f;
            case Difficulty.Hard:     return 3f;
            case Difficulty.Hell:     return 2f;
            default:                  return 4f;
        }
    }

    public static float GetAppleGravityScale()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 0.5f;
            case Difficulty.Easy:     return 1.0f;
            case Difficulty.Medium:   return 1.2f;
            case Difficulty.Hard:     return 1.5f;
            case Difficulty.Hell:     return 2.0f;
            default:                  return 1.0f;
        }
    }

    public static int GetWinTarget()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return 5;
            case Difficulty.Easy:     return 20;
            case Difficulty.Medium:   return 35;
            case Difficulty.Hard:     return 50;
            case Difficulty.Hell:     return 75;
            default:                  return 20;
        }
    }

    public static bool UsesTwoTrees()
    {
        return selectedDifficulty == Difficulty.Hell;
    }

    public static string GetDifficultyName()
    {
        switch (selectedDifficulty)
        {
            case Difficulty.Tutorial: return "Tutorial";
            case Difficulty.Easy:     return "Easy";
            case Difficulty.Medium:   return "Medium";
            case Difficulty.Hard:     return "Hard";
            case Difficulty.Hell:     return "HELL";
            default:                  return "Easy";
        }
    }
}