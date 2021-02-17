using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
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
        if (input == "1")
        {
            level = 1;
            password = "cash";
            StartGame();
        }
        else if (input == "2")
        {
            level = 2;
            password = "agent";
            StartGame();
        }
        else if (input == "3")
        {
            level = 3;
            password = "alien";
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
        Terminal.WriteLine("You have selected level " + level);
        Terminal.WriteLine("Please enter your password: ");
    }

    void GetPassword(string input)
    {

        if(input == password)
        {
            Terminal.WriteLine("Congrats on cracking the password!");
        }
        else
        {
            Terminal.WriteLine("Try Again...");
            StartGame();
        }
    }
}
