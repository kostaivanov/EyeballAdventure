using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsController : MonoBehaviour
{
    [SerializeField]
    private GameObject instructionsMenu, gameUIMenu;
    int instructionIndex;
    [SerializeField]
    private Button nextButton, pauseButton;
    private List<GameObject> instructionsList;
    internal bool firstTimeActiveMenu, buttonClicked;

    [SerializeField] private float FadeRate;
    private float targetAlpha;

    private void Awake()
    {
        instructionsMenu.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        instructionIndex = 0;

        instructionsList = new List<GameObject>();
        firstTimeActiveMenu = true;
        buttonClicked = false;

        for (int i = 0; i < instructionsMenu.transform.childCount - 1; i++)
        {
            instructionsList.Add(instructionsMenu.transform.GetChild(i).gameObject);
            Image currentImage = instructionsList[i].GetComponentInChildren<Image>();

            var tempColor = currentImage.color;
            tempColor.a = 0f;
            currentImage.color = tempColor;
            //PlayerPrefs.SetInt()
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instructionsMenu.activeSelf.Equals(true) && gameUIMenu.activeSelf.Equals(true) && firstTimeActiveMenu == true)
        {
            pauseButton.gameObject.SetActive(false);
            firstTimeActiveMenu = false;
            instructionsList[1].SetActive(false);
            instructionsList[2].SetActive(false);
            instructionsList[3].SetActive(false);
            instructionsList[4].SetActive(false);
        }
        else
        {
            if (gameUIMenu.activeSelf.Equals(true) && instructionIndex < instructionsList.Count && instructionIndex < instructionsList.Count)
            {
                Image currentImage = instructionsList[instructionIndex].GetComponentInChildren<Image>();
                if (currentImage.color.a <= 1)
                {
                    StartCoroutine(FadeIn(currentImage));
                }
                nextButton.onClick.AddListener(OnButtonClicked);

                buttonClicked = true;
            }
        }
    }

    private void OnButtonClicked()
    {
        if (instructionIndex < instructionsList.Count - 1 && buttonClicked == true)
        {
            instructionsList[instructionIndex].SetActive(false);
            instructionsList[instructionIndex + 1].SetActive(true);

            instructionIndex++;
            buttonClicked = false;
        }
        if (instructionIndex == instructionsList.Count - 1 && buttonClicked == true)
        {
            instructionsMenu.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            Time.timeScale = 1.0f;
            instructionIndex++;
            buttonClicked = false;

        }
    }

    IEnumerator FadeIn(Image image)
    {
        targetAlpha = 1.0f;
        Color curColor = image.color;
        while (Mathf.Abs(curColor.a - targetAlpha) > 0.0001f)
        {
            curColor.a = Mathf.Lerp(curColor.a, targetAlpha, FadeRate * Time.unscaledDeltaTime);
            image.color = curColor;
            yield return null;
        }
    }
}
