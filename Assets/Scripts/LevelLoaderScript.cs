using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator trans;

    public void LoadShopWithAnim()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        StartCoroutine(LoadSceneWithAnimCoroutine("Shop"));
    }
    public void LoadPlayWithAnim()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        StartCoroutine(LoadSceneWithAnimCoroutine("SampleScene"));
    }
    public void LoadMenuWithAnim()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        StartCoroutine(LoadSceneWithAnimCoroutine("MainMenu"));
    }
    public void LoadMenu()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        SceneManager.LoadScene("MainMenu");
    }
    IEnumerator LoadSceneWithAnimCoroutine(string scenename)
    {
        trans.SetTrigger("WipeTransition");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scenename);
    }
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
