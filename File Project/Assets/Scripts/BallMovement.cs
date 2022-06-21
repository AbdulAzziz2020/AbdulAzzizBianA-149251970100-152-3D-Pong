using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;

    [SerializeField] private GameObject particleEffect;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") || 
            collision.gameObject.CompareTag("Ball") || 
            collision.gameObject.CompareTag("Spawner"))
        {
            GameObject effect = Instantiate(particleEffect, transform.position, transform.rotation);
            Destroy(effect, 1f);

            float angleX = (transform.position.x - collision.transform.position.x) * 5f;
            float angleZ = (transform.position.z - collision.transform.position.z) * 5f;

            Vector3 direction = new Vector3(angleX, 0, angleZ).normalized;
            rb.velocity = direction  * speed;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player 1"))
        {
            Data.scorePlayer1++;
            Destroy(gameObject, 1f);
        } else if (other.gameObject.CompareTag("Player 2"))
        {
            Data.scorePlayer2++;
            Destroy(gameObject, 1f);
        } else if (other.gameObject.CompareTag("Player 3"))
        {
            Data.scorePlayer3++;
            Destroy(gameObject, 1f);
        } else if (other.gameObject.CompareTag("Player 4"))
        {
            Data.scorePlayer4++;
            Destroy(gameObject, 1f);
        }

    }
}
