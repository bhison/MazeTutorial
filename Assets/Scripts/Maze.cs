using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

	public MazeCell cellPrefab;
	public float generationStepDelay;
	public IntVector2 size;

	private MazeCell[,] cells;

	public MazeCell GetCell(IntVector2 coordinate)
	{
		return cells [coordinate.x, coordinate.z];
	}

	public IEnumerator Generate()
	{
		WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
		cells = new MazeCell[size.x, size.z];
		IntVector2 coordinates = RandomCoordinates;
		while (ContainsCoordinates (coordinates) && GetCell(coordinates) == null) 
		{
			yield return delay;
			CreateCell (coordinates);
			coordinates += MazeDirections.RandomValue.ToIntVector2 ();
		}
	}

	void CreateCell(IntVector2 coordinates)
	{
		MazeCell newCell = Instantiate (cellPrefab) as MazeCell;
		cells [coordinates.x, coordinates.z] = newCell;
		newCell.coordinates = coordinates;
		newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
		newCell.transform.parent = transform;
		newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
	}

	public IntVector2 RandomCoordinates {
		get {
			return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
		}
	}

	public bool ContainsCoordinates(IntVector2 coordinate)
	{
		return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
	}
}
