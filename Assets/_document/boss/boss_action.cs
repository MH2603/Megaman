using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_action : MonoBehaviour
{
    public boss_skill skill;
    public comunicate gamePlay;

    public float step = -2;
    public float startTime;

    bool isDEAD = false;
    public float stepDead = 0;
    public float startTimeDead ;


    public float stepWin = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        
        if (!isDEAD) Doing();

        Dead();
    }

    
    void NextTurn(float timeNext)
    {
        if (startTime <= Time.time - timeNext)
        {
            step++;
            return;
        } 
    }

    void Doing()
    {

        if (step == -1f) skill.StartSolo();


        if (step == 1)
        {
            skill.RunToPlayer();
            skill.SetTwoLightning(true);
        }
        else if (step == 2) NextTurn(2f);
        else if (step == 3) skill.RunToPlayer();

        else if (step == 4) NextTurn(3f);

        else if (step == 5) skill.Bullet();

        else if (step == 6) NextTurn(4.5f);

        else if (step == 7)
        {
            skill.PrepareDash();
            skill.Flip(false);
        }
        else if (step == 8) NextTurn(2f);
        else if (step == 9) skill.Dash();
        else if (step == 10)
        {
            skill.PrepareDash();
            skill.Flip(true);
        }
        else if (step == 11) NextTurn(2f);
        else if (step == 12)
        {
            skill.Dash();
            skill.SetTwoLightning(false);
        }

        else if (step == 13) NextTurn(2f);

        else if (step == 14) skill.SkillWind();

        else if (step == 15) NextTurn(2f);

        else if (step == 16) skill.Bullet();

        else if (step == 17) NextTurn(4.5f);

        if (step == 18)
        {
            skill.RunToPlayer();
            skill.SetTwoLightning(true);
        }
        else if (step == 19) NextTurn(2f);
        else if (step == 20)
        {
            skill.RunToPlayer();
            skill.SetTwoLightning(false);
        }
           

        else if (step == 21) NextTurn(2f);
        else if (step == 22) skill.prepareBoneFire();
        else if (step == 23) NextTurn(3f);
        else if (step == 24) skill.BoneFire();

        else if (step == 25) NextTurn(5f);

        else if (step == 26) skill.prepareBoneLightning();

        else if (step == 27) NextTurn(3f);

        else if (step == 28) NextTurn(9f);

        else if (step == 29) step = 1;

    }



    void Next(float timeNext)
    {
        if (startTimeDead <= Time.time - timeNext)
        {
            stepDead++;
            return;
        }
    }

    void Dead()
    {
        if (stepDead == 1)
        {
            skill.StartUNDEAD();
            isDEAD = true;
        }

        else if (stepDead == 2) Next(5.5f);

        else if (stepDead == 3) skill.MidUNDEAD();

        else if (stepDead == 4) Next(6f);

        else if (stepDead == 5)
        {
            step = 1;
            isDEAD = false;

            stepDead++;

            return;

        }


        if (gamePlay.win == 1 && stepWin == 0)
        {
            skill.DEAD();
            isDEAD = true;

        }else if(gamePlay.win == -1 && stepWin == 0)
        {
            skill.BossWin();
            isDEAD = true;
        }
    }

}
