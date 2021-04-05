using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class paginas : MonoBehaviour
{
    public Button play, replay, continua;
    public Canvas paginaInicial, paginaPrincipal, paginaReniciar;

	void Start ()
    {
        paginaPrincipal.enabled = false;
        paginaReniciar.enabled = false;

        Time.timeScale = 0;
		play.onClick.AddListener(inicio);
		continua.onClick.AddListener(continuar);
		replay.onClick.AddListener(reiniciar);
	}
    void inicio()
    {
        Time.timeScale = 1;
        paginaInicial.enabled = false;
        paginaReniciar.enabled = false;
        paginaPrincipal.enabled = true;
    }

    void continuar()
    {
        Time.timeScale = 1;
        paginaInicial.enabled = false;
        paginaReniciar.enabled = false;
        paginaPrincipal.enabled = true;
    }
    void reiniciar()
    {
        SceneManager.LoadScene(0);
    }
}