using Windows.UI.Xaml;

namespace NumberBoxDemo
{   
    public sealed partial class ConditionEditorView 
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