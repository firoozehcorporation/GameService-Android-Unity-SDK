using UnityEngine;

namespace FiroozehGameServiceAndroid.Helpers
{
    public class NotInstallDialog
    {
        public static void ShowInstallDialog(string GameName)
        {
            DialogUtil dialog = DialogUtil.Instance();
            dialog
                .Title("گیم سرویس")
                .Message("بازی "+GameName+" از گیم سرویس استفاده می کند،برای دریافت کلیک کنید")
                .OnAccept("دریافت", () => { // define what happens when user clicks Yes:
                    Application.OpenURL("https://gameservice.liara.run");
                dialog.Hide();
            });
            dialog.Show();
        }
    }
}