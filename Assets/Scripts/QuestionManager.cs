using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public MainMenu mainMenu;
    public ScoreBoard scoreBoard;

    public TextMeshProUGUI Content, OptionA, OptionB, OptionC, OptionD;
    public List<Button> OptionButtonList;

    public List<QuestionData> questions;

    private QuestionData currentQuestion;

    private int CurrentIndex = 0;
    private int questionCount;
    private bool inDelay;
    public AudioSource audioSource;
    public AudioClip sucSound;
    public AudioClip failSound;

    private void OnEnable()
    {
        CurrentIndex = 0;
        Karistir(questions);
        Fill(questions[CurrentIndex]);
    }

    public void Fill(QuestionData qd)
    {
        inDelay = false;
        currentQuestion = qd;
        Content.text = qd.questionText;
        OptionA.text = qd.optionA;
        OptionB.text = qd.optionB;
        OptionC.text = qd.optionC;
        OptionD.text = qd.optionD;
        for (int i = 0; i < OptionButtonList.Count; i++)
        {
            OptionButtonList[i].GetComponent<Image>().color = Color.white;
        }
    }

    public void Answer(int option)
    {
        if (inDelay) return;
        bool isRight = currentQuestion.correctAnswer == (AnswerOption)option;
        if (!isRight)
        {
            OptionButtonList[option].GetComponent<Image>().color = Color.red;
            audioSource.PlayOneShot(sucSound);
        }
        else
        {
            audioSource.PlayOneShot(failSound);
        }
        mainMenu.player.Score += isRight ? 10 : 0;
        OptionButtonList[(int)currentQuestion.correctAnswer].GetComponent<Image>().color = Color.green;
        Debug.Log(isRight ? "Cevap doğru" : "Cevap yanlış");
        StartCoroutine(CheckAnswer());
    }

    public IEnumerator CheckAnswer()
    {
        inDelay = true;
        yield return new WaitForSeconds(2f);

        CurrentIndex++;
        questionCount++;
        if (questions.Count - 1 < CurrentIndex)
        {
            End();
            yield break;
        }
        if (questionCount == 10)
        {
            End();
        }
        Fill(questions[CurrentIndex]);
    }

    private void End()
    {
        scoreBoard.ListAllPlayers();
        questionCount = 0 ;
    }

    static void Karistir<T>(List<T> liste)
    {
        System.Random rng = new System.Random();
        int n = liste.Count;

        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T temp = liste[k];
            liste[k] = liste[n];
            liste[n] = temp;
        }
    }
}
