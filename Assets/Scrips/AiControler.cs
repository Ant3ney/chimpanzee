using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiControler : MonoBehaviour {
    public PlayerControler Player;
    public Animator Animations;
    Transform Begining;
    public GameObject Rotator;
    public GameObject AudioLocation;
    public AudioSource AudioSccorrce;
    public SeipeControles Swipe;
    public AudioClip Punch1;
    public AudioClip Punch11;
    public AudioClip Punch2;
    public AudioClip Punch22;
    public AudioClip Punch3;
    public AudioClip Punch33;
    public AudioClip Punch4;
    public AudioClip Punch44;
    public AudioClip Punch5;
    public AudioClip Punch55;
    public AudioClip Punch6;
    public AudioClip Punch66;
    public AudioClip SuperPunch;
    public float FlinchTimmer2;
    public float FlinchTimmer;
    public float FlinchTimmer3;
    public float MaxHits;
    public float CurrentHealth;
    public float StrikeTimmer;
    public float StrikeCooldown;
    public float StrikeBlock;
    float StrikeBlock2;
    public bool Alive = true;
    public bool StrikeLeft = false;
    public bool StrikeRight = false;
    public bool IsBlocking = false;
    public bool SuperStriking, SuperAudio = false;
    bool OnlyOnce = false;
    public bool SucessfulBlock = false;
    void Start() {
        AudioSccorrce = GetComponent<AudioSource>();        
        ComponentGrabing();
        CurrentHealth = 1;
        //Begining.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        //Begining.transform.rotation = new Quaternion(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z, this.transform.rotation.w);
    }    
    void Update() {
        this.transform.position = new Vector3(Rotator.transform.position.x, Rotator.transform.position.y, Rotator.transform.position.z);
        this.transform.rotation = new Quaternion(Rotator.transform.rotation.x, Rotator.transform.rotation.y, Rotator.transform.rotation.z, Rotator.transform.rotation.w);
        BaceGettingPunch();
        Strikes();
        DeathCalculations();
        BlockSystems();
    }
    void ComponentGrabing()
    {
        Player = FindObjectOfType<PlayerControler>();
        Animations = GetComponent<Animator>();
        Begining = GetComponent<Transform>();
        Swipe = FindObjectOfType<SeipeControles>();
    }
    void DeathCalculations()
    {
        if ((CurrentHealth <= 0) && (FlinchTimmer2 >= FlinchTimmer))
        {
            print("Dead");
            Animations.SetTrigger("DeathFull");
            Alive = false;
        }
    }
    void BaceGettingPunch()
    {
        FlinchTimmer2 += ((1 )* Time.deltaTime);
        if ((FindObjectOfType<PlayerControler>().PunchLeft == true) && (FlinchTimmer2 >= FlinchTimmer) && (Player.Alive == true))
        {
            print("Ai's Version of punch left is true");
            if (Alive == true)
            {
                Animations.SetTrigger("FlinchRight");
            }            
            FindObjectOfType<PlayerControler>().PunchLeft = false;
            FlinchTimmer2 = 0;
            PunchSoundeffects();
        }
        if ((FindObjectOfType<PlayerControler>().PunchRight == true) && (FlinchTimmer2 >= FlinchTimmer3) && (Player.Alive == true))
        {
            if (Alive == true)
            {
                Animations.SetTrigger("FlinchLeft");
            }            
            FindObjectOfType<PlayerControler>().PunchRight = false;
            FlinchTimmer2 = 0;
            PunchSoundeffects();            
        }
        if ((FindObjectOfType<PlayerControler>().SuperPunch == true) && (FlinchTimmer2 >= (FlinchTimmer3 + 0.5f)) && (Player.Alive == true))
        {
            Animations.SetTrigger("SuperReaction");
            Player.SuperPunch = false;
            FlinchTimmer2 = 0;
            PunchSoundeffects();
            StrikeTimmer -= 4;
            HealthCalculations();
        }
            if ((Player.PunchLeft == true) || (Player.PunchRight == true))
        {
            HealthCalculations();
        }
        if (Player.PunchLeft == true)
        {
            FlinchTimmer2 += (1 * Time.deltaTime);            
        }

    }
    void PunchSoundeffects()
    {        
        if (((Random.Range(1, 6)) == 1))
        {
            AudioSource.PlayClipAtPoint(Punch1, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch1, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch1, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch1, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch1, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch11, AudioLocation.transform.position);
            //print("Triggerd");
        }
        else if ((Random.Range(1, 6)) == 2)
        {
            AudioSource.PlayClipAtPoint(Punch2, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch2, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch2, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch2, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch2, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch2, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch22, AudioLocation.transform.position);
            //print("Triggerd2");
        }
        else if((Random.Range(1, 6)) == 3)
        {
            AudioSource.PlayClipAtPoint(Punch3, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch3, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch3, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch3, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch3, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch3, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch33, AudioLocation.transform.position);
            //print("Triggerd3");
        }
        else if((Random.Range(1, 6)) == 4)
        {
            AudioSource.PlayClipAtPoint(Punch4, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch4, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch4, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch4, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch4, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch4, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch44, AudioLocation.transform.position);
            //print("Triggerd4");
        }
        else if((Random.Range(1, 6)) == 5)
        {
            AudioSource.PlayClipAtPoint(Punch5, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch55, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch55, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch55, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch55, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch55, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch55, AudioLocation.transform.position);
            //print("Triggerd5");
        }
        else if((Random.Range(1, 6)) == 6)
        {
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch66, AudioLocation.transform.position);
            //print("Triggerd6");
        }
        else
        {
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            AudioSource.PlayClipAtPoint(Punch6, AudioLocation.transform.position);
            //print("TriggerdLast");
        }

    }
    void HealthCalculations()
    {
        float CurrentHealth2;
        CurrentHealth2 = MaxHits - FindObjectOfType<PlayerControler>().Hits;
        CurrentHealth = CurrentHealth2 / MaxHits;
    }
    void Strikes()
    {        
        StrikeTimmer += (1 * Time.deltaTime);
        if ((StrikeTimmer >= StrikeCooldown) && (Random.Range(1, 4) == 1) && (Player.Alive == true) && (Player.PunchLeft == false) && (Player.PunchRight == false) && (Alive == true) && (Player.SuperPunch == false))
        {
            print("Strike");
            Animations.SetTrigger("SuperStrike");
            StrikeTimmer = -4;
            Player.FireDelay = -1;
            Player.StrikeReactionsuper = true;
            SuperStriking = true;
            OnlyOnce = true;
            

        }
        if ((StrikeTimmer >= StrikeCooldown) && (Random.Range(1, 3) == 1) && (Player.Alive == true) && (Player.PunchLeft == false) && (Player.PunchRight == false) && (Alive == true) && (Player.SuperPunch == false))
        {
            print("Strike");
            Animations.SetTrigger("StrikeRight");
            StrikeTimmer = 0;            
            Player.FireDelay = -1;
            Player.StrikeReactionStart = true;
            StrikeRight = true;
           OnlyOnce = true;
            

        }
        else if ((StrikeTimmer >= StrikeCooldown) && (Player.Alive == true) && (Player.PunchLeft == false) && (Player.PunchRight == false) && (Alive == true) && (Player.SuperPunch == false))
        {
            print("Strike");
            Animations.SetTrigger("StrikeLeft");
            StrikeTimmer = 0;
            Player.FireDelay = -1;            
            Player.StrikeReactionStartL = true;
            StrikeLeft = true;
            OnlyOnce = true;
         
        }
    }
    void BlockSystems()
    {
       
        if (StrikeLeft == true || StrikeRight == true || SuperStriking == true)
        {
            StrikeBlock2 += (1 * Time.deltaTime);           
        }
        if (StrikeBlock2 >= StrikeBlock)
        {
            SuperStriking = false;
            StrikeLeft = false;
            StrikeRight = false;
            StrikeBlock2 = 0;
            SucessfulBlock = false;
            Player.Blockdelay2 -= 4;
            //SuperAudio = true;
        }
        if ((SucessfulBlock == false) && (StrikeBlock2 >= (StrikeBlock - .2f)))
        {
            if (OnlyOnce)
            {
                if (SuperStriking)
                {
                    Player.HitsTaken += 2;
                    SuperAudio = true;
                    Player.Blockdelay2 -= 4;
                    //Animations.SetTrigger("SuperStrike");

                }
                Player.HitsTaken += 1;
                OnlyOnce = false;
                Player.ConsecutiveHits = 0;
                //StrikeCooldown -= 1;               
            }            
            Player.AditionalHealtCheck = true;
        }
        if ((StrikeRight == true) && ((Swipe.SwipeUp) || Input.GetKeyDown(KeyCode.LeftShift)))
        {
            Animations.SetTrigger("BlockedRight");
            SucessfulBlock = true;
        }
        if ((StrikeLeft == true) && ((Swipe.SwipeUp) || Input.GetKeyDown(KeyCode.LeftShift)))
        {
            Animations.SetTrigger("BlockedLeft");
            SucessfulBlock = true;
        }   
        if ((SuperStriking == true) && ((Swipe.SwipeUp) || Input.GetKeyDown(KeyCode.LeftShift)))
        {
            Animations.SetTrigger("BlockedSuper");
            SucessfulBlock = true;
            SuperAudio = false;
            Player.Animationss.SetTrigger("TrueBlock");
            PunchSoundeffects();           
        }
    }



}
