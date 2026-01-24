using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreenButtons : MonoBehaviour
{
    public void Respawn()
    {
        SceneManager.LoadScene("GameplayScene");
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("StartScene");
    }
}