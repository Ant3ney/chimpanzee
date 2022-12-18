using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {
    public Animator Animationss;
    public Animation Anim;
    public AiControler Chimp;
    public CameraAimation Cam;
    public SeipeControles Swipe;
    public float FireDelay;
    public float WaitTime;
    public float PunchDammage;
    public float Hits = 0;
    public float HitsTaken = 0;
    public float MaxHits;
    public float PlayerHealth = 1;
    public float StrikeReactionDelay;    
    public float StrikeReactionFinished;
    public float StaminaBar;
    public float StaminaCounter;
    public float CanPunchInterval;
    public float SuperPunchDammage;
    public float BlockDelay;
    public bool StopBlock = true;
    public float Blockdelay2;
    float CanPunchInterval2;
    public int ConsecutiveHits = 1;
    public bool StrikeReactionStartL = false;
    public bool StrikeReactionStart = false;
    public bool PunchLeft;
    public bool PunchRight;
    public bool FirstPunch = false;
    public bool Alive = true;
    public bool Kill = false;
    public bool WaititimeafterStrike = false;
    public bool SuperPunch = false;
    public bool AditionalHealtCheck = false;
    public bool StrikeReactionsuper = false;
    bool blocking = false;
    bool CanPunch = true;
    public AudioClip Strike1;
    public AudioClip Strike2;
    public AudioClip Strike3;
    public AudioClip Strike4;
    public AudioClip Strike5;
    public AudioClip SuperStrike;
    // Use this for initialization
    void Start () {
        Animationss = GetComponent<Animator>();
        Chimp = FindObjectOfType<AiControler>();
        Cam = FindObjectOfType<CameraAimation>();
        Swipe = FindObjectOfType<SeipeControles>();
        PlayerHealth = 1;        
    }	
	// Update is called once per frame
	void Update ()
    {
        PunchSystems();
        HealthSystems();
        FlinchAnimations();
        StrikeSoundEffects();
        //CameraAnimations();
        DeathSystems();
        //ExtraTimmerSystems();
    }
    void PunchSystems()
    {
        Blockdelay2 += (1 * Time.deltaTime);
        FireDelay += (1 * Time.deltaTime);
        if ((Chimp.StrikeTimmer + 1) <= Chimp.StrikeCooldown)
        {
            CanPunch = true;
        }
        if ((Swipe.SwipeRight) && (StrikeReactionStartL == false) && (FireDelay >= WaitTime) && (CanPunch == true) && (blocking == false) && (StrikeReactionsuper == false))
        {
            Animationss.SetTrigger("Punch");
            Cam.Animations.SetTrigger("PunchLeft");
            PunchLeft = true;
            FirstPunch = true;
            Chimp.FlinchTimmer2 = 0;
            //Chimp.StrikeTimmer -= 0.5f;
            Hits += PunchDammage;
            ConsecutiveHits += 1;
            FireDelay = 0;
            CanPunch = false;
            WaititimeafterStrike = false;
        }
        if (((Input.GetButtonDown("Fire2")) || Swipe.SwipeLeft) && (StrikeReactionStart == false) && (FireDelay >= WaitTime) && (CanPunch == true) && (blocking == false) && (StrikeReactionsuper == false))
        {            
            Animationss.SetTrigger("Punch2");
            PunchRight = true;
            FirstPunch = true;
            Chimp.FlinchTimmer2 = 0;
            //Chimp.StrikeTimmer -= 0.5f;
            //print("Dammage");
            Hits += PunchDammage;                                 
            Cam.Animations.SetTrigger("PunchRight");
            ConsecutiveHits += 1;
            FireDelay = 0;
            CanPunch = false;
            WaititimeafterStrike = false;
        } 
        if (((Input.GetKeyDown(KeyCode.Space)) || Swipe.SwipeDown) && (StrikeReactionStart == false) && (FireDelay >= WaitTime) && (CanPunch == true) && (blocking == false) && (StrikeReactionsuper == false) && (ConsecutiveHits >= 2))
        {
            Animationss.SetTrigger("SuperPunch");
            Cam.Animations.SetTrigger("SuperPunch");
            SuperPunch = true;
            Chimp.FlinchTimmer2 = 0;
            //Chimp.StrikeTimmer -= 0.5f;
            print("Dammage");
            Hits += SuperPunchDammage;            
            ConsecutiveHits = 0;
            FireDelay = -4;
            CanPunch = false;
            WaititimeafterStrike = false;
        }
        if ((Input.GetKeyDown(KeyCode.LeftShift) || Swipe.SwipeUp) && blocking == false)
        {
            blocking = true;
            Animationss.SetTrigger("Block");
            Cam.Animations.SetTrigger("Block");
            FireDelay -= 0.5f;
            if (Blockdelay2 <= BlockDelay)
            {                
                Blockdelay2 = 0;
                //Animationss.SetBool("StopBlock", true);
            }
           
          
        }
        if (Blockdelay2 >= BlockDelay)
        {
            blocking = false;
        }
        if (Blockdelay2 <= BlockDelay)
        {
            blocking = true;
        }
    }
    void HealthSystems()
    {
        if ((StrikeReactionStart == true) || (StrikeReactionStartL == true))
        {
            StrikeReactionDelay += (1 * Time.deltaTime);
        }        
        float Hits2;
        if (StrikeReactionDelay >= StrikeReactionFinished)
        {
            Hits2 = (MaxHits - HitsTaken);
            PlayerHealth = (Hits2 / MaxHits);                        
        }
        if (AditionalHealtCheck)
        {
            Hits2 = (MaxHits - HitsTaken);
            PlayerHealth = (Hits2 / MaxHits);
            AditionalHealtCheck = false;
        }
    }
    void DeathSystems()
    {
        if ((PlayerHealth <= 0) || (Kill == true))
        {
            Alive = false;
            Animationss.SetTrigger("Death");
            Cam.Animations.SetTrigger("Death");
        }
    }
    void FlinchAnimations()
    {
        if ((StrikeReactionStart == true) && (StrikeReactionDelay >= StrikeReactionFinished) && (Alive == true) && (Chimp.SucessfulBlock == false))
        {
            Animationss.SetTrigger("FlinchRight");
            Cam.Animations.SetTrigger("StrikeRight");
        }
        if ((StrikeReactionStartL == true) && (StrikeReactionDelay >= StrikeReactionFinished) && (Chimp.SucessfulBlock == false))
        {
            Animationss.SetTrigger("FlinchLeft");
            Cam.Animations.SetTrigger("StrikeLeft");
        }
        if ((StrikeReactionsuper == true) && (Chimp.SucessfulBlock == false))
        {
            Animationss.SetTrigger("RecivingSuperStrike");
            Cam.Animations.SetTrigger("RecivingSuperPunch");
            StrikeReactionsuper = false;
        }
    }
    
    //void CameraAnimations()
    //{
        //if ((StrikeReactionStart == true) && (StrikeReactionDelay >= StrikeReactionFinished))
        //{
            //Cam.Animations.SetTrigger("StrikeRight");
        //}
        //if ((StrikeReactionStartL == true) && (StrikeReactionDelay >= StrikeReactionFinished))
        //{
            //Cam.Animations.SetTrigger("StrikeLeft");
        //}
    //}
    void StrikeSoundEffects()
    {
        if ((Random.Range(1,5) == 1) && (StrikeReactionDelay >= StrikeReactionFinished))
        {
            AudioSource.PlayClipAtPoint(Strike1, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike1, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike1, this.transform.position);
            StrikeReactionStartL = false;
            StrikeReactionStart = false;
            StrikeReactionDelay = 0;
        }
        else if ((Random.Range(1, 5) == 1) && (StrikeReactionDelay >= StrikeReactionFinished))
        {
            AudioSource.PlayClipAtPoint(Strike2, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike2, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike2, this.transform.position);
            StrikeReactionStartL = false;
            StrikeReactionStart = false;
            StrikeReactionDelay = 0;
        }
        else if((Random.Range(1, 5) == 1) && (StrikeReactionDelay >= StrikeReactionFinished))
        {
            AudioSource.PlayClipAtPoint(Strike3, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike3, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike3, this.transform.position);
            StrikeReactionStartL = false;
            StrikeReactionStart = false;
            StrikeReactionDelay = 0;
        }
        else if ((Random.Range(1, 5) == 1) && (StrikeReactionDelay >= StrikeReactionFinished))
        {
            AudioSource.PlayClipAtPoint(Strike4, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike4, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike4, this.transform.position);
            StrikeReactionStartL = false;
            StrikeReactionStart = false;
            StrikeReactionDelay = 0;
        }
        else if ((Random.Range(1, 5) == 1) && (StrikeReactionDelay >= StrikeReactionFinished))
        {
            AudioSource.PlayClipAtPoint(Strike5, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike5, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike5, this.transform.position);
            StrikeReactionStartL = false;
            StrikeReactionStart = false;
            StrikeReactionDelay = 0;
        }
        else if (StrikeReactionDelay >= StrikeReactionFinished)
        {
            AudioSource.PlayClipAtPoint(Strike5, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike5, this.transform.position);
            AudioSource.PlayClipAtPoint(Strike5, this.transform.position);
            StrikeReactionStartL = false;
            StrikeReactionStart = false;
            StrikeReactionDelay = 0;
        }
        else if (Chimp.SuperAudio)
        {
            AudioSource.PlayClipAtPoint(SuperStrike, this.transform.position);
            AudioSource.PlayClipAtPoint(SuperStrike, this.transform.position);
            AudioSource.PlayClipAtPoint(SuperStrike, this.transform.position);
            AudioSource.PlayClipAtPoint(SuperStrike, this.transform.position);
            AudioSource.PlayClipAtPoint(SuperStrike, this.transform.position);
            Chimp.SuperAudio = false;
        }
    }

    //void ExtraTimmerSystems()
    //{
        //if (StrikeReactionStart || StrikeReactionStartL)
        //{
        //    WaititimeafterStrike = true;
        //}
        //if (WaititimeafterStrike == true)
        //{
        //    CanPunchInterval2 += (1 * Time.deltaTime);
        //}
    //}
}

