using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public Animator Fade;
    public float transitionTime;
    public void LoadPlay() {
        
        StartCoroutine(SceneLoadWithFadeTransitions("SampleScene"));
    }
    public void LoadShop() {
        
        StartCoroutine(SceneLoadWithFadeTransitions("Shop"));
    }
    public void LoadMenu() {
       
        StartCoroutine(SceneLoadWithFadeTransitions("MainMenu"));
    }
    
    IEnumerator SceneLoadWithFadeTransitions(string scenename)
    {
        
       // Debug.Log("calling trigger");
        Fade.SetTrigger("FadeTransition");
        yield return new WaitForSeconds(transitionTime);        
       // Debug.Log("gonna load scene");
        SceneManager.LoadScene(scenename);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
