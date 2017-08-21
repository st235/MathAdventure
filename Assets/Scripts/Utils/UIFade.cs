using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIFade: MonoBehaviour
{

    [Header("Fade Attributes")]
    [SerializeField] private Image _image;
    [SerializeField] private AnimationCurve _animationCurve;

	public void Start ()
	{
	    StartCoroutine(FadeIn());
	}

    public void FadeTo(string sceneName)
    {
        StartCoroutine(FadeOut(sceneName));
    }

    private IEnumerator FadeIn()
    {
        float deltaTime = 0.5f;

        while (deltaTime > 0f)
        {
            deltaTime -= Time.deltaTime;
            float alfa = _animationCurve.Evaluate(deltaTime);
            _image.color = new Color(0f, 0f, 0f, alfa);
            yield return 0;
        }
    }

    private IEnumerator FadeOut(string sceneName)
    {
        float deltaTime = 0f;

        while (deltaTime < 0.5f)
        {
            deltaTime += Time.deltaTime;
            float alfa = _animationCurve.Evaluate(deltaTime);
            _image.color = new Color(0f, 0f, 0f, alfa);
            yield return 0;
        }

        SceneManager.LoadScene(sceneName);
    }
}
