using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimation : MonoBehaviour
{
    public Animator anim;

    public Animator Fanim;

    bool Frun, Fidle;
    bool run,jump;

    private void Update()
    {
        if(run && !jump)
        {
            anim.SetFloat("Speed", 5);
            anim.SetFloat("JumpingSpeed", 0);
        }
        else if(jump && !run)
        {
            anim.SetFloat("Speed", 0);
            anim.SetFloat("JumpingSpeed", 3);
        }
        if (Frun && !Fidle)
        {
            Fanim.SetBool("Run", true);
            
        }
        else if (Fidle && !Frun)
        {
            Fanim.SetBool("Run", false);
            
        }
    }


    public void Run()
    {
        run = true;
        jump = false;
    }
    public void Jump()
    {
        run = false;
        jump = true;
    }
    public void FRun()
    {
        Frun = true;
        Fidle = false;
    }

    public void FIdle()
    {
        Frun = false;
        Fidle = true;
    }
}
