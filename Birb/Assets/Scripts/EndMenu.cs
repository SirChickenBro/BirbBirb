using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public void restartGame()
    {
        SceneManager.LoadScene("Welcome");
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
