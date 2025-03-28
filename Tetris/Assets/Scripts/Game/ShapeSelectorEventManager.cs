using UnityEngine;
using System;

public class ShapeSelectorEventManager : MonoBehaviour
{
    public static ShapeSelectorEventManager instance;

    public static Action<int, int> OnShapeSelected;

    private void Awake()
    {
        instance = this;
    }

    public void InvokeOnShapeSelectedAction(int boardID, int shapeID)
    {
		OnShapeSelected?.Invoke(boardID, shapeID);
	}
}
