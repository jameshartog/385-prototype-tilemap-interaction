using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TestBallWallChange : MonoBehaviour
{
    public Tilemap floor_tilemap;
    Vector3[] area;
    public Tile new_tile0;
    public Tile new_tile2;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetPlusArea(transform.position);

        for (int i = 0; i < area.Length; i++)
        {
            Vector3Int tile_loc = floor_tilemap.WorldToCell(area[i]);
            if (floor_tilemap.GetTile(tile_loc) == new_tile0) 
            {
                floor_tilemap.SetTile(tile_loc, new_tile2);
            }
            else if (floor_tilemap.GetTile(tile_loc) == new_tile2)
            {
                floor_tilemap.SetTile(tile_loc, new_tile0);
            }
        }
    }

    //[0][1][2]
    //[3][4][5]
    //[6][7][8]
    //0.5f is grid cell size
    private Vector3[] GetPlusArea(Vector3 world_loc)
    {
        area = new Vector3[9];
        area[0] = new Vector3(world_loc.x - 0.5f, world_loc.y + 0.5f, 0);
        area[1] = new Vector3(world_loc.x, world_loc.y + 0.5f, 0);
        area[2] = new Vector3(world_loc.x + 0.5f, world_loc.y + 0.5f, 0);
        area[3] = new Vector3(world_loc.x - 0.5f, world_loc.y, 0);
        area[4] = new Vector3(world_loc.x, world_loc.y, 0);
        area[5] = new Vector3(world_loc.x + 0.5f, world_loc.y, 0);
        area[6] = new Vector3(world_loc.x - 0.5f, world_loc.y - 0.5f, 0);
        area[7] = new Vector3(world_loc.x, world_loc.y - 0.5f, 0);
        area[8] = new Vector3(world_loc.x + 0.5f, world_loc.y - 0.5f, 0);
        //Debug.Log(area[0] + "," + area[1] + "," + area[2]);
        //Debug.Log(area[3] + "," + area[4] + "," + area[5]);
        //Debug.Log(area[6] + "," + area[7] + "," + area[8]);
        return area;
    }
}
