using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
   public GameObject whip;
   public GameObject aura;

   private void Start()
   {
      DisableAllWeapons();

      switch (Data.SelectedWeapon)
      {
         case WeaponType.Whip:
           whip.SetActive(true);
           break;
         case WeaponType.Aura:
           aura.SetActive(true);
            break;
      }
   }

   void DisableAllWeapons()
   {
      whip.SetActive(false);
      aura.SetActive(false);
   }
}
