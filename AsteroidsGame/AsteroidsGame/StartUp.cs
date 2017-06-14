﻿using System;
using System.Windows.Forms;

namespace AsteroidsGame
{
    internal static class StartUp
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AsteroidsForm());
        }
    }
}