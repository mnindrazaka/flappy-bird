﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
  private bool isDead = false;
  public float upForce = 200f;
  private Rigidbody2D rigidbody2D;
  private Animator animator;

  // Use this for initialization
  void Start()
  {
    rigidbody2D = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (!isDead && Input.GetMouseButtonDown(0))
    {
      rigidbody2D.velocity = Vector2.zero;
      rigidbody2D.AddForce(new Vector2(0, upForce));
      animator.SetTrigger("Flap");
    }
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    rigidbody2D.velocity = Vector2.zero;
    isDead = true;
    animator.SetTrigger("Die");
    GameController.instance.BirdDied();
  }
}
