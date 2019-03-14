﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour
{

  public GameObject columnPrefab;
  public int columnPoolSize = 5;
  public float spawnRate = 3f;
  public float columnMin = -2f;
  public float columnMax = 2f;

  private GameObject[] columns;
  private int currentColumn = 0;
  private float spawnXPosition = 10f;
  private float timeSinceLastSpawned;

  // Use this for initialization
  void Start()
  {
    timeSinceLastSpawned = 0f;

    columns = new GameObject[columnPoolSize];
    for (int i = 0; i < columnPoolSize; i++)
    {
      columns[i] = Instantiate(columnPrefab);
    }
  }

  // Update is called once per frame
  void Update()
  {
    timeSinceLastSpawned += Time.deltaTime;

    if (!GameController.instance.gameOver && timeSinceLastSpawned >= spawnRate)
    {
      timeSinceLastSpawned = 0f;
      float spawnYPosition = Random.Range(columnMin, columnMax);
      columns[currentColumn].transform.position = new Vector2(spawnXPosition, spawnYPosition);

      currentColumn++;
      if (currentColumn >= columnPoolSize)
      {
        currentColumn = 0;
      }
    }
  }
}
