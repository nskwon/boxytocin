using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextUpdater2 : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TMP_Text ammoText;
    public int ammoCountPlayer2;
    void Start()
    {
        ammoText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCountPlayer2 = Pistol.currentAmmoPlayer2;
        ammoText.text = "Pistol: " + ammoCountPlayer2.ToString();
    }
}
