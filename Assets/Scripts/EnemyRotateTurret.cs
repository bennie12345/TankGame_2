using UnityEngine;
using System.Collections;

public class EnemyRotateTurret : BaseRotateTurret {
    public Transform player;

    override protected void Start()
    {
        
        base.Start();
    }
	// Update is called once per frame
	override protected void Update () {

        if (player != null)
        {
            targetPos = player.position + Vector3.up * 1f;
            base.Update();
        }
	}
}
