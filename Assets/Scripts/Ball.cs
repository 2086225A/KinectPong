using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float ballInitialVelocity = 800f;
    public float sx;
    public float sy;

    public Rigidbody rb;
    private bool ballInPlay;

    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetButtonDown("Fire1") || KinectManager.instance.IsFire) && ballInPlay == false)
        {
            transform.parent = null;
            ballInPlay = true;
            rb.isKinematic = false;
            sx = Random.Range(0, 2) == 0 ? -1 : 1;
            sy = Random.Range(0, 2) == 0 ? -1 : 1;
            rb.velocity = new Vector3(Random.Range(20,25) * sx, Random.Range(20, 25) * sy, 0);
            KinectManager.instance.IsFire = false;
        }
        else
        {
            //KinectManager.instance.IsFire = false;
        }
    }
}
