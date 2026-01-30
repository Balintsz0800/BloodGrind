using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("GameplayScene");
        Time.timeScale = 1f;
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}