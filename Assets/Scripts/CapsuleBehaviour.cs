using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerBehaviour>())
        {
            PlayerBehaviour.rollIncrease -= 0.05f;
            Destroy(gameObject);
        }
    }   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
