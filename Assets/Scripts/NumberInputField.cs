using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Menu number type inputs
public class NumberInputField : MonoBehaviour
{
    public TMP_InputField inputField;

    public int minValue;
    public int maxValue;
    public int defaultValue;

    // Start is called before the first frame update
    void Start()
    {
        // Input on value changed event
        inputField.onValueChanged.AddListener(delegate { ValueChanged(); });

        // Default value at start
        inputField.text = defaultValue.ToString();
    }

    // On input value changed
    private void ValueChanged()
	{
        int intValue;

        // Tries to parse the input string value to an integer
        if (int.TryParse(inputField.text, out intValue))
		{
            // Min limit
            if (intValue < minValue)
            {
                inputField.text = minValue.ToString();
            }
            // Max limit
            else if (intValue > maxValue)
            {
                inputField.text = maxValue.ToString();
            }
        }
	}
}
