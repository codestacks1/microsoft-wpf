using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace xiaowen.codestacks.uielements
{
    /// <summary>
    /// anhor:zhangxiaowen
    /// date:20170607
    /// from:xiaowen.codestacks.wpf
    /// used:command property to TextBlock
    /// </summary>
    public class TextBlockWithCommand : TextBlock, ICommandSource
    {
        public TextBlockWithCommand() : base() { }
        private static EventHandler _canExecuteClickHander;

        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(
            name: "Command",
            propertyType: typeof(ICommand),
            ownerType: typeof(TextBlockWithCommand),
            typeMetadata: new PropertyMetadata(defaultValue: (ICommand)null, propertyChangedCallback: new PropertyChangedCallback(CommandChanged))
            );

        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(
            name: "CommandParameter",
            propertyType: typeof(object),
            ownerType: typeof(TextBlockWithCommand),
            typeMetadata: new PropertyMetadata((object)null)
            );

        public static readonly DependencyProperty CommandTargetProperty = DependencyProperty.Register(
            name: "CommandTarget",
            propertyType: typeof(IInputElement),
            ownerType: typeof(TextBlockWithCommand),
            typeMetadata: new PropertyMetadata((IInputElement)null)
            );

        private static void CommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBlockWithCommand textBlock = (TextBlockWithCommand)d;
            textBlock.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        private void HookUpCommand(ICommand oldValue, ICommand newValue)
        {
            if (oldValue != null)
            {
                EventHandler handler = CanExecuteChanged;
                oldValue.CanExecuteChanged -= handler;
            }
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (this.Command != null)
            {
                RoutedCommand command = this.Command as RoutedCommand;
                if (command != null)
                {
                    if (command.CanExecute(this.CommandParameter, this.CommandTarget))
                        this.IsEnabled = true;
                    else
                        this.IsEnabled = false;
                }
            }
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        private void AddCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = new EventHandler(CanExecuteChanged);
            _canExecuteClickHander = handler;
            if (newCommand != null)
                newCommand.CanExecuteChanged += _canExecuteClickHander;
        }

        private void RemoveCommand(ICommand oldCommand, ICommand newCommand)
        {
            EventHandler handler = CanExecuteChanged;
            oldCommand.CanExecuteChanged -= handler;
        }
    }
}
