using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarPlayer : MonoBehaviour {
    public PlayerControler Player;
    public Transform HealthLength;
	// Use this for initialization
	void Start () {
        Player = FindObjectOfType<PlayerControler>();
        HealthLength = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update ()
    {      
        HealthLength.transform.localScale = new Vector3(1 * Player.PlayerHealth, this.transform.localScale.y, this.transform.localScale.z);
        if (HealthLength.transform.localScale.x <= 0.1f)
        {
            HealthLength.transform.localScale = new Vector3(0, this.transform.localScale.y, this.transform.localScale.z);
        }
	}
}
