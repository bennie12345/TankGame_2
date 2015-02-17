using UnityEngine;
using System.Collections;

public class Tank : DestructableObject {
    private Transform[] transforms;
    protected Transform nozzle;
    protected Transform turret;
    protected Vector3 targetPos;
    public float reloadTime;
    public GameObject bulletPrefab;
    public float timeToReload;
    public float shootingRange;
	
	// Update is called once per frame
	void Update () {
        aimTurret();
        fireBullet();
        reloadTimer();
	}
	void findNozzleTurret()
	{
         bool turretFound = false;
         transforms = gameObject.GetComponentsInChildren<Transform>();
         foreach (Transform t in transforms)
         {
             if (t.gameObject.name == "turret")
             {
                 turret = t;
                 turretFound = true;
             }
             if (t.gameObject.name == "nozzle")
             {
                 nozzle = t;

             }
         }
         if (!turretFound)
         {
             print("turret not found in gameObject");
         }
	}
    void Start()
    {
        findNozzleTurret();
        
    }

	void aimTurret()
	{
        turret.LookAt(targetPos);
	}

	void reloadTimer()
	{
        reloadTime += Time.deltaTime;
        if (reloadTime >= timeToReload)
        {
            fireBullet();

        }
	}

	void fireBullet()
	{
        if (Input.GetButtonDown("Fire1"))
        {
            Quaternion rotation = Quaternion.Euler(Vector3.up * turret.transform.rotation.eulerAngles.y);

            Instantiate(bulletPrefab, nozzle.transform.position, rotation);
        }
	}

}
