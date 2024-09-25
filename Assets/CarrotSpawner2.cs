using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotSpa : MonoBehaviour
{
    public GameObject carrotPrefab;
    public Transform spawnPoint; 
    private float[] spawnPositionsX = {0.65f,1f,2f, 1.8f,1.5f,1.6f,1.7f}; 
    // Start is called before the first frame update
    void Start()
    {
         StartCoroutine(SpawnCarrot());
          IEnumerator SpawnCarrot()
          {
        while (true) 
        {
            float waitTime = Random.Range(0.1f, 2f);
            yield return new WaitForSeconds(waitTime);

            BoxCollider2D boxCollider2D = carrotPrefab.GetComponent<BoxCollider2D>();
            SpriteRenderer spriteRenderer = carrotPrefab.GetComponentInChildren<SpriteRenderer>();

            boxCollider2D.enabled = true;
            spriteRenderer.enabled = true;

            float randomX = spawnPositionsX[Random.Range(0, spawnPositionsX.Length)];

            Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

            Instantiate(carrotPrefab, spawnPosition, Quaternion.identity);
        }
    }
    }
    
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
