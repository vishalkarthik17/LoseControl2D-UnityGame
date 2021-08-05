using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    public TextMeshProUGUI HsDisp,CoinsDisp;
    public Animator OptionsPanel,DimmerPanel,AboutPanel,InstructionPanel;
    public void instagram()
    {
        Application.OpenURL("https://www.instagram.com/vishalkarthik17/");
    }
    public void linkedin()
    {
        Application.OpenURL("https://www.linkedin.com/in/vishal-karthikeyan-ab4a60184/");
    }
    public void github()
    {
        Application.OpenURL("https://github.com/vishalkarthik17");
    }

    public void privacyPolicy()
    {
        Application.OpenURL("https://vishalkarthik17.github.io/Privacy-Policy-Lose-Control/");
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        HsDisp.text = "HIGHSCORE : " + (int)PlayerPrefs.GetInt("highscore");
        CoinsDisp.text = "COINS : " + PlayerPrefs.GetInt("Totalcoins");
        if (!PlayerPrefs.HasKey("NoOfSkinOwned"))
        {
            PlayerPrefs.SetInt("NoOfSkinOwned", 1);
        }
    }
    public void ResetInsPrefs() {
        if (!PlayerPrefs.HasKey("ShowInstructions"))
            PlayerPrefs.SetInt("ShowInstructions",1);
        else
            PlayerPrefs.SetInt("ShowInstructions", 1);

       

    }

    public void DiminFunc() {
        StartCoroutine(DimmerCoroutine("DimIn"));
    }
    public void DimOutFunc() {
        StartCoroutine(DimmerCoroutine("DimOut"));
    }
    IEnumerator DimmerCoroutine(string triggerval) {
        DimmerPanel.SetTrigger(triggerval);
        yield return new WaitForSeconds(1);
    }

   
    public void OpenOptions() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        DiminFunc();
        StartCoroutine(OptionsCoroutine("OpenOptions"));
    }
    public void CloseOptions(){
        SFXManagerScript.SFXInstance.Playbtnsound();
        DimOutFunc();
        StartCoroutine(OptionsCoroutine("CloseOptions"));
    }
    IEnumerator OptionsCoroutine(string triggerval) {
        OptionsPanel.SetTrigger(triggerval);
        yield return new WaitForSeconds(1);

    }

    public void OpenAbout() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        DiminFunc();
        StartCoroutine(AboutCoroutine("OpenOptions"));
    }
    public void CloseAbout() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        DimOutFunc();
        StartCoroutine(AboutCoroutine("CloseOptions"));
    }
    IEnumerator AboutCoroutine(string triggerval) {
        AboutPanel.SetTrigger(triggerval);
        yield return new WaitForSeconds(1);
    }

    public void OpenInstructions() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        DiminFunc();
        StartCoroutine(InstructionCoroutine("OpenOptions"));
    }
    public void CloseInstructions(){
        SFXManagerScript.SFXInstance.Playbtnsound();
        DimOutFunc();
        StartCoroutine(InstructionCoroutine("CloseOptions"));
    }
    IEnumerator InstructionCoroutine(string triggerval) {
        InstructionPanel.SetTrigger(triggerval);
        yield return new WaitForSeconds(1f);
    }

    public void FactResetPP() {
        PlayerPrefs.SetInt("highscore",0);
        PlayerPrefs.SetInt("Totalcoins",0);
        PlayerPrefs.SetInt("own2",0);
        PlayerPrefs.SetInt("own3",0);
        PlayerPrefs.SetInt("own4",0);
        SceneManager.LoadScene("MainMenu"); 
    }

    
    public void LoadSkins()
    {
        SceneManager.LoadScene("Shop");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    
}
