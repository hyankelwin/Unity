using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class corona : MonoBehaviour
{

    public AudioSource som1;
    public AudioSource som2;

    public Text txtVidas;
    private static int vidas = 5;

    // Start is called before the first frame update
    void Start()
    {
        txtVidas.text = "Vidas: " + vidas;

        som1 = GetComponents<AudioSource>()[0];
        som2 = GetComponents<AudioSource>()[1];
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("azul") && collision.relativeVelocity.magnitude > 2)
        {
            som1.Play();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("vermelho"))
        {
            
            som2.Play();
            vidas--;
            if (vidas < 1)
            {
                SceneManager.LoadScene("GameOver");
            }
            else {
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (other.gameObject.CompareTag("verde"))
        {
            SceneManager.LoadScene("Winner");
        }

    }
}
