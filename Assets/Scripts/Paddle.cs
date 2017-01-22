using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    public float paddleSpeed = 100f;

    private string axis;

    private Vector3 playerPos;
	
	// Update is called once per frame
	void Update () {
        if(gameObject.name == "paddle002")
        {
            axis = "Horizontal";
        }
        else
        {
            axis = "Vertical";
        }
        float yPos = transform.position.y;

        if (KinectManager.instance.IsAvailable)
        {
            yPos = KinectManager.instance.PaddlePosition;
        }
        else
        {
            yPos = transform.position.y + (Input.GetAxis(axis) * paddleSpeed);
        }

        playerPos = new Vector3(transform.position.x,Mathf.Clamp(yPos, 2f, 29f), 11f);

        transform.position = playerPos;
    }
}
