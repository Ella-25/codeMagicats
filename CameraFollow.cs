using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //acesso ao componente tranform do obj player
    public float minX, maxX;

    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10); //soma com vetor de 3 eixos. Z é -10 p/ câmera pegar o jogo
        newPosition.y = 0.1f;
        transform.position = newPosition; //concertando a posição da câmera 

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z); //limitação de câmera p/ não aparecer borda com mínimo e máximo
    }
}
