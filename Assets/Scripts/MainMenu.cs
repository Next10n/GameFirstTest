using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject Menu;
    public bool _isMenuOpen;
    // Use this for initialization
    public virtual void Start()
    {
        Menu = GameObject.Find("MainMenu");
    }

    // Update is called once per frame
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isMenuOpen)
                HideMenu();
            else
                ShowMenu();
        }

    }

    public void HideMenu()
    {
        Menu.SetActive(false);
        _isMenuOpen = false;
        Time.timeScale = 1;
    }

    public void ShowMenu()
    {
        Menu.SetActive(true);
        _isMenuOpen = true;
        Time.timeScale = 0;
    }

    public void Loadlevel(int lvlNumber)
    {
        Application.LoadLevel(lvlNumber);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
