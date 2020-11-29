using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    public GameObject prefab = null;
    public Transform spawn = null;
    private float minTime = 3f;
    private float maxTime = 10f;

    private void Start()
    {
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
    private void SpawnObstacle()
    {
        GameObject go = Instantiate(prefab);
        go.transform.position = new Vector3(spawn.position.x, spawn.position.y, spawn.position.z);
        go.transform.rotation = new Quaternion(-1f, -1f, -1f, -1f);
        Invoke("SpawnObstacle", Random.Range(minTime, maxTime));
    }
}
