using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextUpdater1 : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TMP_Text ammoText;
    public int ammoCountPlayer1;
    void Start()
    {
        ammoText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCountPlayer1 = Pistol.currentAmmoPlayer1;
        ammoText.text = "Pistol: " + ammoCountPlayer1.ToString();
    }
}
