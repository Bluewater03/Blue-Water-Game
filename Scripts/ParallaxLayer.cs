// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class ParallaxLayer : MonoBehaviour
 {
       // Variáveis públicas do tipo "float" para aceitar valores quebrados.
       public float parallaxFactor;

       // Método público que configura o fator parallax a cada camada atribuida.
       public void Move(float delta)
       {
           // Sintaxe que utiliza o "Vector3" para efetuar uma equação que irá atualizar a posição da camada com o fator parallax.
           Vector3 newPos = transform.localPosition;
           newPos.x -= delta * parallaxFactor;
           transform.localPosition = newPos;
       }
 }