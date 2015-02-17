using UnityEngine;
using System.Collections;

public class Explosion : TempObject {
    private Light light;
    public float lightFade;
	// Use this for initialization
	void Start () {
        light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void FadeExplosion()
    {
        light.intensity -= lightFade;
    }
}
