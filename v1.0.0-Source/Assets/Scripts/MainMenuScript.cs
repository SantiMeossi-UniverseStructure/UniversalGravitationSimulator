using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;


public class MainMenuScript : MonoBehaviour
{
    public TMP_InputField Gbutton;
    public TMP_InputField mass1;
    public TMP_InputField mass2;
    public TMP_InputField separation;
    public TMP_InputField initialSpeed;
    public Button start;
    public Toggle activeCollider;
    private float G = UniversalVariables.G;
    private float textG;
    private float textMass1;
    private float textMass2;
    private float textSeparation;
    private float textSpeed;

    private void Start()
    {
        Gbutton.text = G.ToString();
        mass1.text = UniversalVariables.mass1.ToString(CultureInfo.InvariantCulture);
        mass2.text = UniversalVariables.mass2.ToString(CultureInfo.InvariantCulture);
        separation.text = UniversalVariables.separation.ToString(CultureInfo.InvariantCulture);
        initialSpeed.text = UniversalVariables.intialSpeed.ToString(CultureInfo.InvariantCulture);
        activeCollider.isOn = UniversalVariables.collider;
    }

    public void startSimulation()
    {
        if (float.TryParse(Gbutton.text, NumberStyles.Any, CultureInfo.InvariantCulture, out textG))
        {
            UniversalVariables.G = textG;
        }
        else
        {
            UniversalVariables.G = 1f;
        }

        if (float.TryParse(mass1.text, NumberStyles.Any, CultureInfo.InvariantCulture, out textMass1))
        {
            UniversalVariables.mass1 = Mathf.Abs(textMass1);
        }
        else
        {
            UniversalVariables.mass1 = 1f;
        }

        if (float.TryParse(mass2.text, NumberStyles.Any, CultureInfo.InvariantCulture, out textMass2))
        {
            UniversalVariables.mass2 = Mathf.Abs(textMass2);
        }
        else
        {
            UniversalVariables.mass2 = 0.5f;
        }

        if (float.TryParse(separation.text, NumberStyles.Any, CultureInfo.InvariantCulture, out textSeparation))
        {
            UniversalVariables.separation = textSeparation;
        }
        else
        {
            UniversalVariables.separation = 50f;
        }

        if (float.TryParse(initialSpeed.text, NumberStyles.Any, CultureInfo.InvariantCulture, out textSpeed))
        {
            UniversalVariables.intialSpeed = textSpeed;
        }
        else
        {
            UniversalVariables.intialSpeed = 0f;
        }

        SceneManager.LoadScene(1);
    }
}
