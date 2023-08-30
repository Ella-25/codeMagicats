using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //importação de biblioteca de cena

public class ProxFase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) //se a colisão for com a tag player, carrega a segunda fase
        {
            SceneManager.LoadScene("Fase2");
        }
    }
}
