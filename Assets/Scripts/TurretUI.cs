using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurretUI : MonoBehaviour {

	public GameObject ui;

	private TowerPlatforms target;

    public TextMeshProUGUI upgradePriceText;
    public TextMeshProUGUI sellPriceText;

    public Button upgradeButton;
    public Button sellButton;

	public void SetTarget (TowerPlatforms _target)
	{
		target = _target;

		transform.position = target.GetBuildPosition();

        		if (!target.isUpgraded)
		{
			upgradePriceText.text = "Upgrade price:\n" + target.turretsManager.upgradePrice;
			upgradeButton.interactable = true;
		} else
		{
			upgradePriceText.text = "DONE";
			upgradeButton.interactable = false;
		}

        sellPriceText.text = "Sell price:\n" + target.turretsManager.GetSellPrice();

		ui.SetActive(true);
	}

	public void Hide ()
	{
		ui.SetActive(false);
	}

    public void Upgrade ()
	{        
		target.UpgradeTurret();
		Building.instance.DeselectNode();
	}

    public void Sell ()
	{
		target.SellTurret();
		Building.instance.DeselectNode();
	}

}
