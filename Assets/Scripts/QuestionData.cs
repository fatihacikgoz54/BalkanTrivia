using UnityEngine;

[CreateAssetMenu(fileName = "NewQuestion", menuName = "Quiz/Question")]
public class QuestionData : ScriptableObject
{
    [TextArea]
    public string questionText;

    public string optionA;
    public string optionB;
    public string optionC;
    public string optionD;

    public AnswerOption correctAnswer;
}

public enum AnswerOption
{
    A = 0,
    B = 1,
    C = 2,
    D = 3
}   