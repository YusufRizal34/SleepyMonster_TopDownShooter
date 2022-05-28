using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region Main Menu
    public void Stage1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_01");
    }

    public void Stage2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_02");
    }

    public void Stage3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_03");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }
    

    public void SelectStage()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SelecStage");
    }
    #endregion

    public void RetryButtonLv1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_01");
    }

    public void RetryButtonLv2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_02");
    }

    public void RetryButtonLv3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level_03");
    }

    public void NextButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackButton()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
