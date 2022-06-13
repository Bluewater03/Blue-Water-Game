// Variávei que carregam por padrão assim que o arquivo C# é criado, são necessárias para o projeto funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Biblioteca necessária para manipular elementos de "User Interface".
using UnityEngine.UI;

// Nome da classe que deve ter o exato nome do arquivo para funcionar.
public class healthController : MonoBehaviour
{
    // Variáveis públicas do tipo float que trabalham com valores decimais.
    public float health = 1;
    // Variável float que garante que o valor "health" não seja menor que zero ou exceda a variável "maxHealth".
    public float Health {
        get {
            return health;
        }
        set {
            health = Mathf.Clamp(value, 0, maxHealth);
        }
    }
    public float maxHealth = 100;

    // Variáveis de referência que requer um objeto do Unity para funcionar, no caso um é "Image" e o outro espera um "GameObject".
    public Image healthBar;
    public GameObject gameOver;
   
    // Variável que permite que outros scripts acessem este de forma remota, contando que estejam na mesma pasta.
    public static healthController acesso;

    // Método que é executado apenas quando o jogo inicia.
    void Start()
    {
        // A sintaxe abaixo faz com que este script seja público e que seus métodos públicos possam ser acessados de forma remota.

        acesso = this;
    }

    // Método público que subtrai pontos da vida do jogador em um valor pré-determinado.
    public void TakeDamage()
    {
        Health -= 15f;
        
        UpdateHealthBar();
        Death();
    }
    
    // Método público que acrescenta pontos na vida do jogador em um valor pré-determinado.
    public void Heal()
    {
        Health += 15f;
        
        UpdateHealthBar();
    }

    // Método que confere se o jogador está com seus pontos de vida zerados, e exibe a tela de game over.
    void Death()
    {
        if (Health == 0){
            SavePoint.acesso.ShowGameOver();
         
        }
    UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Health / maxHealth;
    }
}
