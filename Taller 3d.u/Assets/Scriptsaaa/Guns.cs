using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Guns : MonoBehaviour
{
    [SerializeField]
    PlayerStaticVariable owner;
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;
    //reference
    public Camera fpcCam;
    public Transform attacPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    //Graphis
    public GameObject muzzleFlash, bulletHoleGraphic;
    public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI Text;
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();
        //SetText
        Text.SetText(bulletsLeft + "/" + magazineSize);
    }

    private void MyInput()
    {
        if (allowButtonHold)
        {
            shooting = Input.GetKey(KeyCode.Mouse0);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Mouse0);
        }
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();
        //Shoot
        if(readyToShoot && shooting && !reloading && bulletsLeft>0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }
    private void Shoot()
    {
        readyToShoot = false;
        //Spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);
        //Calculate Direction with spread
        Vector3 direction = fpcCam.transform.forward + new Vector3(x, y, 0);
       //Raycast
        if(Physics.Raycast(fpcCam.transform.position,direction,out rayHit, range,whatIsEnemy,QueryTriggerInteraction.Ignore))
        {
            //Debug.Log(rayHit.collider.name);
            if(rayHit.collider.CompareTag("Enemy"))
            {
                rayHit.collider.GetComponent<EnemyBase>().ReceiveDamage(damage,owner);
                Debug.Log(rayHit.collider.name);
            }
        }
        //ShakeCamera
        camShake.Shake(camShakeDuration,camShakeMagnitude );
        //Graphics
        
        GameObject hole_aux = Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.identity);
        hole_aux.transform.forward = rayHit.normal;
        Instantiate(muzzleFlash, attacPoint.position, Quaternion.identity);



        bulletsLeft--;
        bulletsShot--;
        Invoke("ResetShot", timeBetweenShooting);
        if (bulletsShot > 0 && bulletsLeft > 0)
        {
            Invoke("Shoot", timeBetweenShots);
        }
    }
    private void ResetShot()
    {
        readyToShoot = true;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }
   
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
