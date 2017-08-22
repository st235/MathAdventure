using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoardController : MonoBehaviour
{
    [SerializeField] private Text _sequenceKepeer;
    [SerializeField] private AudioSource _audioSource;

    private Sequence _sequence;
    private OperationsConfig _operationsConfig;
    private SequenceGenerator _sequenceGenerator;

	private void Awake()
	{
        _operationsConfig = ScriptableObject.CreateInstance<OperationsConfig>();
        _sequenceGenerator = new SequenceGenerator(_operationsConfig.GetOperations());
        Messenger.AddListener(GameEvents.OnNextSequence, OnNextSequence);
	}

    void Start()
    {
        _sequence = _sequenceGenerator.Generate();
        SetSequence(_sequence);
    }

    void OnNextSequence() {
		_sequence = _sequenceGenerator.Generate();
		SetSequence(_sequence);
    }

    public void OnApplyClick() {
        if (CheckSequence(true)) OnSuccess();
        else OnMistake();
    }

    public void OnDeclineClick() {
        if (CheckSequence(false)) OnSuccess();
        else OnMistake();
    }

    private void OnSuccess() {
        _audioSource.Play();
        Messenger.Broadcast(GameEvents.OnNextSequence);
    }

    private void OnMistake() {
        Messenger.Broadcast(GameEvents.OnGameEnded);
    }

    private bool CheckSequence(bool isApply) {
        bool isSequenceRight = _sequence.Fair;
        return isApply == isSequenceRight;
    }

    private void SetSequence(Sequence sequence) {
		_sequenceKepeer.text = sequence.ToString();
    }

    private void OnDestroy()
    {
        Messenger.RemoveListener(GameEvents.OnNextSequence, OnNextSequence);
    }
}
