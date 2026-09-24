using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject branchPrefab;

    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float changeDirChance = 0.1f;
    public float appleDropDelay = 1f;

    // Keeps the tree from running before Start is pressed
    public bool gameStarted = false;

    void Start()
    {
        // Do NOT start dropping objects yet
    }

    public void StartGame()
    {
        gameStarted = true;

        // Start dropping apples/branches
        Invoke("DropApple", 2f);
    }

    void DropApple()
    {
        if (!gameStarted)
        {
            return;
        }

        GameObject fallingObject;

        // 5% chance of branch falling
        if (Random.value < 0.20f)
        {
            fallingObject = Instantiate<GameObject>(branchPrefab);
        }
        else
        {
            fallingObject = Instantiate<GameObject>(applePrefab);
        }

        fallingObject.transform.position = transform.position;

        Invoke("DropApple", appleDropDelay);
    }

    void Update()
    {
        // Don't move the tree until the game starts
        if (!gameStarted)
        {
            return;
        }

        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
    }

    void FixedUpdate()
    {
        // Don't change direction until the game starts
        if (!gameStarted)
        {
            return;
        }

        if (Random.value < changeDirChance)
        {
            speed *= -1;
        }
    }
}
