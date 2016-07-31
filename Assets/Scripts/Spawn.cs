using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {
    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;

    // Use this for initialization
    void Start () {
        spawn();
    }

    void spawn()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        Invoke("spawn", Random.Range(spawnMin, spawnMax));
    }

}
