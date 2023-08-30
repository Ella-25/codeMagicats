using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour //também serve para o game over
{
    public void LoadScenes(string cena) //método público p/ acessar click do botão start + variável
    {
        SceneManager.LoadScene(cena); //carregamento de cena
    }
}
