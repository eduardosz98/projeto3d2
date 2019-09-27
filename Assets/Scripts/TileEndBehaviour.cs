using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileEndBehaviour : MonoBehaviour
{
    public float destroyTime = 1.5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.GetComponent<PlayerBehaviour>()) {
            GameObject.FindObjectOfType<GameController>().SpawnNextTile();

            Destroy(transform.parent.gameObject, destroyTime);
        }
    }
}
