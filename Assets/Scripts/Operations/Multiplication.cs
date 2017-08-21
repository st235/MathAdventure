using UnityEngine;
using System.Collections;

public class Multiplication : Operation
{
	private readonly char _sign = '×';

	public char GetSign()
	{
		return _sign;
	}

	public OperationProvider Generate()
	{
		int firstFactor = Random.Range(0, 20);
		int secondFactor = Random.Range(0, 10);
        int solution = firstFactor * secondFactor;
		return new OperationProvider(firstFactor, secondFactor,
									 solution, _sign);
	}
}
