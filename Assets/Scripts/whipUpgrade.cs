using UnityEngine;

public class whipUpgrade : MonoBehaviour
{
    public GameObject WhipUpgradePanel;
    public WhipAttack whipAttack;

    public void Damage()
    {
        whipAttack.whipDamage *= 1.15f;
        WhipUpgradePanel.SetActive(false);
    }
    public void Size()
    {
        whipAttack.whipAttackSize *= 1.05f;
        WhipUpgradePanel.SetActive(false);
    }
    public void AttackCooldown()
    {
        whipAttack.AttackTime *= 0.95f;
        WhipUpgradePanel.SetActive(false);
    }
}
