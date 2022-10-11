using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnPoint;

    public GameObject bullet;

    public float shootForce = 1500f;
    public float shootRate = 0.5f;

    private float shootRateTime = 0;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale != 0f)
        {
            if (Time.time > shootRateTime && GameManager.Instance.cañonAmmo > 0)
            {
                GameManager.Instance.cañonAmmo--;

                GameObject newBullet;

                newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

                newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shootForce);

                shootRateTime = Time.time + shootRate;

            }

        }
    }
}
