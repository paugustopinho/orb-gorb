using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using System;

public class Dialouge : MonoBehaviour
{
    [SerializeField] List<string> lines, response, answer;
    [SerializeField] GameObject button1, button2;
    [SerializeField] TextMeshProUGUI output, answer1, answer2;
    float textSpeed = 0.1f;
    bool listenforAnswer;
    int answerTo1, answerTo2;

    void Start()
    {
        firstLine();
    }

    private void Update()
    {
        if (listenforAnswer) { 
            if (Input.GetKeyDown(KeyCode.Q))
            {
                listenforAnswer = false;
                button1.SetActive(false);
                button2.SetActive(false);
                StartCoroutine(TypeLine(answerTo1, answerTo1 == 0));
            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                listenforAnswer = false;
                button1.SetActive(false);
                button2.SetActive(false);
                StartCoroutine(TypeLine(answerTo2, answerTo2 == 0));
            }
        }
    }

    void firstLine()
    {
        StartCoroutine(TypeLines());   
    }

    IEnumerator TypeLines()
    {
        foreach (char c in lines[0].ToCharArray())
        {
            output.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 2f);
        output.text = "";
        foreach (char c in lines[1].ToCharArray())
        {
            output.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 2f);
        choice(0, 1);
    }

    void choice(int choice1, int choice2)
    {
        button1.SetActive(true);
        button2.SetActive(true);
        answer1.text = response[choice1];
        answer2.text = response[choice2];
        listenforAnswer = true;
        answerTo1 = choice1;
        answerTo2 = choice2;
    }

    IEnumerator TypeLine(int index, bool doesContinue)
    {
        output.text = "";
        foreach (char c in answer[index].ToCharArray())
        {
            output.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
        yield return new WaitForSeconds(textSpeed * 2f);
        if (doesContinue)
            choice(2, 3);
    }
}
