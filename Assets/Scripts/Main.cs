using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<10; i++) {
            GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            float r=5f;    // distance from center
            float angle=Random.Range(0,Mathf.PI*2);    // Random angle in radians
            // sin and cos need value in radians
            // full turn aroud circle in radians equal 2*PI ~6.283185 rad
            Vector2 pos2d=new Vector2(Mathf.Sin(angle)*r,Mathf.Cos(angle)*r);
            sphere.transform.position=new Vector3(pos2d.x,pos2d.y,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float radius = 3f;
        int amountToSpawn =2;
        for (int i = 0; i < amountToSpawn; i++)
        {
            float angle = i * Mathf.PI*2f / amountToSpawn;
            Vector3 newPos = new Vector3(Mathf.Cos(angle)*radius, Mathf.Sin(angle)*radius, 0);
            GameObject go = Instantiate(GameObject.CreatePrimitive(PrimitiveType.Cube), newPos, Quaternion.identity);
        }
    }
}
