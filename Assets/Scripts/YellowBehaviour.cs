using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowBehaviour : MonoBehaviour
{
    [Tooltip("Espera ate reiniciar o jogo")]
    public float waitTime = 1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PlayerBehaviour>())
        {
            PlayerBehaviour.numeroVidas--;            

            if (PlayerBehaviour.numeroVidas == 0)
            {
                Destroy(collision.gameObject);
                ResetGame();
            }

            Destroy(gameObject);
        }
    }

    void ResetGame()
    {
        PlayerBehaviour.rollIncrease = 0.1f;
        PlayerBehaviour.numeroVidas = 2;
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
