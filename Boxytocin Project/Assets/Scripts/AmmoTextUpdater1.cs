using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoTextUpdater1 : MonoBehaviour
{
    // Start is called before the first frame update
    private TMPro.TMP_Text ammoText;
    public int ammoCountPlayer1;
    public string player1Weapon;
    void Start()
    {
        ammoText = GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoCountPlayer1 = BaseWeapon.currentAmmoPlayer1;
        player1Weapon = BaseWeapon.weaponName1;
        ammoText.text = player1Weapon + ": " + ammoCountPlayer1.ToString();
    }
}
