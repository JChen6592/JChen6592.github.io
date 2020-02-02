using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string playGameLevel;
    public string theInstruction;
    public string mainMenuLevel;
    public string aboutScene;
    public string theCredits;

    public void PlayGame()
    {
        SceneManager.LoadScene(playGameLevel);
    }

    public void ViewInstruction()
    {
        SceneManager.LoadScene(theInstruction);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(mainMenuLevel);
    }

    public void GameAbout()
    {
        SceneManager.LoadScene(aboutScene);
    }

    public void Credits()
    {
        SceneManager.LoadScene(theCredits);
    }
}
