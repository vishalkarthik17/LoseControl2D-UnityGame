using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SFXManagerScript : MonoBehaviour
{
    public static SFXManagerScript SFXInstance;
    public AudioSource SFXAudio;
    public AudioClip btn, coin, crs, gameover;
 
     private void Start()
    {
       // Debug.Log("SFXManagerStart");
    }

    public void Awake()
    {
        if (SFXInstance != null && SFXInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        SFXInstance = this;
        
        DontDestroyOnLoad(this);
    }
    public void Playbtnsound() {
        SFXInstance.SFXAudio.PlayOneShot(btn);
    }
    public void Playcoinsound()
    {
        SFXInstance.SFXAudio.PlayOneShot(coin);
    }
    public void Playcrssound()
    {
        SFXInstance.SFXAudio.PlayOneShot(crs);
    }
    public void Playgameoversound()
    {
        SFXInstance.SFXAudio.PlayOneShot(gameover);
    }

    

}
