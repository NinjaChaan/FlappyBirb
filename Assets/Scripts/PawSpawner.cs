using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawSpawner : MonoBehaviour
{
    public static PawSpawner instance;

    private void Awake() {
        if(instance!= null) {
            Destroy(instance.gameObject);
        }

        instance = this;

        DontDestroyOnLoad(this.gameObject);
    }

    float minY = -60f;
    float maxY = -13f;

    public GameObject kitiPawPrefab;

    List<GameObject> kitiPaws = new List<GameObject>();

    private void Start() {
        StartCoroutine(SpawnPawsRoutine());
    }

    IEnumerator SpawnPawsRoutine() {
        while (true) {
            kitiPaws.Add(SimplePool.Spawn(kitiPawPrefab, new Vector2(transform.position.x + 120f, Random.Range(minY, maxY)), Quaternion.identity, transform));
            if(kitiPaws.Count > 2) {
                SimplePool.Despawn(kitiPaws[0]);
                kitiPaws.Remove(kitiPaws[0]);
            }
            yield return new WaitForSeconds(2f);
        }
    }
}
