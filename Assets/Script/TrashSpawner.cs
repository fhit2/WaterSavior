using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] trashPrefab;
    [SerializeField] float secondSpawn;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;
    void Start()
    {
        StartCoroutine(TrashSpawn());
    }

    IEnumerator TrashSpawn()
    {
        while (true) {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(trashPrefab[Random.Range(0, trashPrefab.Length)],
            position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);
            Destroy(gameObject, 5f);
        }
    }

}
