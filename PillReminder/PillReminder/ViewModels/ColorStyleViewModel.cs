using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using PillReminder.Models;
using Xamarin.Essentials;

namespace PillReminder.ViewModels
{
    public class ColorSettingsObj : RestAnswer
    {
        public string bkgcolor { get; set; }
        public string barcolor { get; set; }
        public string apptitle { get; set; }

    }

    class ColorStyleViewModel : BaseViewModel
    {
        public Command LoadColorsCommand { get; set; }
        public Command SendMobileDataCommand { get; set; }
        private ColorSettingsObj colorSetting;
        public ColorSettingsObj ColorSet
        {
            get { return colorSetting; }
            set { SetProperty(ref colorSetting, value); }
        }
        public ColorStyleViewModel()
        {
            ColorSet = new ColorSettingsObj();
            SendMobileDataCommand = new Command(async () => await ExecuteSendDataCommand());
        }

        async Task ExecuteSendDataCommand()
        {
            int i = 1;
            try
            {
                var queryparams = new Dictionary<string, string>()
                {
                    { "cmd", "login"},
                    { "ver", Uri.EscapeDataString(DeviceInfo.Model.ToString())},
                    { "os", Uri.EscapeDataString(DeviceInfo.Platform.ToString() +" / "+ DeviceInfo.Name)},
                };

                await AsyncQuery<ColorSettingsObj>("", queryparams, (RestAnswer answer) =>
                {
                    var ans = (answer as ColorSettingsObj);

                    if (ans != null)
                    {
                        ColorSet = ans;
                        MessagingCenter.Send<ColorStyleViewModel>(this, "UploadColors");
                    }
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {

            }
        }
      
    }
}
