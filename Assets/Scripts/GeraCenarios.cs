using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeraCenarios : MonoBehaviour
{
    public GameObject[] obstaculos, itensDeForça,cenarios, moedas;
    public GameObject RaizDasCoisas;
    public Transform PosInicial;
    public int velocidade;
    private float cronometro, cronometro2, cronometro3, cronometro4, velteste, contador;
    public GameObject chao, rua;

    public Color[] cores;
    public Color corAtual;
    private int mudaCor;

    float r,g,b;

    int i;

    void Start()
    {
        InvokeRepeating("geraMoedas", 1, 0.3f);   
    }
    void Update()
    {
        if(instanciaObstaculos(Random.Range(0.8f,5)))
        {
            Invoke("criaObstaculos",1);
            cronometro2=0;
        }

        if(instanciaCenas(0.5f))
        {
            Invoke("CriaCenario",1);
            cronometro3=0;
        }

        if(instanciaRua(0.3f))
        {
            Invoke("criaRua",1);
            cronometro4=0;
        }

        if(contadorDeTempo(10) && mudaCor < cores.Length-1)
        {   
            mudaCor++;
            cronometro = 0;
        }
        else
        {
            if(corAtual != cores[mudaCor])
            {
                float tempo = 3f*Time.deltaTime;
                r = Mathf.SmoothStep(corAtual.r,cores[mudaCor].r, tempo);
                g = Mathf.SmoothStep(corAtual.g,cores[mudaCor].g, tempo);
                b = Mathf.SmoothStep(corAtual.b,cores[mudaCor].b, tempo);
                corAtual = new Color(r,g,b);
                chao.GetComponent<Renderer>().material.color = corAtual;
            }
        }
    }

    
    bool contadorDeTempo(float tempo)
    {
        cronometro += Time.deltaTime;
        if(cronometro > tempo){
            return true;
        }else{
            return false;
        }
        
    }
    bool instanciaObstaculos(float tempo)
    {
        cronometro2 += Time.deltaTime;
        if(cronometro2 > tempo){
            return true;
        }else{
            return false;
        }
        
    }
    bool instanciaCenas(float tempo)
    {
        cronometro3 += Time.deltaTime;
        if(cronometro3 > tempo){
            return true;
        }else{
            return false;
        }
        
    }
    bool instanciaRua(float tempo)
    {
        cronometro4 += Time.deltaTime;
        if(cronometro3 > tempo){
            return true;
        }else{
            return false;
        }
        
    }
    void CriaCenario()
    {
        
        switch(mudaCor)
        {
            case 0:
                laterais(0, 9);
            break;

            case 1:
                laterais(10, 14);
            break;

            case 2:
                laterais(21, 25);
                cidade(rua);
            break;

            case 3:
                laterais(15, 20);
            break;
            default:
                print("Em andamento...");
            break;
        }
        
    }
    void laterais(int min, int max)
    {

        int randomEsquerda = 0, randomDireita = 0;

        randomDireita = Random.Range(min,max);
        randomEsquerda = Random.Range(min,max);

        criarObjetosLaterais(false, cenarios[randomEsquerda]);
        criarObjetosLaterais(true, cenarios[randomDireita]);
    }

    void cidade(GameObject ObjetoParaInstanciar)
    {
        GameObject novo = Instantiate(ObjetoParaInstanciar);
        novo.transform.position = PosInicial.position + new Vector3(0,0f,0);
        novo.transform.rotation = Quaternion.Euler(0,0,0);
        novo.transform.parent = RaizDasCoisas.transform;
        novo.AddComponent<BoxCollider>().isTrigger = true;
        novo.AddComponent<Rigidbody>().useGravity = false;
        novo.GetComponent<Rigidbody>().freezeRotation = true;
        novo.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-velocidade), ForceMode.Force);
        novo.tag = "cenario";
    }

    void criarObjetosLaterais(bool IsDireita, GameObject ObjetoParaInstanciar)
    {
        int positionInicialEmX;

        if(IsDireita)
        {
            positionInicialEmX = Random.Range(3,5);
        }
        else
        {
            positionInicialEmX = Random.Range(-3,-5);
        }

        GameObject novo = Instantiate(ObjetoParaInstanciar);
        novo.transform.position = PosInicial.position + new Vector3(positionInicialEmX,0.1f,0);
        novo.transform.rotation = Quaternion.Euler(0,Random.Range(0,360),0);
        novo.transform.parent = RaizDasCoisas.transform;
        novo.AddComponent<BoxCollider>().isTrigger = false;
        novo.AddComponent<Rigidbody>().useGravity = false;
        novo.GetComponent<Rigidbody>().freezeRotation = true;
        novo.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-velocidade), ForceMode.Force);
        novo.tag = "cenario";
    }
    void criaObstaculos()
    {
        GameObject novo = Instantiate(obstaculos[mudaCor]);
        novo.transform.position = PosInicial.position;
        novo.transform.rotation = Quaternion.Euler(0,0,0);
        novo.transform.parent = RaizDasCoisas.transform;
        novo.AddComponent<Rigidbody>().useGravity = false;
        novo.GetComponent<Rigidbody>().freezeRotation = true;
        novo.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-velocidade), ForceMode.Force);
        novo.tag = "obstaculo";
    }

    void geraMoedas()
    {
        GameObject novo = Instantiate(moedas[Random.Range(0,4)]);
        novo.transform.position = PosInicial.position+ new Vector3(0,0.75f,0);
        novo.transform.parent = RaizDasCoisas.transform;
        novo.AddComponent<SphereCollider>().isTrigger = true;
        novo.AddComponent<Rigidbody>().useGravity = false;
        novo.GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-velocidade), ForceMode.Force);
        novo.GetComponent<Rigidbody>().AddTorque(new Vector3(0,200,0), ForceMode.Force);
        novo.tag = "moedas";
        novo.name = novo.name.Replace("(Clone)","");
    }
}
