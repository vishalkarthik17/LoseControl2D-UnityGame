using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            collision.GetComponent<PlayerScript>().gameoverFunc();
            //Debug.Log(collision.GetComponent<PlayerScript>().isAlive);
            Destroy(gameObject);
        }

        if (collision.CompareTag("DestroyerTag") ) {
            Destroy(gameObject);
        }

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down*speed*Time.deltaTime);
        
    }
}
