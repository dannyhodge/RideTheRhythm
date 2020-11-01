using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoMove : MonoBehaviour
{
   public float scrollSpeed = 5.0f;
  
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right *  Time.deltaTime * scrollSpeed);
    }

}
