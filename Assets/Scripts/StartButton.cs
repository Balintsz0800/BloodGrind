using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject WeaponPanel;
    public void StartGame()
    {
        WeaponPanel.SetActive(true);
    }

    public void weapon1()
    {
        Data.SelectedWeapon = WeaponType.Whip;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameplayScene");
    }

    public void weapon2()
    {
        Data.SelectedWeapon = WeaponType.Aura;
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameplayScene");
    }
}