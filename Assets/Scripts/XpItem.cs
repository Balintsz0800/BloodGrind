using UnityEngine;

public class XpItem : MonoBehaviour
{
    public int XpAmount = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Character player = other.GetComponent<Character>();

            if (player != null)
            {
                player.AddXp(XpAmount);
            }
            Destroy(gameObject);
        }
    }
}
