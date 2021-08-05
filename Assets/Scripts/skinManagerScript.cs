using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using GooglePlayGames;

public class skinManagerScript : MonoBehaviour
{

    
    public GameObject sr;
    public List<Sprite> skinsLocked = new List<Sprite>();
    public List<Sprite> skinsUnlocked = new List<Sprite>();
    public Sprite Own, Buy;
    //public MenuManager tranScript;
    public Text testTxt;


    int selectedSkinNo=0;
    public GameObject i1, i2, i3, i4, CoinLessPanel;
    public Button b1, b2, b3, b4;
    public TextMeshProUGUI t1, t2, t3, t4 , coinsDisp;
    public Animator DimmerPanel,CoinPanel;
    public int[]  costArray= { 0,200,500,1000} ;
    public void plus100() {
       int a= PlayerPrefs.GetInt("Totalcoins");
        PlayerPrefs.SetInt("Totalcoins", a + 100);
        coinsDisp.text = "COINS : "+PlayerPrefs.GetInt("Totalcoins")+"";
    }
    public void minus100()
    {
        int a = PlayerPrefs.GetInt("Totalcoins");
        PlayerPrefs.SetInt("Totalcoins", a - 100);
        coinsDisp.text = "COINS : " + PlayerPrefs.GetInt("Totalcoins") + "";
    }
    public void Reset_Shop()
    {
        PlayerPrefs.SetInt("own1", 1);
        PlayerPrefs.SetInt("own2", 0);
        PlayerPrefs.SetInt("own3", 0);
        PlayerPrefs.SetInt("own4", 0);
        PlayerPrefs.SetInt("skinNumber", 0);
        PlayerPrefs.SetInt("NoOfSkinOwned",1);
        SceneManager.LoadScene("Shop");
    }

    public void ViewRight() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        selectedSkinNo++;
        if (selectedSkinNo == skinsUnlocked.Count)
            selectedSkinNo = 0;

        int plusOne = (selectedSkinNo + 1);
        string dictOwn = "own"+plusOne;
        while (PlayerPrefs.GetInt(dictOwn)==0)
        {
            selectedSkinNo++;
            if (selectedSkinNo == skinsUnlocked.Count)
                selectedSkinNo = 0;
            plusOne = (selectedSkinNo + 1);
            dictOwn = "own" + plusOne;
        }
        
