using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public Transform[] spawnPoint;
    public int ActiveSpawnPoint;

    public Vector3 GetSpawnPoint()
    {
        return spawnPoint[ActiveSpawnPoint].transform.position;
    }

    public void SetSpawnPoint(int NewSpawnPoint)
    {
        ActiveSpawnPoint = NewSpawnPoint;
    }
}
