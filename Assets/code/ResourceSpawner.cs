using System.Collections;
using UnityEngine;

public class ResourceSpawner : MonoBehaviour {
    public ResourceType resourceType;
    public float timer = 5;

    void Start(){
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn(){
        while (true){
            yield return new WaitForSeconds(timer);
            Vector3 spawnPos = new(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));
            switch (resourceType){
                case ResourceType.stone:
                    Instantiate(GameManager.gameManager.stone, transform.position + spawnPos, Quaternion.identity).transform.parent = transform;
                    break;

                case ResourceType.iron:
                    Instantiate(GameManager.gameManager.iron, transform.position + spawnPos, Quaternion.identity).transform.parent = transform;
                    break;

                case ResourceType.emerald:
                    Instantiate(GameManager.gameManager.emerald, transform.position + spawnPos, Quaternion.identity).transform.parent = transform;
                    break;
            }
        }
    }
}

public enum ResourceType{
    none,
    stone,
    emerald,
    iron
}