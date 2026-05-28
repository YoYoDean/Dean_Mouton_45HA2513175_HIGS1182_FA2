using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Restart();
        }
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            MainMenu();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("EndlessMode");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    } 
    public void EndlessMode()
    {
        SceneManager.LoadScene("EndlessMode");
    } 

    public void MainMenu()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("Start");
    } 

    public void GameOver()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("GameOver");
    } 
}