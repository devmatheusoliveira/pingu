using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class personagem : MonoBehaviour
{
   float contador;
   public GameObject jogador;
   public GameObject jogadorCollider;
   public Animation animacaoPersonagem;
   public CharacterController controleDoPersonagem;

   public float gravidade, movePulo;
   public int dinheiro, pulo;

   public Text moedas;

   bool isNoChao;
   public Button pular;
   void tela()
   {
      pulo = 1;
   }

   
   void Start() 
   {
      pular.onClick.AddListener(tela);
      animacaoPersonagem = jogador.GetComponent<Animation>();
      controleDoPersonagem = GetComponent<CharacterController>();
   }

   void FixedUpdate () 
   {
      movimentos();
      animations();
   }

   void movimentos()
   {
      movePulo = Input.GetAxis("Jump") + pulo;
      isNoChao = jogador.transform.position.y <= 0.25f;
      
      if(controleDoPersonagem.isGrounded && movePulo == 1)
      {
         gravidade = movePulo * 1.9f;
      }
      else
      {
         gravidade -= 0.098f;

      }
      controleDoPersonagem.Move(new Vector3(0,gravidade*Time.fixedDeltaTime,0));
      pulo = 0;
   }

   void animations()
   {
      
      if(!controleDoPersonagem.isGrounded)
      {
         contador +=Time.deltaTime;
         jogador.GetComponent<Animation>().Play("pular");
      }
      else
      {
         if(!animacaoPersonagem.IsPlaying("pular"))
         {
            jogador.GetComponent<Animation>().Play("correr");
         }
      }
   }

   void adicionaMoedas(Collider moeda)
   {
      
      switch(moeda.name)
      {
         case "ouro":
            dinheiro += 10;
         break;
         case "prata":
            dinheiro += 5;
         break;
         case "bronze":
            dinheiro += 1;
         break;
      }
      dinheiro++;
      moedas.text = dinheiro.ToString();
      Destroy(moeda.gameObject);
   }
   void finalizaFase(Collider other)
   {
      Time.timeScale = 0;

   }

   void OnTriggerEnter(Collider other)
   {
      switch(other.tag)
      {
         case "cenario":

         break;

         case "obstaculo":
            print("obstaculos");
            finalizaFase(other);
         break;

         case "moedas":
            adicionaMoedas(other);
         break;

         default:

         break;
      }
   }
}