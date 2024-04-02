using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;

    public AnimationCurve curve;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    //Fade in
    private IEnumerator FadeIn()
    {
        float t = 1f;
        
        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0.03921569f, 0.5137255f, 0.5960785f, a);
            yield return 0;
        }
    }

    //Fade out
    private IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 1f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0.03921569f, 0.5137255f, 0.5960785f, a);
            yield return 0;
        }

        SceneManager.LoadScene(scene);
    }
}
