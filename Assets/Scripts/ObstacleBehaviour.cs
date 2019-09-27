using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleBehaviour : MonoBehaviour
{
    [Tooltip("Espera ate reiniciar o jogo")]
    public float waitTime = 2.0f;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            Destroy(collision.gameObject);

            Invoke("ResetGame", waitTime);
        }
    }

    void ResetGame()
    {
        PlayerBehaviour.rollIncrease = 0.1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
