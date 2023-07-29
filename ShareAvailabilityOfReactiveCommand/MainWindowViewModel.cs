using Reactive.Bindings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShareAvailabilityOfReactiveCommand
{
    public class MainWindowViewModel
    {
        public ReadOnlyReactivePropertySlim<bool> CanMouseDown { get; }

        public ReactiveCommand<bool> ChangeModeCommand { get; }

        public ReactiveCommandSlim<MouseEventArgs> MouseMoveCommand { get; }

        public ReactiveCommandSlim<MouseEventArgs> MouseDownCommand { get; }

        public MainWindowViewModel()
        {
            ChangeModeCommand = new ReactiveCommand<bool>();
            CanMouseDown = ChangeModeCommand.ToReadOnlyReactivePropertySlim();
            CanMouseDown.Subscribe(x => Console.WriteLine($"Click {(x ? "Enabled" : "Disabled")}."));
            MouseMoveCommand = new ReactiveCommandSlim<MouseEventArgs>().WithSubscribe(_ => Console.WriteLine("Moved."));
            MouseDownCommand = CanMouseDown.ToReactiveCommandSlim<MouseEventArgs>().WithSubscribe(_ => Console.WriteLine("Clicked."));
        }
    }
}
