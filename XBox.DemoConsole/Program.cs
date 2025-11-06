namespace XBox.DemoConsole
{
    public class Program
    {
        private static string lastState = "";
        static void Main(string[] args)
        {
            // Set up the controller watcher to monitor connection events
            XBoxControllerWatcher xbcw = new XBoxControllerWatcher();
            xbcw.ControllerConnected += OnControllerConnected;
            xbcw.ControllerDisconnected += OnControllerDisconnected;

            // Give some time for initial connections to be detected
            Thread.Sleep(1000);

            // Main loop to read controller states, exit on key press
            Console.WriteLine("Press any key to exit.");
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(200);
                foreach (var c in XBoxController.GetConnectedControllers())
                {
                    var state = "Controller " + c.PlayerIndex.ToString() +
                        ": Thumb Left (x=" + c.ThumbLeftX.ToString("N0").PadRight(3) + " y=" + c.ThumbLeftY.ToString("N0").PadRight(3) + ")" +
                        " | Thumb Right (x=" + c.ThumbRightX.ToString("N0").PadRight(3) + "y=" + c.ThumbRightY.ToString("N0").PadRight(3) + ")" +
                        " | X = " + c.ButtonXPressed.ToString().PadRight(5) +
                        " | A = " + c.ButtonAPressed.ToString().PadRight(5) +
                        " | Y = " + c.ButtonYPressed.ToString().PadRight(5) +
                        " | B = " + c.ButtonBPressed.ToString().PadRight(5);

                    if (state != lastState)
                    {
                        lastState = state;
                        Console.WriteLine(state);
                    }
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