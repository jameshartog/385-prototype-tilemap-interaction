using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestBallWideControl : MonoBehaviour
{
    public Tilemap floor_tilemap;
    Vector3Int[] area;
    public Tile new_tile;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Vector3Int tile_loc = floor_tilemap.WorldToCell(transform.position);
        GetPlusArea(tile_loc);

        for (int i = 0; i < area.Length; i++)
        {
            floor_tilemap.SetTile(area[i], new_tile);
        }
    }

    //[ ][0][ ]
    //[1][2][3]
    //[ ][4][ ]
    //This check will only work on continuous areas with the center being the colliding object
    private Vector3Int[] GetPlusArea(Vector3Int tile_loc)
    {
        area = new Vector3Int[5];
        area[0].y = tile_loc.y + 1; area[0].x = tile_loc.x;
        area[1].y = tile_loc.y; area[1].x = tile_loc.x + 1;
        area[2] = tile_loc;
        area[3].y = tile_loc.y; area[3].x = tile_loc.x - 1;
        area[4].y = tile_loc.y - 1; area[4].x = tile_loc.x;
        return area;
    }
}
