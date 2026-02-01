using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;
    
    [SerializeField] private GameObject deathScreen;
    private void Awake()
    {
        instance = this;
    }
    
    public void DeathScreen()
    {
        deathScreen.SetActive(true);
    }
}
