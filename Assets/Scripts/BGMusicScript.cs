using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public static BGMusicScript BGMusicInstance;
    public AudioSource musiq;
    public void Awake()
    {
        if (BGMusicInstance != null && BGMusicInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        BGMusicInstance = this;
        DontDestroyOnLoad(this);
    }

    
}
