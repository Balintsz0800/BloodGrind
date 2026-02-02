using UnityEngine;

public class WeaponLoader : MonoBehaviour
{
   public GameObject whip;

   private void Start()
   {
      DisableAllWeapons();

      switch (Data.SelectedWeapon)
      {
         case WeaponType.Whip:
           whip.SetActive(true);
           break;
      }
   }

   void DisableAllWeapons()
   {
      whip.SetActive(false);
   }
}
