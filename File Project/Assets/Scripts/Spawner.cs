using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoint;
    [SerializeField] private GameObject spawnGameObject;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeBetweenSpawn = 1f;

    private float timeSpawn = 1f;

    private void Update()
    {
        if(timeSpawn < 0 && GameObject.FindGameObjectsWithTag("Ball").Length <= 5 && !Data.isWin)
        {
            int rand = Random.Range(0, spawnPoint.Length);
            GameObject ball = Instantiate(spawnGameObject, spawnPoint[rand].position, spawnPoint[rand].rotation);
            ball.GetComponent<Rigidbody>().velocity = spawnPoint[rand].transform.forward * speed;

            timeSpawn = timeBetweenSpawn;
        } else {
            timeSpawn -= Time.deltaTime;
        }
    }
}