        sr.GetComponent<Image>().sprite = skinsUnlocked[selectedSkinNo];
        PlayerPrefs.SetInt("skinNumber",selectedSkinNo);
        
    }
    public void ViewLeft()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        selectedSkinNo--;
        if (selectedSkinNo < 0)
            selectedSkinNo = skinsUnlocked.Count - 1;

        int plusOne = (selectedSkinNo + 1);
        string dictOwn = "own" + plusOne;
        while (PlayerPrefs.GetInt(dictOwn) == 0)
        {
            selectedSkinNo--;
            if (selectedSkinNo < 0)
                selectedSkinNo = skinsUnlocked.Count - 1;
            plusOne = selectedSkinNo + 1;
            dictOwn = "own" + plusOne;
        }
        sr.GetComponent<Image>().sprite = skinsUnlocked[selectedSkinNo];
        PlayerPrefs.SetInt("skinNumber", selectedSkinNo);
        
    }

    public void SkinAch() {


        int curSkinOwned = PlayerPrefs.GetInt("NoOfSkinOwned");        
        PlayerPrefs.SetInt("NoOfSkinOwned",curSkinOwned+1);
        testTxt.text = ""+(curSkinOwned + 1);

        if (PlayerPrefs.GetInt("NoOfSkinOwned") == 2) {
            //Spender
            Social.ReportProgress(GPGSIds.achievement_collector,100f,null);
        }
        if (PlayerPrefs.GetInt("NoOfSkinOwned") == 4)
        {
            //Collector
            Social.ReportProgress(GPGSIds.achievement_shopaholic, 100f, null);
        }
    }

    public void Button2Onclick()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        int curBal = PlayerPrefs.GetInt("Totalcoins");
        if (curBal < costArray[1])
        {
            CoinLessPanel.SetActive(true);
            showCoinLessPanel();
        }
        else {
            PlayerPrefs.SetInt("Totalcoins",curBal-costArray[1]);
            coinsDisp.text = "COINS : " + PlayerPrefs.GetInt("Totalcoins") + "";
            PlayerPrefs.SetInt("own2",1);
            i2.GetComponent<Image>().sprite = skinsUnlocked[1];
           // i2.GetComponent<Image>().SetNativeSize();
            t2.text = "OWNED";
            b2.GetComponent<Image>().sprite = Own;
            SkinAch();
            b2.interactable = false;

        }
    }

    public void Button3Onclick()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        int curBal = PlayerPrefs.GetInt("Totalcoins");
        if (curBal < costArray[2])
        {
            CoinLessPanel.SetActive(true);
            showCoinLessPanel();
        }
        else {
            PlayerPrefs.SetInt("Totalcoins", curBal - costArray[2]);
            coinsDisp.text = "COINS : " + PlayerPrefs.GetInt("Totalcoins") + "";
            PlayerPrefs.SetInt("own3", 1);
            i3.GetComponent<Image>().sprite = skinsUnlocked[2];
            //i3.GetComponent<Image>().SetNativeSize();
            t3.text = "OWNED";
            b3.GetComponent<Image>().sprite = Own;
            SkinAch();
            b3.interactable = false;
        }
    }

    public void Button4Onclick()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        int curBal = PlayerPrefs.GetInt("Totalcoins");
        if (curBal < costArray[3])
        {
            CoinLessPanel.SetActive(true);
            showCoinLessPanel();
        }
        else
        {
            PlayerPrefs.SetInt("Totalcoins", curBal - costArray[3]);
            coinsDisp.text = "COINS : " + PlayerPrefs.GetInt("Totalcoins") + "";
            PlayerPrefs.SetInt("own4", 1);
            i4.GetComponent<Image>().sprite = skinsUnlocked[3];
            //i4.GetComponent<Image>().SetNativeSize();
            t4.text = "OWNED";
            b4.GetComponent<Image>().sprite = Own;
            SkinAch();
            b4.interactable = false;
        }
    }
    public void showCoinLessPanel() {
        DiminFunc();
        StartCoroutine(CoinLessPanelCoroutine("flyup"));
    }
    public void closeBtnLessCoin()
    {
        SFXManagerScript.SFXInstance.Playbtnsound();
        DimOutFunc();
        StartCoroutine(CoinLessPanelCoroutine("flydown"));
    }
    IEnumerator CoinLessPanelCoroutine(string triggerval) {
        CoinPanel.SetTrigger(triggerval);
        yield return new WaitForSeconds(0.5f);

    }
    

    public void DiminFunc()
    {
        StartCoroutine(DimmerCoroutine("DimIn"));
    }
    public void DimOutFunc()
    {
        StartCoroutine(DimmerCoroutine("DimOut"));
    }
    IEnumerator DimmerCoroutine(string triggerval)
    {
        DimmerPanel.SetTrigger(triggerval);
        yield return new WaitForSeconds(1);

    }


    // Start is called before the first frame update
    void Start()
    {
        //Reset_Shop();
        //PlayerPrefs.SetInt("skinNumber",0);
        /* if (!PlayerPrefs.HasKey("NoOfSkinOwned"))
         {
             PlayerPrefs.SetInt("NoOfSkinOwned", 1);
         }*/
        //AdManagerScript.Ins.hideBanner();
       // int rand = Random.Range(0, 4);
        //if(rand==2)
           // AdManagerScript.Ins.ShowInterstitialAd();

        testTxt.text = PlayerPrefs.GetInt("NoOfSkinOwned")+ " ";

        coinsDisp.text= "COINS : " + PlayerPrefs.GetInt("Totalcoins");
        if (PlayerPrefs.HasKey("skinNumber"))
        {
            selectedSkinNo = PlayerPrefs.GetInt("skinNumber");
        }
        else
            selectedSkinNo = 0;
        
        sr.GetComponent<Image>().sprite = skinsUnlocked[selectedSkinNo];

        if (!PlayerPrefs.HasKey("own1")) 
            PlayerPrefs.SetInt("own1",1);
        if (!PlayerPrefs.HasKey("own2"))
            PlayerPrefs.SetInt("own2", 0);
        if (!PlayerPrefs.HasKey("own3"))
            PlayerPrefs.SetInt("own3", 0);
        if (!PlayerPrefs.HasKey("own4"))
            PlayerPrefs.SetInt("own4", 0);


        if (PlayerPrefs.GetInt("own1") == 1)
        {
            i1.GetComponent<Image>().sprite = skinsUnlocked[0];
            t1.text = "OWNED";
            b1.GetComponent<Image>().sprite = Own;
            b1.GetComponent<Image>().SetNativeSize();
            b1.interactable = false;
        }
        else {
            i1.GetComponent<Image>().sprite = skinsLocked[0];
            t1.text = costArray[0] + " ";
            b1.GetComponent<Image>().sprite = Buy;
            b1.GetComponent<Image>().SetNativeSize();
            b1.interactable = true;
        }

        if (PlayerPrefs.GetInt("own2") == 1)
        {
            i2.GetComponent<Image>().sprite = skinsUnlocked[1];
            t2.text = "OWNED";
            b2.GetComponent<Image>().sprite = Own;
            b2.GetComponent<Image>().SetNativeSize();
            b2.interactable = false;
        }
        else
        {
            i2.GetComponent<Image>().sprite = skinsLocked[1];
            t2.text = costArray[1] + " ";
            b2.GetComponent<Image>().sprite = Buy;
            b2.GetComponent<Image>().SetNativeSize();
            b2.interactable = true;
        }


        if (PlayerPrefs.GetInt("own3") == 1)
        {
            i3.GetComponent<Image>().sprite = skinsUnlocked[2];
            t3.text = "OWNED";
            b3.GetComponent<Image>().sprite = Own;
            b3.GetComponent<Image>().SetNativeSize();
            b3.interactable = false;
        }
        else
        {
            i3.GetComponent<Image>().sprite = skinsLocked[2];
            t3.text = costArray[2] + " ";
            b3.GetComponent<Image>().sprite = Buy;
            b3.GetComponent<Image>().SetNativeSize();
            b3.interactable = true;
        }


        if (PlayerPrefs.GetInt("own4") == 1)
        {
            i4.GetComponent<Image>().sprite = skinsUnlocked[3];
            t4.text = "OWNED";
            b4.GetComponent<Image>().sprite = Own;
            b4.GetComponent<Image>().SetNativeSize();
            b4.interactable = false;
        }
        else
        {
            i4.GetComponent<Image>().sprite = skinsLocked[3];
            t4.text = costArray[3] + " ";
            b4.GetComponent<Image>().sprite = Buy;
            b4.GetComponent<Image>().SetNativeSize();
            b4.interactable = true;
        }



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
