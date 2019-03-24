using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject Interacttext;
    public GameObject sceneswitcher;
    public bool cangotonextlevel;
    LevelChanger levelchange;
    public string levelindextoload;
    // Start is called before the first frame update
    void Start()
    {
        cangotonextlevel = false;
        levelchange = sceneswitcher.GetComponent<LevelChanger>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(cangotonextlevel);

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && cangotonextlevel == true)
        {
            Interacttext.SetActive(true);
            if(Interacttext.activeInHierarchy == true && Input.GetKeyDown(KeyCode.E))
            {
                levelchange.FadeToLevel(levelindextoload);
            }


        }
    }

    public void BossBeaten()
    {
        cangotonextlevel = true;
    }
}
