using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameState
{
    None,
    Title,
    Playing,
    Paused,
    GameOver
}

public enum GameScreens
{
    MainMenu,
    Options,
    Credits,
    Game
}

public class GameController : MonoBehaviour {

	public GameState State { set; get; }
    public Stack<GameScreens> Screens = new Stack<GameScreens>();
    public GameScreens currentScreen;

    
    public GameObject MainMenuScreen;
    public GameObject OptionsScreen;
    public GameObject CreditsScreen;

    public AudioClip test;

    private bool PlayerAlreadySeen = false;

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
        State = GameState.None;
        currentScreen = GameScreens.MainMenu;
        Screens.Push(GameScreens.MainMenu);

        MainMenuScreen.SetActive(true);
        OptionsScreen.SetActive(false);
        CreditsScreen.SetActive(false);

    }

    public void TopScreen(string newScreen)
    {
        SwitchScreen(currentScreen);
        if (newScreen == "Options")
        {
            currentScreen = GameScreens.Options;
        }else if(newScreen == "Credits")
        {
            currentScreen = GameScreens.Credits;
        }
        Screens.Push(currentScreen);
        SwitchScreen(currentScreen);
    }

    public void BackScreen()
    {
        SwitchScreen(currentScreen);
        Screens.Pop();
        currentScreen = Screens.Peek();
        SwitchScreen(currentScreen);
    }

    public void SwitchScreen(GameScreens screen)
    {
        switch (screen)
        {
            case GameScreens.MainMenu:
                MainMenuScreen.SetActive(!MainMenuScreen.activeInHierarchy);
                break;
            case GameScreens.Options:
                OptionsScreen.SetActive(!OptionsScreen.activeInHierarchy);
                break;
            case GameScreens.Credits:
                CreditsScreen.SetActive(!CreditsScreen.activeInHierarchy);
                break;
        }
    }

    public void StartGame()
    {
        if (!PlayerAlreadySeen)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(2);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }


    public void ChangeLanguage(string language)
    {
        if(language == "English")
        {
            Toolbox.instance.SetLanguage(Languages.English);
        }else if (language == "Portuguese")
        {
            Toolbox.instance.SetLanguage(Languages.Portuguese);
        }
        else if (language == "Spanish")
        {
            Toolbox.instance.SetLanguage(Languages.Spanish);
        }
    }
    
}
