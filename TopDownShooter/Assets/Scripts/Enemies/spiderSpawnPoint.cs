using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderSpawnPoint : MonoBehaviour
{
    public GameObject spider;

    private void Start()
    {
        trigger.bossevent += () => { StartCoroutine(nameof(spawnSpider)); };
    }



    public IEnumerator spawnSpider()
    {
        while (true)
        {
            Instantiate(spider, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(10);
        }
    }
}
