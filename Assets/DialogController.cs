using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogController : MonoBehaviour
{
    public TMP_Text dialogText;
    public Button nextButton;
    public Button prevButton;
    public Button keyButton;
    public Button coinsButton;

    //private bool keyButtonClicked = false;
    private bool coinsButtonClicked = false;

    private string[] paragraphs = {
        "�Ah, viajero intr�pido!\nTe encuentras ante la encrucijada de tu destino.\nEn mi humilde puesto de comercio, ofrezco dos tesoros que pueden cambiar el rumbo de tu traves�a. La elecci�n, sin duda, marcar� tu camino en esta oscura mazmorra.",
        "Opci�n 1 - Llave Misteriosa:\n�Una llave, forjada en las entra�as de la antigua magia? Nadie sabe a qu� puertas abre, pero dicen que detr�s se ocultan secretos olvidados y riquezas inimaginables.\n�Te atreves a desvelar los misterios que aguardan tras ella?",
        "Opci�n 2 - 100 Monedas:\n�O quiz�s prefieras el tintineo de las monedas, brillando con la promesa de poder y gloria?\nCon cien monedas, podr�as comprar el favor de los seres sombr�os que moran en estas profundidades, o invertirlas sabiamente en equipo que te haga m�s resistente a las artima�as de la mazmorra.",
        "Recuerda, valiente aventurero, cada elecci�n que hagas resonar� en las sombras de este laberinto. El destino te aguarda, pero solo elige sabiamente aquellos tesoros que iluminar�n tu camino hacia la victoria. �Buena suerte!"
    };

    private int currentParagraph = 0;

    void Start()
    {
        dialogText.text = paragraphs[currentParagraph];
        nextButton.onClick.AddListener(ShowNextParagraph);
        keyButton.onClick.AddListener(ShowKey);
        coinsButton.onClick.AddListener(ShowCoins);
        prevButton.onClick.AddListener(ShowPrevParagraph);
        UpdateButtons();
    }

    public void ShowNextParagraph()
    {

        if (currentParagraph < paragraphs.Length - 1)
        {
            currentParagraph++;
            dialogText.text = paragraphs[currentParagraph];
            UpdateButtons();
        }
        else
        {
            dialogText.text = "";
            UpdateButtons();
        }
    }

    public void ShowPrevParagraph()
    {
        if (currentParagraph > 0)
        {
            currentParagraph--;
            dialogText.text = paragraphs[currentParagraph];
            UpdateButtons();
        }
    }

    void ShowKey()
    {
        //if (!keyButtonClicked)
        //{
        //    // Realizar acciones espec�ficas para el bot�n de llave
        //    // ...

        //    keyButtonClicked = true;
        //    keyButton.interactable = false;  // Desactivar interactividad
        //    HideCanvas();
        //}
    }

    void ShowCoins()
    {
        if (!coinsButtonClicked)
        {
            GameObject player = GameObject.Find("Player");

            if (player != null)
            {
                GoldController goldController = player.GetComponent<GoldController>();

                if (goldController != null)
                {
                    goldController.AddCoins(100);
                    goldController.RefreshUI();
                }
            }

            coinsButtonClicked = true;
            coinsButton.interactable = false;
            HideCanvas();
        }
    }

    void UpdateButtons()
    {
        if (currentParagraph == 0)
        {
            nextButton.gameObject.SetActive(true);
            prevButton.gameObject.SetActive(false);
            keyButton.gameObject.SetActive(false);
            coinsButton.gameObject.SetActive(false);

            Time.timeScale = 1f;
        }
        else if (currentParagraph == paragraphs.Length - 1)
        {
            nextButton.gameObject.SetActive(false);
            prevButton.gameObject.SetActive(true);
            keyButton.gameObject.SetActive(true);
            coinsButton.gameObject.SetActive(true);
            
            Time.timeScale = 0f;
        }
        else
        {
            nextButton.gameObject.SetActive(true);
            prevButton.gameObject.SetActive(true);
            keyButton.gameObject.SetActive(false);
            coinsButton.gameObject.SetActive(false);
        }
    }

    void HideCanvas()
    {
        Time.timeScale = 1f;

        gameObject.SetActive(false);
    }
}
