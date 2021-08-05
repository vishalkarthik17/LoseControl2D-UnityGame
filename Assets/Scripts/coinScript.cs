using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinScript : MonoBehaviour
{

    public float speed;
    public GameObject particleEffect;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            SFXManagerScript.SFXInstance.Playcoinsound();
            collision.GetComponent<PlayerScript>().coinCollectedEachGame++;
            Instantiate(particleEffect,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if (collision.CompareTag("DestroyerTag")) {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
