using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
    public int speed;
    public float limiter;
    public bool move;
    private bool isStopSound;
	// Use this for initialization
	void Start () {
        move = true;
        GetComponent<AudioSource>().Play();
        isStopSound = false;
	}
	
	// Update is called once per frame
	void Update () {
        float newPos  = (transform.position.x)+(speed*Time.deltaTime);
        if (newPos < limiter&&move)
        {

            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }

        else if(!isStopSound)
        {
            isStopSound = true;
            GetComponent<AudioSource>().Stop();
        }
	}
}
