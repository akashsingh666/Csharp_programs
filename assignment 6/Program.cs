using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
             /*Application.Run(new Registrationfrom());
             Application.Run(new studentform());
             Application.Run(new Fees());
             Application.Run(new subjectform());
             Application.Run(new Marks());
             Application.Run(new Login());
             Application.Run(new Facultyform());*/
            Application.Run(new Login()); 
        }
    }
}
