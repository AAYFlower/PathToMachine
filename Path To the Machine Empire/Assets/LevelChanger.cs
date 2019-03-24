using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private string levelToLoad;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FadeToLevel(string levelIndex)
    {
        Debug.Log("loadnextlevel");
        levelToLoad = levelIndex;
        SceneManager.LoadScene(levelToLoad);
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
       // SceneManager.LoadScene(levelToLoad);
    }


}
