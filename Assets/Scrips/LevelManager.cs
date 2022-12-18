using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
    public bool Intro, Win, Lose, Main;
    public float Timmer1, Timmer2, Intros, Wins, Loses;
    public AiControler Chimp;
    public PlayerControler Player;
    float Won1 = 0;
    float Won2 = 4;
    // Use this for initialization
    void Start () {
        Chimp = FindObjectOfType<AiControler>();
        Player = FindObjectOfType<PlayerControler>();
	}
    public void NextLevel(string NameAnth)
    {
        Application.LoadLevel(NameAnth);
    }
    // Update is called once per frame
    void Update () {

		if ((Input.GetButtonDown("Fire1")) && Main == true)
        {
            Timmer2 += 100;
            Application.LoadLevel("Intro");
        }
        if (Intro)
        {
            Timmer2 += (1 * Time.deltaTime);
            if  (Timmer2 >= Intros)
            {
                Application.LoadLevel("Fight");
            }
        }
        if (Win)
        {
            Timmer2 += (1 * Time.deltaTime);
            if (Timmer2 >= Wins)
            {
                Application.LoadLevel("MainMenu");
            }
        }
        if (Lose)
        {
            Timmer2 += (1 * Time.deltaTime);
            if (Timmer2 >= Loses)
            {
                Application.LoadLevel("MainMenu");
            }
        }
        if (Chimp && Chimp.Alive == false)
        {
            print("DoubleDead");
            
            Won1 += (1 * Time.deltaTime);
            
            if (Won1 >= Won2)
            {
                Application.LoadLevel("Win");
            }
            
        }
        if (Player && Player.Alive == false)
        {
            Won1 += (1 * Time.deltaTime);
            if (Won1 >= Won2)
            {
                Application.LoadLevel("Lose");
            }
        }

    }
    
}
