using ParkingRegistry.Infrastructure.WPF.Exceptions;
using System.Diagnostics;
using System.Text;

namespace ParkingRegistry.Infrastructure.WPF.Listeners
{
    public class BindingErrorListener : TraceListener
    {
        private StringBuilder buffer = new StringBuilder();
        public static void Attach()
        {
            PresentationTraceSources.DataBindingSource.Listeners.Add(new BindingErrorListener());
        }
        public override void Write(string message) {
            buffer.Append(message);
        }
        [DebuggerStepThrough]
        public override void WriteLine(string message)
        {
            buffer.Append(message);
            var msg = buffer.ToString();
            buffer.Clear();
            throw new BindingException(msg);
        }
    }
}
