using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkin : MonoBehaviour
{
    // Start is called before the first frame update

    //public SpriteRenderer sr;
    public List<Sprite> skinss = new List<Sprite>();
    int selectedSkinNumber;
    public GameObject playerPrefab;

    void Start()
    {
        //selected skin no = get from playerPrefs
        int selectedSkinNumber = PlayerPrefs.GetInt("skinNumber");
        playerPrefab.GetComponent<SpriteRenderer>().sprite= skinss[selectedSkinNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
