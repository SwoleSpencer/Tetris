using UnityEngine;
using UnityEngine.UI;

public class UI_NextShape : MonoBehaviour
{
	[SerializeField] private Image _nextShapeImage;
	[SerializeField] private int _boardID;
	[SerializeField] private Sprite[] _shapeSprites;

	private void OnEnable()
	{
		ShapeSelectorEventManager.OnShapeSelected += ShapeSelectorEventManager_OnShapeSelected;
	}

	private void OnDisable()
	{
		ShapeSelectorEventManager.OnShapeSelected -= ShapeSelectorEventManager_OnShapeSelected;
	}

	private void ShapeSelectorEventManager_OnShapeSelected(int boardID, int shapeID)
	{
		if (_boardID == boardID)
		{
			_nextShapeImage.sprite = _shapeSprites[shapeID];
		}
	}
}
