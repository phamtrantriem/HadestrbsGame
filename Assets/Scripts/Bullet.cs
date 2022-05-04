using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform bulletTransform;
    Animator bulletAnimation;

    bool isGameOver = false;
    private void Start() {
        bulletTransform = transform.parent;
        bulletAnimation = GetComponent<Animator>();
    }

    public void RandomizeBullet() {
        
        float angle = Random.Range(0f, 360f);
        bulletTransform.RotateAround(bulletTransform.position, Vector3.forward, angle);
        
        float speed = Random.Range(1.0f, 1.0f);
        bulletAnimation.speed = speed;
        
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(FindObjectOfType<GameManager>().CheckGameOver() == false) {
            if(other.gameObject.tag == "Circle") {
                FindObjectOfType<GameManager>().IncreasingScore();
            }
            Debug.Log("trigger bullets exit");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player") {
            FindObjectOfType<GameManager>().GameOver();
            Debug.Log("trigger player enter");
        }
    }
 
}
