using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour //tamb�m serve para o game over
{
    public void LoadScenes(string cena) //m�todo p�blico p/ acessar click do bot�o start + vari�vel
    {
        SceneManager.LoadScene(cena); //carregamento de cena
    }
}
