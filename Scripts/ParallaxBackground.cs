// Bibliotecas do Unity que são carregadas assim que o arquivo C#, sem estás 03 bibliotecas o script não irá funcionar.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

A função deste script no projeto é atribuir o efeito parallax à câmada plano de fundo localizada no Tilepalet.

Métodos deste Script:

void Start();
void SetLayers();
void Move();

GameObject atribuido:

Tilemap, Tilepallet, Layer Background.

*/

// Classe criada junto do arquivo C# e deve conter restritamente o nome do arquivo.
public class ParallaxBackground : MonoBehaviour
{
   // Variável pública com o componente Parallax atribuido na câmera.
   public ParallaxCamera parallaxCamera;
   List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();
  
   // Método que é ativado uma vez apenas e é quando o jogo começa.
   void Start()
   {
       // A sessão abaixo trata de pegar o componente "ParallaxCamera" caso este componente seja nulo por padrão, e configurando em camadas.
       if (parallaxCamera == null)
         parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();
       if (parallaxCamera != null)
         parallaxCamera.onCameraTranslate += Move;
       SetLayers();
   }
  
   // Este método configura as camadas do efeito parallax para abrir no jogo.
   void SetLayers()
   {
       // A sintaxe abaixo atribui o efeito parallax às camadas desejadas.
       parallaxLayers.Clear();
       for (int i = 0; i < transform.childCount; i++)
       {
           ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();
  
           if (layer != null)
           {
               layer.name = "Layer-" + i;
               parallaxLayers.Add(layer);
           }
       }
     }

     // O método abaixo coloca o componente "ParallaxLayer" nas camadas necessárias. 
     void Move(float delta)
     {
         // A sintaxe abaixo utiliza de um laço de repetição para atribuir o atributo "ParallaxLayer" na variável "parallaxLayer".
         foreach (ParallaxLayer layer in parallaxLayers)
       {
           layer.Move(delta);
       }
   }
 }