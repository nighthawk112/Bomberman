using UnityEngine;
using UnityEngine.SceneManagement;

public class CreepSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject creeperPrefab;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy() 
    {
        if (creeperPrefab == null) { return; }

        for (int i = 0; i <=4; i++)
        {
            int randNum = Mathf.RoundToInt(Random.Range(0f, spawnPoints.Length - 1));
            Instantiate(creeperPrefab, spawnPoints[randNum].transform.position, Quaternion.identity);
        }

    }

    private void Update()
    {
        if (creeperPrefab.activeSelf == false)
        {
            SceneManager.LoadScene(0);
        }
    }
}
