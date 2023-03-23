using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityPopup
{
    public class ProgressIndicatorVM : BindableBase
    {
        public bool HasTitle => string.IsNullOrWhiteSpace(Title) == false;

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (SetProperty(ref _title, value))
                {
                    OnPropertyChanged(nameof(HasTitle));
                }
            }
        }

        private double _progress = 0;
        public double Progress
        {
            get => _progress;
            set => SetProperty(ref _progress, value);

        }

        private Color _progressColor;
        public Color ProgressColor
        {
            get => _progressColor;
            set => SetProperty(ref _progressColor, value);

        }

        private Size _size = new Size(300, 120);
        public Size Size
        {
            get => _size;
            set => SetProperty(ref _size, value);

        }
    }
}
