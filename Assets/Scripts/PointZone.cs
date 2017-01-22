using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointZone : MonoBehaviour {

	void OnTriggerEnter(Collider c)
    {
        print("Flag 1");
        if (gameObject.name == "Goal001")
        {
            GameSystem.instance.playerScored(2);
        }
        else
        {
            GameSystem.instance.playerScored(1);
        }
    }
}
