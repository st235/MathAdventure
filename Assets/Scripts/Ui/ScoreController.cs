using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private int _score = 0;
    [SerializeField] private Text _scoreText;

	private void Awake()
	{
        _scoreText.text = _score.ToString();
		Messenger.AddListener(GameEvents.OnNextSequence, OnNextSequence);
	}

	void OnNextSequence()
	{
        _score += 1;
        _scoreText.text = _score.ToString();
	}

	private void OnDestroy()
	{
		Messenger.RemoveListener(GameEvents.OnNextSequence, OnNextSequence);
	}
}
