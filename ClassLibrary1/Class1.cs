using Rocket.Core.Plugins;
using Rocket.Unturned.Events;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1 : RocketPlugin
    {
        protected override void Load()
        {
            base.Load();
            PlayerEquipment.OnUseableChanged_Global += (equipment) => onUsebleChanged(equipment);
            ChangeFiremode.OnFiremodeChanged += onFiremodeChanged;
            UseableGun.onChangeMagazineRequested += changeMagazine;

        }

        private void changeMagazine(PlayerEquipment equipment, UseableGun gun, Item oldItem, ItemJar newItem, ref bool shouldAllow)
        {
            var player = UnturnedPlayer.FromPlayer(equipment.player);

            if (player == null) return;
            if (newItem != null)
            {
                var maxAmmo = new Item(newItem.item.id, true).amount;
                var newitem = newItem.item.amount;;
            }
            else
            {
                //0
                //0
            }
        }

        private void onFiremodeChanged(Player player, EFiremode firemode)
        {
            var players = UnturnedPlayer.FromPlayer(player);
            var Değer = getFiremode(firemode); //mod
        }

        private void onUsebleChanged(PlayerEquipment equipment)
        {
            var player = UnturnedPlayer.FromPlayer(equipment.player);
            if (equipment.asset != null && equipment.asset.type == EItemType.GUN)
            {
                ushort Mermis = BitConverter.ToUInt16(new byte[] { equipment.state[8], equipment.state[9] }, 0);
                if (Mermis != 0)
                {
                    var maxAmmo = new Item(Mermis, true).amount;
                    var Mermi = equipment.state[10];
                    var BütünMermi = maxAmmo;
                    var SilahDurum = getFiremode(equipment.state[11]);
                }
                else
                {
                  //Mermi 0 ise
                }
            }
            else
            {
                //Silah Yok
            }
        }


        private static string getFiremode(EFiremode firemode)
        {
            switch (firemode)
            {
                case EFiremode.SAFETY:
                    return "SAFE";
                case EFiremode.SEMI:
                    return "SEMI";
                case EFiremode.AUTO:
                    return "AUTO";
                case EFiremode.BURST:
                    return "BURST";
            }

            return "NEVIEM";
        }

        private static string getFiremode(byte firemode)
        {
            switch (firemode)
            {
                case 0:
                    return "SAFE";
                case 1:
                    return "SEMI";
                case 2:
                    return "AUTO";
                case 3:
                    return "BURST";
            }

            return "NEVIEM";
        }
    }
}
