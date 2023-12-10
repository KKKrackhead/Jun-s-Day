using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScreen : MonoBehaviour
{
    [SerializeField] private Image fadeImage;
    public bool isPrologue;

    private void Awake()
    {
        fadeImage = GameObject.Find("TransitionScreen").GetComponent<Image>();
        if (!isPrologue) BtC();
    }

    public void BtC()
    {
        StartCoroutine(BlackToClear());
    }

    public void CtB()
    {
        StartCoroutine(ClearToBlack());
    }

    private IEnumerator BlackToClear()
    {
        float elapsed = 0f;
        float duration = 2f;

        while (elapsed < duration)
        {
            float temp = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.black, Color.clear, temp);

            elapsed += Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSecondsRealtime(1.5f);
    }

    private IEnumerator ClearToBlack()
    {
        float elapsed = 0f;
        float duration = 2f;

        while (elapsed < duration)
        {
            float temp = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.black, temp);

            elapsed += Time.deltaTime;

            yield return null;
        }
        yield return new WaitForSecondsRealtime(1.5f);
    }
}