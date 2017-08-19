using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameBoardController : MonoBehaviour
{
    [SerializeField] private Text _sequenceKepeer;

    private OperationsConfig _operationsConfig;
    private SequenceGenerator _sequenceGenerator;

	private void Awake()
	{
        _operationsConfig = ScriptableObject.CreateInstance<OperationsConfig>();
        _sequenceGenerator = new SequenceGenerator(_operationsConfig.GetOperations());
	}

    void Start()
    {
        Sequence sequence = _sequenceGenerator.Generate();
        _sequenceKepeer.text = sequence.ToString();
        Debug.Log(sequence);
    }

    void Update()
	{
			
	}
}
