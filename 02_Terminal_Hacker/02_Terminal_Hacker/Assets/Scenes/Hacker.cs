using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Data.
    string[] level1Password = { "account", "transaction", "receipt", "cashflow", "routing"};
    string[] level2Password = { "assaulted", "undercover", "tactical", "detective", "domestic" };
    string[] level3Password = { "nevada", "extraterrestrial", "conspiracy", "theories", "oxcart" };
    // Game State.
    int level;
    enum Screen { MainMenu, Password, Win };
    Screen currentScreen;
    string password;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for the local bank.");
        Terminal.WriteLine("Press 2 for the F.B.I.");
        Terminal.WriteLine("Press 3 for Area 51.");
        Terminal.WriteLine("Enter your selection: ");
    }
    

    void OnUserInput(string input)
    {
        if(input == "menu")
        {
            ShowMainMenu();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.Password)
        {
            GetPassword(input);
        }

    }

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if(isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }
        else if (input == "007")
        {
            Terminal.WriteLine("Choose a level Mr.Bond.");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid level.");
        }
    }

    void StartGame()
    {
        currentScreen = Screen.Password;
        Terminal.ClearScreen();
        SelectPassword();
        Terminal.WriteLine("Enter your password: " + password.Anagram());
    }



    private void SelectPassword()
    {
        switch (level)
        {

            case 1:
                password = level1Password[RandomPassword(level1Password)];
                break;
            case 2:
                password = level2Password[RandomPassword(level2Password)];
                break;
            case 3:
                password = level3Password[RandomPassword(level3Password)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    private int RandomPassword(string[] password)
    {
        return Random.Range(0, password.Length);
    }

    void GetPassword(string input)
    {
        if(input == password)
        {
            DisplayWinScreen();

        }
        else
        {
            StartGame();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
    }

     void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Cracked the level 1 password!");
                Terminal.WriteLine("\n");
                Terminal.WriteLine("Cash Money.");
                Terminal.WriteLine("\n");
                StartGameOver();
                break;
            case 2:
                Terminal.WriteLine("Cracked the level 2 password!");
                Terminal.WriteLine("\n");
                Terminal.WriteLine("Kill Confirmed!!");
                Terminal.WriteLine("\n");
                StartGameOver();
                break;
            case 3:
                Terminal.WriteLine("Cracked the level 3 password!");
                Terminal.WriteLine("\n");
                Terminal.WriteLine("We are not alone");
                Terminal.WriteLine("\n");
                StartGameOver();
                break;
            default:
                Terminal.WriteLine("Wrong password. Try Again.");
                break;
        } 
        
    }

    void StartGameOver()
    {
        Terminal.WriteLine("Type 'menu' to return to main menu.");
    }
}
