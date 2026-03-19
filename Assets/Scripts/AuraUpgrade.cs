using UnityEngine;

public class AuraUpgrade : MonoBehaviour
{
    public GameObject AuraUpgradePanel;
    public GameObject Aura;
    public Aura aura;
    
    public void Damage()
    {
        aura.damage *= 1.05f;
        AuraUpgradePanel.SetActive(false);
    }

    public void Range()
    {
        Aura.transform.localScale *= 1.05f;
        AuraUpgradePanel.SetActive(false);
    }

    public void AttackRate()
    {
        aura.tick *= 0.95f;
        AuraUpgradePanel.SetActive(false);
    }
}
