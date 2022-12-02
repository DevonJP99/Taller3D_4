using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    // spawn common enemy in stores 
    // activate guardias qeu estand esactivados por default

    [SerializeField]
    List<Transform> toGoPoints;
    [SerializeField]
    List<Transform> stores;
    [SerializeField]
    List<GameObject> enemieSpawned;
    [SerializeField]
    GameObject[] Guards;
    [SerializeField]
    GameObject enemyPrefab;

    public float secondsToScore = 60 * 5;

    float delt = 0;

    // Update is called once per frame
    void Update()
    {
        delt += Time.deltaTime;
        if (!Guards[(int)(delt/60)].activeSelf)
        {
            Guards[(int)(delt / 60)].SetActive(true);
        }
    }


    private void Start()
    {
        //instancia enemys y activa gaurdia 0
        for (int i = 0; i < 20; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, stores[(int)(Random.value * stores.Count)].position, Quaternion.identity, transform);
            enemy.GetComponent<EnemyCompradorStatePasive>().pointsToGo = toGoPoints;
            enemieSpawned.Add(enemy);
            enemy.SetActive(true);
        }
    }
}
