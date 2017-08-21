using UnityEngine;
using System.Collections;

public class Division : Operation
{
	private readonly char _sign = '÷';

	public char GetSign()
	{
		return _sign;
	}

	public OperationProvider Generate()
	{
		int secondFactor = Random.Range(1, 10);
		int solution = Random.Range(1, 10);
        int firstFactor = secondFactor * solution;
		return new OperationProvider(firstFactor, secondFactor,
									 solution, _sign);
	}
}
