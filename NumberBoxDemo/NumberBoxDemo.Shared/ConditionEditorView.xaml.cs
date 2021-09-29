using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace NumberBoxDemo
{   
    public sealed partial class ConditionEditorView : UserControl
    {
        public static readonly DependencyProperty ViewModelProperty =
                  DependencyProperty.Register(nameof(ViewModel), typeof(ConditionEditor), typeof(ConditionEditorView), new PropertyMetadata(null));

        public ConditionEditor ViewModel
        {
            get => (ConditionEditor)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        public ConditionEditorView() => this.InitializeComponent();
    }
}