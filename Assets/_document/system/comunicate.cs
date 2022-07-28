using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class comunicate : MonoBehaviour
{
    public boss_action action;

    public bossHP boss;
    public CharacterController2D_new player;

    public float win = 0;
    bool fistDead = false;

    public GameObject bossUI;

    public GameObject boxChat;
    public Text boxText;


    public GameObject WinPause;
    public Text winText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (action.step == 0) bossUI.SetActive(true);

        if (action.step == 0 && action.stepWin == 0) BossTalk("Solo Ko");
        else boxChat.SetActive(false);


        if( action.stepDead == 4)
        {
            BossTalk("UNDEAD KIGHT");
        }

        if (action.stepDead == 6)
        {
            fistDead = true;
            action.stepDead ++;
        }

        SetWin();

        
    }

    void SetWin()
    {
        if (player.life <= 0)
        {
            win = -1;
            PlayerLoss();
        }
        else if (boss.life <= 0 && fistDead ) 
        {
            win = 1;
            PlayerWin();
            
        }
    }

    void BossTalk(string text)
    {
        boxChat.SetActive(true);
        boxText.text = text;
    }



    void PlayerLoss()
    {
        BossTalk("Hơi Non");
        WinPause.SetActive(true);
        winText.text = "You lose, Let try again";

    }

    void PlayerWin()
    {
        BossTalk("GG");
        WinPause.SetActive(true);
        if(player.life == 16)
        {
            winText.text = "You win with max HP, Are you Faker ???";
        }else winText.text = "You win, but you should try to win max HP";



    }
    

   
    
}
