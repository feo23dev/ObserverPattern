using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject eggPrefab;
    public Terrain terrain;

    TerrainData terrainData;
    // Start is called before the first frame update
    public Event eggDrop;
    void Start()
    {
        terrainData = terrain.terrainData;
        InvokeRepeating("CreateEgg",1,0.1f);
    }


    void CreateEgg()
    {
        int x = (int) Random.Range(0, terrainData.size.x);
        int z = (int) Random.Range(0, terrainData.size.z);
        Vector3 pos = new Vector3(x,0,z);
        pos.y = terrain.SampleHeight(pos) + 10;

        GameObject egg = Instantiate(eggPrefab,pos,Quaternion.identity);
        eggDrop.Occured(egg);

    }

    
}
