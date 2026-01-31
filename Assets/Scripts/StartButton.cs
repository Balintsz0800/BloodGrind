using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public GameObject WeaponPanel;
    public GameObject PlayerwhipPrefab;
    public void StartGame()
    {
        WeaponPanel.SetActive(true);
    }

    public void weapon1()
    {
        SceneManager.LoadScene("GameplayScene");
        Transform SpawnPos = GameObject.Find("SpawnPos").transform;
        Instantiate(PlayerwhipPrefab, SpawnPos.position, SpawnPos.rotation);
    }
}