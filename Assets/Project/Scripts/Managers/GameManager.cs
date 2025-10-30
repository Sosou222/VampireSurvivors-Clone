using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        ExpierienceSystem.Instance.LeveledUp += OnLevelUp;
    }

    private void OnLevelUp(int level)
    {
        List<UpgradeCardInfo> upgradeInfo = CreateUpgradeCardInfoList();
        upgradeInfo.Shuffle();
        int maxUpgradeCards = 3;
        List<UpgradeCardInfo> upgradeInfoSent = new();
        for(int i=0;i < upgradeInfo.Count && i< maxUpgradeCards; i++)
        {
            upgradeInfoSent.Add(upgradeInfo[i]);
        }

        UIManager.Instance.ShowUpgrades(upgradeInfoSent);

    }

    private List<UpgradeCardInfo> CreateUpgradeCardInfoList()
    {
        List<UpgradeCardInfo> upgradeInfo = new();
        if (PlayerInfoSystem.Instance.TryGetPlayer(out Player player))
        {

            List<WeaponData> weaponsData = WeaponDataHolder.Instance.GetWeaponList();
            List<WeaponData> currentWeapons = player.WeaponHolder.GetWeaponData();

            foreach (WeaponData wp in weaponsData)
            {
                if (currentWeapons.Contains(wp))
                {
                    continue;
                }

                UpgradeCardInfo upgradeCardInfo = new UpgradeCardInfo()
                {
                    TitleText = "Get " + wp.WeaponName,
                    DescriptionText = wp.WeaponAddText,
                    OnClickAction = () =>
                    {
                        player.WeaponHolder.Add(wp);
                    }
                };
                upgradeInfo.Add(upgradeCardInfo);
            }

            foreach (WeaponData wp in currentWeapons)
            {
                int wpLevel = player.WeaponHolder.GetWeaponLevel(wp);
                if (wpLevel == -1 || wpLevel >= wp.MaxLevel)
                {
                    continue;
                }

                UpgradeCardInfo upgradeCardInfo = new UpgradeCardInfo()
                {
                    TitleText = wp.WeaponName + (wpLevel + 1).ToString(),
                    DescriptionText = wp.WeaponLevelUpText,
                    OnClickAction = () =>
                    {
                        player.WeaponHolder.LevelUpWeapon(wp);
                    }
                };
                upgradeInfo.Add(upgradeCardInfo);
            }


        }
        return upgradeInfo;
    }
}
