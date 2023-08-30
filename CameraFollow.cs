using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; //acesso ao componente tranform do obj player
    public float minX, maxX;

    private void FixedUpdate()
    {
        Vector3 newPosition = player.position + new Vector3(0, 0, -10); //soma com vetor de 3 eixos. Z � -10 p/ c�mera pegar o jogo
        newPosition.y = 0.1f;
        transform.position = newPosition; //concertando a posi��o da c�mera 

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z); //limita��o de c�mera p/ n�o aparecer borda com m�nimo e m�ximo
    }
}
