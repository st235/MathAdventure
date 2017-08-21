using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private int _score = 0;
    private int _savedScore = 0;
    [SerializeField] private Text _scoreText;

	private void Awake()
	{
        _scoreText.text = _score.ToString();
        _savedScore = PlayerPrefs.GetInt(GameEvents.ScorePrefs);
		Messenger.AddListener(GameEvents.OnNextSequence, OnNextSequence);
	}

	void OnNextSequence()
	{
        _score += 1;
        _scoreText.text = _score.ToString();

        if (_score > _savedScore) {
            PlayerPrefs.SetInt(GameEvents.ScorePrefs, _score);
            _savedScore = _score;
        }
	}

	private void OnDestroy()
	{
		Messenger.RemoveListener(GameEvents.OnNextSequence, OnNextSequence);
	}
}
