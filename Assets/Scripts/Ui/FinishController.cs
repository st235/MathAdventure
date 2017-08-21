using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinishController : MonoBehaviour
{
    [SerializeField] private GameObject _gameBoard;
    [SerializeField] private GameObject _finishBoard;

    private void Awake()
    {
        Messenger.AddListener(GameEvents.OnGameEnded, OnGameEnded);
    }

    private void OnGameEnded() {
        _gameBoard.SetActive(false);
        _finishBoard.SetActive(true);
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvents.OnGameEnded, OnGameEnded);
    }
}
