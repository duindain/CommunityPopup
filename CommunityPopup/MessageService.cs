using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityPopup
{
    public static class MessageService
    {
        private static ProgressPopup _progressIndicatorPopup;

        public static void ShowProgressIndicator(string message = null, double progress = 0)
        {
            HideProgressIndicator();
            _progressIndicatorPopup ??= new ProgressPopup();

            SetProgressIndicator(message, progress);

            NavigateToPopup(_progressIndicatorPopup);
        }

        public static void SetProgressIndicator(string message = null, double progress = 0)
        {
            if (_progressIndicatorPopup != null)
            {
                _progressIndicatorPopup.VM.Title = message;
                SetProgressIndicator(progress);
            }
        }

        public static void SetProgressIndicator(double progress = 0)
        {
            if (_progressIndicatorPopup != null)
            {
                _progressIndicatorPopup.VM.Progress = ClampProgress(progress);
            }
        }

        public static void HideProgressIndicator()
        {
            if (_progressIndicatorPopup != null)
            {
                try
                {
                    _progressIndicatorPopup.Close();
                }
                catch (NullReferenceException ex)
                {
                    Logger.WriteLine("MessageService.HideProgressIndicator: NullReferenceException trying to close popup from Maui framework");
                    //Logger.WriteException(ex, false);
                }
                _progressIndicatorPopup = null;
            }
        }

        public static Popup NavigateToPopup(Popup popupInstance)
        {
            var className = TypeDescriptor.GetClassName(popupInstance);
            Logger.WriteLine($"NavigationService.NavigateToPopup: Popup with Page {className}");
            PushPopupSafely(popupInstance);
            return popupInstance;
        }

        private static void PushPopupSafely(Popup popup)
        {
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                try
                {
                    await Application.Current.MainPage.ShowPopupAsync(popup);
                }
                catch (Exception ex)
                {
                    Logger.WriteLine($"NavigationService.PushPopupSafely failed to open: Popup {TypeDescriptor.GetClassName(popup)}, Message:{ex.Message}");
                }
            });
        }

        private static double ClampProgress(double progress)
        {
            if (progress < 0)
            {
                progress = 0;
            }
            if (progress > 100)
            {
                progress = 100;
            }
            if (progress > 1)
            {
                progress = progress / 100;
            }
            return progress;
        }
    }
}
