using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour {
    public GameObject Text;
    public float timmer1, timmer2;
    public bool Add, Subtract;
	// Use this for initialization
	void Start () {
        Subtract = true;
	}
	
	// Update is called once per frame
	void Update () {
        timmer2 += (1 * Time.deltaTime);
        if (Subtract == true)
        {
            Text.GetComponent<Text>().color -= new Color(0, 0, 0, (1 * Time.deltaTime));
        }
        if (Subtract == false)
        {
            Text.GetComponent<Text>().color += new Color(0, 0, 0, (1 * Time.deltaTime));
        }
        if (timmer2 >= timmer1)
        {
           Subtract = !Subtract;
            timmer2 = 0;
        }

    }
}
