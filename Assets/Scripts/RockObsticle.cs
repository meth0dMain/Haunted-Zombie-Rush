﻿using System.Collections;
using UnityEngine;

public class RockObsticle : MovingObject
{
   [SerializeField] private Vector3 topPos;
   [SerializeField] private Vector3 botPos;
   [SerializeField] private float speed = 1.0f;


   private void Start()
   {
      StartCoroutine(Move(botPos));
   }
   


   private IEnumerator Move(Vector3 target)
   {
      while (Mathf.Abs((target - transform.localPosition).y) > 0.20f)
      {
         Vector3 direction = target.y == topPos.y ? Vector3.up : Vector3.down;
         transform.localPosition += direction * Time.deltaTime * speed;
         yield return null;
      }
      Vector3 newTarget = target.y == topPos.y ? botPos : topPos;
      StartCoroutine(Move(newTarget));
   }
}
