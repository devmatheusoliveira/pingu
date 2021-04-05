using UnityEngine;
using UnityEngine.UI;

public class paginas : MonoBehaviour
{
    public Button play;
    public Canvas paginaInicial, paginaPrincipal;

	void Start () {
        paginaPrincipal.enabled = false;
        Time.timeScale = 0;
		play.onClick.AddListener(inicio);
	}
    void inicio()
    {
        Time.timeScale = 1;
        paginaInicial.enabled = false;
        paginaPrincipal.enabled = true;
    }
}
