using UnityEngine;
using TMPro;

public class UI_PlayerNicknameDisplay : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI nicknameText;
	[SerializeField] private string defaultNickname;
	[SerializeField] private TMP_InputField inputField;

	public void UpdateNickname()
	{
		if (inputField.text == "")
		{
			nicknameText.text = defaultNickname;
		}
		else
		{
			nicknameText.text = inputField.text;
		}
	}
}
