using UnityEngine;
using System.Collections;

public class Enemy : Tank {
    public Transform player;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        DetermineTarget();
        CheckIfSeesPlayer();
	}
	void DetermineTarget()
	{
        if (player != null)
        {
            targetPos = player.position + Vector3.up * 1f;
        }
	}
	void CheckIfSeesPlayer()
	{
        Ray myRay = new Ray();
        myRay.origin = turret.position;
        myRay.direction = turret.forward;

        RaycastHit hitInfo;

        //checken mbv van een raycast of de player in zicht is
        if (Physics.Raycast(myRay, out hitInfo, shootingRange))
        {
            string hitObjectName = hitInfo.collider.gameObject.name;

            if (hitObjectName == "Tank")
            {
                Instantiate(bulletPrefab, nozzle.position, nozzle.rotation);

                reloadTime = 0f;
            }
        }
	}
}
