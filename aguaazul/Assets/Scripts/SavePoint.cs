using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; //sem isso a inteface nao funciona
using UnityEngine.SceneManagement; //bliblioteca pra gereniar a cena

public class SavePoint : MonoBehaviour
{
    public int totalPontos;
    public Text contador;
    
    public GameObject gameOver;
    
    public static SavePoint acesso;

    void Start()
    {
        acesso = this;
    
    }

    public void atualizaPontosText() => contador.text = totalPontos.
    ToString();

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

   public void RestartGame(string level)
   {
     SceneManager.LoadScene(level);
   }

}
