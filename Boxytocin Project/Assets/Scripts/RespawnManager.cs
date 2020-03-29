using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{

    public float respawnDelay = 5.0f;
    public Transform respawnPoint;
    public Player1Script player1;
    public GameObject player1Object;

    // Start is called before the first frame update
    void Start()
    {

        player1 = GetComponent<Player1Script>();
    }

    public void Respawn()
    {
        StartCoroutine("RespawnCoroutine");
    }

    public IEnumerator RespawnCoroutine()
    {
        yield return new WaitForSeconds(respawnDelay);
    }

}
