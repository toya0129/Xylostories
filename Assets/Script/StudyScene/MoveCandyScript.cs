using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCandyScript : MonoBehaviour {

    private Vector3 goal_pos;
    private float speed = 1;
    private float step;

    // Use this for initialization
    void Start () {
        goal_pos = new Vector3(Random.Range(-14, 15), Random.Range(-9, 15), 1);
    }
	
	// Update is called once per frame
	void Update () {
        step = speed * Time.deltaTime;
        this.gameObject.transform.localPosition = Vector3.MoveTowards(this.gameObject.transform.localPosition, goal_pos, 2f);

        if (this.gameObject.transform.localPosition == goal_pos)
        {
            this.gameObject.GetComponent<MoveCandyScript>().enabled = false;
        }
    }
}
