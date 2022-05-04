using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{   
    public float moveSpeed = 5f;
    float xInput, yInput;

    float maxDistance = 3.2f;
    float actualDistance;
    
    private void Update() {
        xInput = Input.GetAxisRaw("Horizontal");
        yInput = Input.GetAxisRaw("Vertical");


        Vector2 centerVector = new Vector2(0, 0);
        Vector2 position = transform.position;

        actualDistance = Vector2.Distance(centerVector, position);
 
        if (actualDistance > maxDistance)
        {
            Vector2 centerToPosition = position;
            centerToPosition.Normalize();
            //Debug.Log(centerToPosition);
            position = centerToPosition * maxDistance;
            transform.Translate(-position*Time.deltaTime);
            return;
        }
        transform.Translate(xInput*moveSpeed*Time.deltaTime, yInput*moveSpeed*Time.deltaTime, 0);
    }

    private void OnEnable() {
        Vector3 position = transform.position;
        position.y = 0f;
        position.x = 0f;
        transform.position = position * Time.deltaTime * Time.deltaTime;
    }    
}
