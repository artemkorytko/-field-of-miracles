using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Letter : MonoBehaviour
{
    Transform bg;
    Transform front;
    TextMeshProUGUI text;

    private float speed = 150;
    private char letter;

    private void Awake()
    {
        bg = transform.GetChild(0);
        front = transform.GetChild(1);
        text = GetComponentInChildren<TextMeshProUGUI>();
    }
    public Letter Setup(char letter)
    {
        this.letter = letter;
        text.text = letter.ToString();
        bg.gameObject.SetActive(true);
        front.gameObject.SetActive(false);
        return this;
    }

    public void Check(char letter)
    {
        if(this.letter == letter)
        {
            Open();
        }
    }

    private void Open()
    {
        StartCoroutine(Rotate());
    }

    private IEnumerator Rotate()
    {
        while(bg.transform.rotation.eulerAngles.y < 90)
        {
            bg.transform.rotation = Quaternion.RotateTowards(bg.transform.rotation, Quaternion.Euler(new Vector3(0, 90, 0)), speed * Time.deltaTime);
            yield return null;
        }

        bg.gameObject.SetActive(false);
        front.gameObject.SetActive(true);

        front.rotation = Quaternion.Euler(new Vector3(0, -90, 0));

        while (front.transform.rotation.eulerAngles.y > 0)
        {
            front.transform.rotation = Quaternion.RotateTowards(front.transform.rotation, Quaternion.Euler(Vector3.zero), speed * Time.deltaTime);
            yield return null;
        }
    }
}
