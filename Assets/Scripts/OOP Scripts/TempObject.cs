﻿using UnityEngine;
using System.Collections;

public class TempObject : MonoBehaviour {
    public float maxLifeTime;
    private float lifeTime;
    
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        RemoveAfterTime();
	}

    void RemoveAfterTime()
    {
        lifeTime += Time.deltaTime;
        if (lifeTime > maxLifeTime)
        {
            Destroy(this.gameObject);
        }
    }
}
