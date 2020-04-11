using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextUpdater2 : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TMP_Text ammoText;
    public int ammoCountPlayer2;
    public string player2Weapon;
    void Start()
    {
        ammoText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCountPlayer2 = BaseWeapon.currentAmmoPlayer2;
        player2Weapon = BaseWeapon.weaponName2;
        ammoText.text = player2Weapon + ": " + ammoCountPlayer2.ToString();
    }
}
