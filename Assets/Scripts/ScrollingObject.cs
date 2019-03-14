﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

  private Rigidbody2D rigidbody2D;

  // Use this for initialization
  void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
    rigidbody2D.velocity = new Vector2(GameController.instance.scrollSpeed, 0);
  }

  // Update is called once per frame
  void Update()
  {
    if (GameController.instance.gameOver)
      rigidbody2D.velocity = Vector2.zero;
  }
}
