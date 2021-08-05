using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlReverser : MonoBehaviour
{

    public float speed;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerScript>().swapButtonSprite();
            SFXManagerScript.SFXInstance.Playcrssound();
            if (collision.GetComponent<PlayerScript>().isSwapMode == false)
                collision.GetComponent<PlayerScript>().isSwapMode = true;
            else
                collision.GetComponent<PlayerScript>().isSwapMode = false;
        }


        if (collision.CompareTag("DestroyerTag"))
        {
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
