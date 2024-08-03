using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utility
{
    public static void GotoCharacterScene()
    {
        SceneManager.LoadScene("CharacterScene");
    }

    public static void GoToLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }

}