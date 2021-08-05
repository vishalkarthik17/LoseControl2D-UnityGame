using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using GooglePlayGames;
public class PlayerScript : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 startPos;
    public float XOffset,speed,clampValueLeft,clampValueRight;
    public bool isAlive ;
    public bool isLocked;
    public bool isSwapMode;
    public TextMeshProUGUI scoreBox,coinBox,GOscore, GOHighscore, GOCoinsCollected;
    public GameObject GOScreenPanel;
    public int coinCollectedEachGame;
    public float scoreAmount, pointIncPerSecond;
    public GameObject SpawnerPrefab;
    public Animator GOwindowpanel,playerAnimator;
    int crsCount;
    public List<Sprite> LR = new List<Sprite>();
    public List<Sprite> RL = new List<Sprite>();
    public Button LBtn, RBtn;

    public void swapButtonSprite() {
        if (crsCount % 2 == 1)
        {
            LBtn.GetComponent<Image>().sprite = LR[0];
            RBtn.GetComponent<Image>().sprite = LR[1];
        }
        else {
            LBtn.GetComponent<Image>().sprite = RL[0];
            RBtn.GetComponent<Image>().sprite = RL[1];
        }
        crsCount++;
    }

    public void leftClick() {
        //Debug.Log("LeftClicked");
        SFXManagerScript.SFXInstance.Playbtnsound();
        if (isSwapMode == false)
        {
            if (transform.position.x > clampValueLeft && isLocked == false)
            {
                isLocked = true;
                targetPos = new Vector2(transform.position.x - XOffset, transform.position.y);
                //Debug.Log("TargetPosSet");
            }
        }
        else {
            if (transform.position.x < clampValueRight && isLocked == false)
            {
                isLocked = true;
                targetPos = new Vector2(transform.position.x + XOffset, transform.position.y);
                //Debug.Log("TargetPosSet");
            }
        }
        
        
    }

    public void rightClick() {
        SFXManagerScript.SFXInstance.Playbtnsound();
        if (isSwapMode == true)
        {
            if (transform.position.x > clampValueLeft && isLocked == false)//left move
            {
                isLocked = true;
                targetPos = new Vector2(transform.position.x - XOffset, transform.position.y);
            }
        }
        else
        {
            if (transform.position.x < clampValueRight && isLocked == false)
            {
                isLocked = true;
                targetPos = new Vector2(transform.position.x + XOffset, transform.position.y);
            }
        }

    }
    

    void Start()
    {
        //AdManagerScript.Ins.hideBanner();
        Time.timeScale = 1.0f; 
        targetPos = new Vector2(transform.position.x,transform.position.y);
        isAlive = true;
        isSwapMode = false;
        scoreAmount = 0f;
        pointIncPerSecond = 3.0f;
        coinCollectedEachGame = 0;
        crsCount = 0;

    }
    public void gameoveranim() {
        SFXManagerScript.SFXInstance.Playgameoversound();
        StartCoroutine(gameoveranimCoroutine());
    }
    IEnumerator gameoveranimCoroutine() {
        GOwindowpanel.SetTrigger("gameoverAnim");
        yield return new WaitForSeconds(1f);
    }
    public void explode() {
        StartCoroutine(explodeCoroutine());
    }
    IEnumerator explodeCoroutine() {
        playerAnimator.SetTrigger("explode");
        yield return new WaitForSeconds(1f);
    }
    public void gameoverFunc() {
       
        GOScreenPanel.SetActive(true);
        //Time.timeScale = 0f;
        explode();
        gameoveranim();
        SpawnerPrefab.GetComponent<Spawner>().isGamePaused = true;
        GOscore.text = "Score : " + (int)scoreAmount;

        if ((int)scoreAmount > PlayerPrefs.GetInt("highscore")) {
            PlayerPrefs.SetInt("highscore", (int)scoreAmount);           
        }
        PlayGamesControlerScript.PostToLeaderboard((long)scoreAmount);

        GOHighscore.text = "Highscore : " + PlayerPrefs.GetInt("highscore");
        GOCoinsCollected.text = "Coins Collected : " + coinCollectedEachGame;
        int currentCoinBalance = PlayerPrefs.GetInt("Totalcoins");
        PlayerPrefs.SetInt("Totalcoins", currentCoinBalance + coinCollectedEachGame);

        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_2k_club,(int)scoreAmount,null);
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_4k_club, (int)scoreAmount, null);
        PlayGamesPlatform.Instance.IncrementAchievement(GPGSIds.achievement_6k_club, (int)scoreAmount, null);

        if (!PlayerPrefs.HasKey("scoreTotalOverall"))
        {
            PlayerPrefs.SetInt("scoreTotalOverall", (int)scoreAmount);
        }
        else {
            int curr = PlayerPrefs.GetInt("scoreTotalOverall");
            PlayerPrefs.SetInt("scoreTotalOverall",(int)scoreAmount+curr);
        }
        if (!PlayerPrefs.HasKey("coinsTotalOverall"))
        {
            PlayerPrefs.SetInt("coinsTotalOverall", coinCollectedEachGame);
        }
        else {
            int curr=PlayerPrefs.GetInt("coinsTotalOverall");
            PlayerPrefs.SetInt("coinsTotalOverall",coinCollectedEachGame+curr);
        }

        if (scoreAmount >= 250) {
            Social.ReportProgress(GPGSIds.achievement_marathon,100f,null);
        }
        if (coinCollectedEachGame >= 50) {
            Social.ReportProgress(GPGSIds.achievement_miner,100f,null);
        }

        
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isLocked == true){
            if (transform.position.x==targetPos.x) {
                isLocked = false;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position,targetPos,speed*Time.deltaTime);
        //Debug.Log("Should Move");

       if (SpawnerPrefab.GetComponent<Spawner>().isGamePaused == false) { 
        scoreBox.text = "Score : " + (int)scoreAmount;
        coinBox.text = "Coins : " + coinCollectedEachGame;
        scoreAmount += pointIncPerSecond * Time.deltaTime;
       }


    }
}
