using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public bool startFight;
    DialogueTrigger trigger;

    void Start()
    {
        startFight = false;
        trigger = GetComponent<DialogueTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(startFight);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            startFight = true;
            trigger.TriggerDialogue();
            gameObject.SetActive(false);
        }
    }



}
