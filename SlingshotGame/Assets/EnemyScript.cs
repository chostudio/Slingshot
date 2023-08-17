using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private float speedy;

    // Start is called before the first frame update
    void Start()
    {
        speedy = Random.Range(-3.0f, -1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position += new Vector3(0, speedy, 0) * Time.deltaTime;
        
    }

}
