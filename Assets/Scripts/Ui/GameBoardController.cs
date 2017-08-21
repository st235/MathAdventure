using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoardController : MonoBehaviour
{
    [SerializeField] private Text _sequenceKepeer;

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
        if (CheckSequence(true)) Messenger.Broadcast(GameEvents.OnNextSequence);
        else Messenger.Broadcast(GameEvents.OnGameEnded);
    }

    public void OnDeclineClick() {
        if (CheckSequence(false)) Messenger.Broadcast(GameEvents.OnNextSequence);
		else Messenger.Broadcast(GameEvents.OnGameEnded);
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
