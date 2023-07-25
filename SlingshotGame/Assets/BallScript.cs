using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("OutOfBounds"))
        {
            
            Destroy(gameObject);
        }
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            CanvasScore.instance.AddPoint();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
