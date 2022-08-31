using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolUP : MonoBehaviour
{
 public float speed;

 private bool MovingRight = true;

 public Transform groundDetection;

void Update()
 {
    transform.Translate(Vector2.right * speed * Time.deltaTime);
    
     int layer_mask = LayerMask.GetMask ("chaoInimigo");

    RaycastHit2D groundinfo = Physics2D.Raycast (groundDetection.position, Vector2.up, layer_mask);
    
    if(groundinfo.collider == false){
       
        if(MovingRight == true){
           transform.eulerAngles = new Vector3(0, -180, 0);
           MovingRight = false;
           
           } else {
            
            transform.eulerAngles = new Vector3(0, 0, 0);
            MovingRight = true;
        }
    }
 
 
 }

}
