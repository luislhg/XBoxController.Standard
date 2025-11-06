namespace XBox.DemoConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Set up the controller watcher to monitor connection events
            XBoxControllerWatcher xbcw = new XBoxControllerWatcher();
            xbcw.ControllerConnected += OnControllerConnected;
            xbcw.ControllerDisconnected += OnControllerDisconnected;

            // Main loop to read controller states, exit on key press
            Console.WriteLine("Press any key to exit.");
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                foreach (var c in XBoxController.GetConnectedControllers())
                {
                    Console.WriteLine("Controller " + c.PlayerIndex.ToString() + " Thumb Left X = " + c.ThumbLeftX.ToString() + ", Y = " + c.ThumbLeftY.ToString() + ", A = " + c.ButtonAPressed.ToString());
                }
            }
        }

        private static void OnControllerConnected(XBoxController controller)
        {
            Console.WriteLine("Controller Connected: Player " + controller.PlayerIndex.ToString());
        }

        private static void OnControllerDisconnected(XBoxController controller)
        {
            Console.WriteLine("Controller Disconnected: Player " + controller.PlayerIndex.ToString());
        }
    }
}