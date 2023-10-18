
using System;

namespace consoleTest
{
    using Terminal.Gui;

    class Demo {
        static int Main ()
        {
            Application.Init ();

            var n = MessageBox.Query (50, 7,
                "Question", "Do you like console apps?", "Yes", "No");

            return n;
        }
    }
}

