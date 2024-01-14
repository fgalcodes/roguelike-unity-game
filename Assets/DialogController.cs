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
        "�Ah, viajero intr�pido! Te encuentras ante la encrucijada de tu destino. En mi humilde puesto de comercio, ofrezco dos tesoros que pueden cambiar el rumbo de tu traves�a. La elecci�n, sin duda, marcar� tu camino en esta oscura mazmorra.",
        "Opci�n 1 - Llave Misteriosa:\n�Una llave misteriosa, forjada en las entra�as de la antigua magia? Nadie sabe a qu� puertas abre, pero dicen que detr�s se ocultan secretos olvidados y riquezas inimaginables. �Te atreves a desvelar los misterios que aguardan tras ella?",
        "Opci�n 2 - 100 Monedas:\n�O quiz�s prefieras el tintineo de las monedas, brillando con la promesa de poder y gloria? Con cien monedas, podr�as comprar el favor de los seres sombr�os que moran en estas profundidades, o invertirlas sabiamente en equipo que te haga m�s resistente a las artima�as de la mazmorra.",
        "Recuerda, valiente aventurero, cada elecci�n que hagas resonar� en las sombras de este laberinto. El destino te aguarda, pero solo elige sabiamente aquellos tesoros que iluminar�n tu camino hacia la victoria. �Buena suerte!"
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
            dialogText.text = "�Has llegado al final!";
            keyButton.gameObject.SetActive(true);
            coinsButton.gameObject.SetActive(true);
        }
    }

    void ShowKey()
    {
        // Acciones para la opci�n "Key"
        HideCanvas();
    }

    void ShowCoins()
    {
        // Acciones para la opci�n "Coins"
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
