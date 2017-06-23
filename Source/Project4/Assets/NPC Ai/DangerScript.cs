using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerScript : MonoBehaviour {

    public GameObject player;
    public float myDistanceToPlayer;
    public CameraEffects camEffects;

    void Start()
    {
        player = GameObject.Find("Player");
        camEffects = player.transform.GetChild(0).GetComponent<CameraEffects>();
    }

void FixedUpdate()
    {
        myDistanceToPlayer = Vector3.Distance(player.transform.position, this.gameObject.transform.position);
        if (myDistanceToPlayer <= camEffects.anxietyRadius)
        {
            camEffects.closeEnemy = this.gameObject;
        }
    }
}
