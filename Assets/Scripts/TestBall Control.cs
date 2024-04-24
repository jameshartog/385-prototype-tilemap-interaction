using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestBallControl : MonoBehaviour
{
    public Tilemap floor_tilemap;
    public Tile new_tile;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3Int tile_loc = floor_tilemap.WorldToCell(transform.position);
        floor_tilemap.SetTile(tile_loc, new_tile);
        //Debug.Log(transform.position + "\n" + tile_loc);
    }
}
