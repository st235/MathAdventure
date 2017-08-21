using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float _baseTime;
    [SerializeField] private float _deltaTime;

    [SerializeField] private Image _progressBar;
	[SerializeField] private float _targetTime = 60.0f;

    private void Awake()
    {
        _baseTime = _targetTime;
        if (_progressBar == null) _progressBar = GetComponent<Image>();

        Messenger.AddListener(GameEvents.OnNextSequence, OnNextSequence);
    }

    public void Update()
	{

		_targetTime -= Time.deltaTime;
        OnTimerChanged(_targetTime);

		if (_targetTime <= 0.0f)
		{
            TimerEnded();
		}

	}

    void OnNextSequence()
    {
        _targetTime += _deltaTime;
        _baseTime += _deltaTime;
        OnTimerChanged(_targetTime);
    }

    void OnTimerChanged(float time) {
        float factor = time / _baseTime;
        _progressBar.fillAmount = factor;
    }

	void TimerEnded()
	{
        Messenger.Broadcast(GameEvents.OnGameEnded);
	}

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvents.OnNextSequence, OnNextSequence);
    }
}
