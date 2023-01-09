using static UserConstants.Constants;
using UnityEngine;

namespace UI
{
    public class NameInputField : MonoBehaviour
    {
        public void ReadStringAsName(string value)
        {
            PlayerPrefs.SetString(PlayerName, value); 
            Debug.Log("PlayerPrefs Name set to " + PlayerPrefs.GetString(PlayerName));
        }
    }
}
