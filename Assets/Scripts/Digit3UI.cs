using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Digit3UI : MonoBehaviour
{
    [SerializeField]
    private Texture[] digitSamples = null;

    [SerializeField]
    private int number = 0;
    public int Number {
        get { return number; }
        set { number = value; }
    }

    private RawImage[] digitImages = null;

    void Start()
    {
        digitImages = gameObject.GetComponentsInChildren<RawImage>();
    }

    void Update()
    {
        int[] digits = getDigits();
        for(int i = 0; i < 3; ++i)
        {
            digitImages[i].texture = digitSamples[digits[i]];
        }

        digitImages[0].gameObject.SetActive(true);
        digitImages[1].gameObject.SetActive(true);
        if (Number < 100)
        {
            digitImages[0].gameObject.SetActive(false);
        }
        if(Number < 10)
        {
            digitImages[1].gameObject.SetActive(false);
        }
    }

    private int[] getDigits()
    {
        int currentNumber = Number;
        int[] digits = new int[3];
        for(int i = 2; i >= 0; --i)
        {
            digits[i] = currentNumber % 10;
            currentNumber /= 10;
        }
        return digits;
    }
}
