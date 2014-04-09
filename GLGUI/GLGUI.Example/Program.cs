using System;
using System.Windows.Forms;
using System.Threading;

namespace GLGUI.Example
{
	public static class Program
	{
        [STAThread]
		public static int Main(string[] args)
		{
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new ThreadExceptionEventHandler(OnGuiUnhandedException);
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

			new MainForm().Run();
			return 0;
		}

        private static void HandleUnhandledException(Object o)
        {
            Exception e = o as Exception;

            if (e != null)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private static void OnUnhandledException(Object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(e.ExceptionObject);
        }

        private static void OnGuiUnhandedException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleUnhandledException(e.Exception);
        }
	}
}
