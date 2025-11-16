using System;
using JetBrains.Annotations;
using UnityEngine;

public class WorldScrolling : MonoBehaviour
{
   [SerializeField] Transform playerTransform;
   Vector2Int currentTilePos = new Vector2Int(0,0);
   [SerializeField] Vector2Int playerTilePos;
   Vector2Int onTileGridPlayerPos;
   [SerializeField] float tileSize = 20f;
   GameObject[,] terrainTiles;
   
   [SerializeField] int TerrainTileHorizontalCount;
   [SerializeField] int TerrainTileVerticalCount;
   
   [SerializeField] int fieldOfVisionHeight = 3;
   [SerializeField] int fieldOfVisionWidth = 3;

   void Awake()
   {
      terrainTiles = new GameObject[TerrainTileHorizontalCount, TerrainTileVerticalCount];
   }

   void Start()
   {
      UpdateTilesOnScreen();
   }

   private void Update()
   {
      playerTilePos.x = (int)(playerTransform.position.x / tileSize);
      playerTilePos.y = (int)(playerTransform.position.y / tileSize);
      
      playerTilePos.x -= playerTransform.position.x < 0 ? 1 : 0;
      playerTilePos.y -= playerTransform.position.y < 0 ? 1 : 0;

      if (currentTilePos != playerTilePos)
      {
         currentTilePos = playerTilePos;

         onTileGridPlayerPos.x = CalculatePosOnAxis(onTileGridPlayerPos.x, true);
         onTileGridPlayerPos.y = CalculatePosOnAxis(onTileGridPlayerPos.y, false);
         UpdateTilesOnScreen();
      }
   }

   private void UpdateTilesOnScreen()
   {
      for (int pov_x = -(fieldOfVisionWidth/2); pov_x <= fieldOfVisionWidth/2; pov_x++)
      {
         for (int pov_y = -(fieldOfVisionHeight/2); pov_y <= fieldOfVisionHeight/2; pov_y++)
         {
            int tileToUpdate_x = CalculatePosOnAxis(playerTilePos.x + pov_x, true);
            int tileToUpdate_y = CalculatePosOnAxis(playerTilePos.y + pov_y, false);
            
            GameObject tile = terrainTiles[tileToUpdate_x,tileToUpdate_y];
            tile.transform.position = CalculateTilePos(playerTilePos.x + pov_x, playerTilePos.y + pov_y);
         }
      }
   }

   private Vector3 CalculateTilePos(int x, int y)
   {
      return new Vector3(x * tileSize, y * tileSize, 0f);
   }

   private int CalculatePosOnAxis(int currentValue, bool horizontal)
   {

      if (horizontal)
      {
         if (currentValue >= 0)
         {
            currentValue = currentValue % TerrainTileHorizontalCount;
         }
         else
         {
            currentValue += 1;
            currentValue = TerrainTileHorizontalCount - 1 + currentValue % TerrainTileHorizontalCount;
         }
      }
      else
      {
         if (currentValue >= 0)
         {
            currentValue = currentValue % TerrainTileVerticalCount;
         }
         else
         {
            currentValue += 1;
            currentValue = TerrainTileVerticalCount - 1 + currentValue % TerrainTileVerticalCount;
         }
      } 
      return currentValue;
   }
   public void Add(GameObject tileGameObject, Vector2Int tilePos)
   {
      terrainTiles[tilePos.x, tilePos.y] = tileGameObject;
   }
}