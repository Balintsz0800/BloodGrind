using UnityEngine;

public class SelectedWeaponUpgrade : MonoBehaviour
{
    public GameObject WhipUpgradePanel;
    public GameObject AuraUpgradePanel;
    
    public void Upgrade()
    {
        if (Data.SelectedWeapon == WeaponType.Whip)
        {
            WhipUpgradePanel.SetActive(true);
        }
        else if (Data.SelectedWeapon == WeaponType.Aura)
        {
            AuraUpgradePanel.SetActive(true);
        }
    }
}
