using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CoinDrop : MonoBehaviour
{
    [SerializeField] GameObject DropItemPrefab;
    [SerializeField] [Range(0f,1f)] float DropChance = 1f;

    private void OnDestroy()
    {
        if (Random.value < DropChance)
        {
            Transform t = Instantiate(DropItemPrefab).transform;
            t.position = transform.position;
        }
    }
}
