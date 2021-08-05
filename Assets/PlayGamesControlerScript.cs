using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class PlayGamesControlerScript : MonoBehaviour
{
    public bool log=false;

    public static PlayGamesPlatform platform;

  

    public static void PostToLeaderboard(long newscore)
    {       
            Social.ReportScore(newscore, GPGSIds.leaderboard_high_score, (bool success) =>
            {
                if (success)
                {
                   // Debug.Log("Posted");
                }
                else
                {
                   // Debug.Log("Unable to post score");
                }
            });
        
        
    }

   

    public static void ShowLeaderboardUI() {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
     }

    public void showGPGSLeaderboard() {
        //ShowLeaderboardUI();
        if (platform == null)
        {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            });
        }
        Social.ShowLeaderboardUI();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (platform == null) {
            PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
            PlayGamesPlatform.InitializeInstance(config);
            PlayGamesPlatform.DebugLogEnabled = true;
            PlayGamesPlatform.Activate();
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {

            });
        }
       

        /* Social.localUser.Authenticate((bool success) =>
         {
             if (success == true)
             {
                 Debug.Log("Logged into gpgs");
                 log = true;
             }
             else
             {
                 Debug.Log("Didnt Log");
                 log = false;
             }
         }

        );*/

    }


    public  void OpenAch() {
        if (platform == null) {
            PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            });
        }

        Social.ShowAchievementsUI();
    }

 

    public void signOutGPGS()
    {
        PlayGamesPlatform.Instance.SignOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
