using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    public float spawnRangeX = 5f;
    public float spawnHeight = 5f;

    public float moveSpeed = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        SpawnBall();
        rb = GetComponent<Rigidbody2D>();
    }
    void SpawnBall()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        Vector3 spawnPosition = new Vector3(randomX, spawnHeight, 0);
        Instantiate(ballPrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        float moveDirection = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
    }
}
