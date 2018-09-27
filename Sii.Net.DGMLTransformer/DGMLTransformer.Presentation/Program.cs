using DGMLTransformer.Presentation.UserControls;
using DGMLTransformer.Presentation.UserControls.Filters;
using DGMLTransformer.Services.Dgml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace DGMLTransformer.Presentation
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Unity container.
        /// </summary>
        static IUnityContainer container = new UnityContainer();

        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Configure();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<MainWindow>());
        }

        /// <summary>
        /// Unity configuration
        /// </summary>
        private static void Configure()
        {
            // Forms
            container.RegisterSingleton<MainWindow>();

            // User controls
            //container.RegisterType<DgmlSelector>();
            //container.RegisterType<DgmlGenerator>();
            //container.RegisterType<DgmlFilters>();
            //container.RegisterType<DgmlCategoryFilter>();

            // Services
            container.RegisterType<IDgmlService, DgmlService>();
        }
    }
}
