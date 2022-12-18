using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {
    public Transform HealthBarLength;
    public PlayerControler Player;
    public AiControler Chimp;
	// Use this for initialization
	void Start () {
        HealthBarLength = GetComponent<Transform>();
        Player = FindObjectOfType<PlayerControler>();
        Chimp = FindObjectOfType<AiControler>();
	}
	
	// Update is called once per frame
	void Update () {
        HealthBarLength.transform.localScale = new Vector3(1 * Chimp.CurrentHealth, this.transform.localScale.y, this.transform.localScale.z);
	}
}
