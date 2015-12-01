// Script by Jason Miller
// psyaxismundi@gmail.com

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowOnMouseOver : MonoBehaviour
{
    private Text[] StarInfoText;
    private Text HighConceptDescriptionText;
    private Text StellarTypeDescriptionText;
    private Text SpectralClassDescriptionText;

    public Text HighConcept;
    public Text StellarTypeDescription;
    public Text SpectralClassDescription;

    private GameObject UIInfoPanels;

    void Awake()
    {

    }

    void Start()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
        StarInfoText = GameObject.FindGameObjectWithTag("SideMenu").GetComponentsInChildren<Text>();
        HighConcept = StarInfoText [0];
        HighConceptDescriptionText = HighConcept;
        StellarTypeDescription = StarInfoText [1];
        SpectralClassDescription = StarInfoText [2];
        // UIInfoPanels = GameObject.Find("UIInfoPanels");
    }

    void OnMouseEnter()
    {
        // enable UI panels
        this.gameObject.GetComponent<Canvas>().enabled = true;
        HighConcept.text = this.gameObject.transform.parent.gameObject.name;

        // resets the text box to the top of the scroll window
        // Vector3 PosYReset = new Vector3(0,-70.0f,0);
        // StellarTypeDescriptionText.transform.localPosition = PosYReset;

        // sets the text for stellar type information
        StellarTypeDescription.text = this.gameObject.transform.parent.gameObject.GetComponent<BaseStellarType>().StellarTypeDescriptionText;
        SpectralClassDescription.text = this.gameObject.transform.parent.gameObject.GetComponent<BaseSpectralClass>().SpectralClassDescriptionText;
    }

    void OnMouseExit()
    {
        this.gameObject.GetComponent<Canvas>().enabled = false;
    }

    void OnMouseUp()
    {

    }
}
