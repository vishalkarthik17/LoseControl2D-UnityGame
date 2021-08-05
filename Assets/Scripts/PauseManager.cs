using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    
    public GameObject PausePanel,InstructionPanel;
    


    public void pauseGame() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        Time.timeScale = 0f;
        PausePanel.SetActive(true);
    }

    public void LoadMenu(){
        SFXManagerScript.SFXInstance.Playbtnsound();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }

    public void resumeGame() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        Time.timeScale = 1.0f;
        PausePanel.SetActive(false);

       
    }

    public void restartGame() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        SceneManager.LoadScene("SampleScene");
    }

    public void InsDontShowAgain()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        PlayerPrefs.SetInt("ShowInstructions", 0);
        InstructionPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void InsClose()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        InstructionPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    

    void Start()
    {
        int ShowIns;
        if (!PlayerPrefs.HasKey("ShowInstructions"))
        {
            PlayerPrefs.SetInt("ShowInstructions", 1);
        }
        ShowIns = PlayerPrefs.GetInt("ShowInstructions");
        if (ShowIns == 1)
        {
            Time.timeScale = 0f;
            InstructionPanel.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
