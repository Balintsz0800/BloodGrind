using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinDrop : MonoBehaviour
{
    [SerializeField] GameObject DropItemPrefab;
    [SerializeField] GameObject DropHealItemPrefab;
    [SerializeField] [Range(0f,1f)] float DropChance = 1f;
    [SerializeField] [Range(0f,1f)] float HealDropChance = 1f;

    private void OnDestroy()
    {
        if (Random.value < DropChance)
        {
            Transform t = Instantiate(DropItemPrefab).transform;
            t.position = transform.position;
        }
        else if  (Random.value < HealDropChance)
        {
            Transform t = Instantiate(DropHealItemPrefab).transform;
            t.position = transform.position;
        }
    }
}
