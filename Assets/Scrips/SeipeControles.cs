using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeipeControles : MonoBehaviour {
    public bool Tap, SwipeLeft, SwipeRight, SwipeUp, SwipeDown, IsDraging;
    public Vector2 StartToch, SwipeDelta;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
        Tap = SwipeLeft = SwipeRight = SwipeUp = SwipeDown = false;
        if (Input.GetMouseButtonDown(0))
        {
            Tap = true;
            IsDraging = true;
            StartToch = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            IsDraging = false;
            Reset();
        }
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                IsDraging = true;
                Tap = true;
                StartToch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                IsDraging = false;
                Reset();
            }
            if(SwipeDelta.magnitude > 100)
            {
                print("Magnitude is high enoughf");
                float x = SwipeDelta.x;
                float y = SwipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x < 0)
                    {
                        SwipeLeft = true;
                    }
                    else
                    {
                        SwipeRight = true;
                    }
                }
                else
                {
                    if (y < 0)
                    {
                        SwipeDown = true;
                    }
                    else
                    {
                        SwipeUp = true;
                    }
                }
                if (SwipeUp == true)
                {
                    Debug.Log("Swiped Up");
                }
                if (SwipeDown == true)
                {
                    Debug.Log("Swiped Down");
                }
                if (SwipeLeft == true)
                {
                    Debug.Log("Swiped Left");
                }
                if (SwipeRight == true)
                {
                    Debug.Log("Swiped Right");
                }
                Reset();
            }
        }
        SwipeDelta = Vector2.zero;        
        if (IsDraging)
        {
            if(Input.touches.Length > 0)
            {
                SwipeDelta = Input.touches[0].position - StartToch;
            }
            else if (Input.GetMouseButton(0))
            {
                SwipeDelta = (Vector2)Input.mousePosition - StartToch;
            }
        }
        if (SwipeDelta.magnitude > 100)
        {
            print("Magnitude is high enoughf");
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                if (x < 0)
                {
                    SwipeLeft = true;
                }
                else
                {
                    SwipeRight = true;
                }
            }
            else
            {
                if (y < 0)
                {
                    SwipeDown = true;
                }
                else
                {
                    SwipeUp = true;
                }
            }
            if (SwipeUp == true)
            {
                Debug.Log("Swiped Up");
            }
            if (SwipeDown == true)
            {
                Debug.Log("Swiped Down");
            }
            if (SwipeLeft == true)
            {
                Debug.Log("Swiped Left");
            }
            if (SwipeRight == true)
            {
                Debug.Log("Swiped Right");
            }
            Reset();
        }
    }
    private void Reset()
    {
        IsDraging = false;
        StartToch = SwipeDelta = Vector2.zero;
    }
}
