using UnityEngine;

public class TerrainTile : MonoBehaviour
{
    [SerializeField] Vector2Int tilePos;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponentInParent<WorldScrolling>().Add(gameObject, tilePos);
        
        transform.position = new Vector3(-100, -100, 0);
    }
}