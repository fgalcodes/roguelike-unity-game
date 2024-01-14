using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    public Text dialogText;
    public Button nextButton;
    public Button keyButton;
    public Button coinsButton;

    private string[] paragraphs = {
        "¡Ah, viajero intrépido! Te encuentras ante la encrucijada de tu destino. En mi humilde puesto de comercio, ofrezco dos tesoros que pueden cambiar el rumbo de tu travesía. La elección, sin duda, marcará tu camino en esta oscura mazmorra.",
        "Opción 1 - Llave Misteriosa:\n¿Una llave misteriosa, forjada en las entrañas de la antigua magia? Nadie sabe a qué puertas abre, pero dicen que detrás se ocultan secretos olvidados y riquezas inimaginables. ¿Te atreves a desvelar los misterios que aguardan tras ella?",
        "Opción 2 - 100 Monedas:\n¿O quizás prefieras el tintineo de las monedas, brillando con la promesa de poder y gloria? Con cien monedas, podrías comprar el favor de los seres sombríos que moran en estas profundidades, o invertirlas sabiamente en equipo que te haga más resistente a las artimañas de la mazmorra.",
        "Recuerda, valiente aventurero, cada elección que hagas resonará en las sombras de este laberinto. El destino te aguarda, pero solo elige sabiamente aquellos tesoros que iluminarán tu camino hacia la victoria. ¡Buena suerte!"
    };

    private int currentParagraph = 0;

    void Start()
    {
        dialogText.text = paragraphs[currentParagraph];
        nextButton.onClick.AddListener(ShowNextParagraph);
        keyButton.onClick.AddListener(ShowKey);
        coinsButton.onClick.AddListener(ShowCoins);
        HideButtons();
    }

    void ShowNextParagraph()
    {
        currentParagraph++;

        if (currentParagraph < paragraphs.Length)
        {
            dialogText.text = paragraphs[currentParagraph];
        }
        else
        {
            HideButtons();
            dialogText.text = "¡Has llegado al final!";
            keyButton.gameObject.SetActive(true);
            coinsButton.gameObject.SetActive(true);
        }
    }

    void ShowKey()
    {
        // Acciones para la opción "Key"
        HideCanvas();
    }

    void ShowCoins()
    {
        // Acciones para la opción "Coins"
        HideCanvas();
    }

    void HideButtons()
    {
        nextButton.gameObject.SetActive(false);
        keyButton.gameObject.SetActive(false);
        coinsButton.gameObject.SetActive(false);
    }

    void HideCanvas()
    {
        gameObject.SetActive(false);
    }
}
