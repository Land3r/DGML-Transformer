﻿using DgmlLib;
using DGMLTransformer.Domain;
using DGMLTransformer.Presentation.Events;
using DGMLTransformer.Presentation.UserControls;
using DGMLTransformer.Services.Dgml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGMLTransformer.Presentation
{
    /// <summary>
    /// MainWindow class.
    /// Main window of the application.
    /// </summary>
    public partial class MainWindow : Form
    {
        /// <summary>
        /// The <see cref="DgmlService"/> service.
        /// </summary>
        private IDgmlService dgmlService;

        /// <summary>
        /// The <see cref="DgmlDoc"/> instance the window is working on.
        /// </summary>
        private DgmlDoc dgmlDoc = null;
        /// <summary>
        /// Gets the <see cref="DgmlDoc"/> of the window.
        /// </summary>
        public DgmlDoc DgmlDoc
        {
            get { return dgmlDoc; }
        }

        /// <summary>
        /// The <see cref="DgmlSelector"/> user control.
        /// </summary>
        private DgmlSelector dgmlSelector { get; set; }

        /// <summary>
        /// The <see cref="DgmlFilters"/> user control.
        /// </summary>
        private DgmlFilters dgmlFilters { get; set; }

        /// <summary>
        /// The <see cref="DgmlGenerator"/> user control.
        /// </summary>
        private DgmlGenerator dgmlGenerator { get; set; }

        /// <summary>
        /// Event handler for when the dgml doc is loaded.
        /// </summary>
        public event EventHandler<DgmlDocEventArgs> DgmlDocHandler;

        /// <summary>
        /// Initalizes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="dgmlService">Instance of the <see cref="DgmlService"/> service, injected by Unity.</param>
        public MainWindow(IDgmlService dgmlService)
        {
            InitializeComponent();

            this.dgmlService = dgmlService;

            this.dgmlSelector = new DgmlSelector();
            this.dgmlSelector.Dock = DockStyle.Fill;
            this.dgmlSelector.DgmlFileHandler += new EventHandler<DgmlFileEventArgs>(this.OnDgmlFileSelected);

            this.dgmlFilters = new DgmlFilters();
            this.dgmlFilters.Dock = DockStyle.Fill;
            this.DgmlDocHandler += new EventHandler<DgmlDocEventArgs>(this.dgmlFilters.OnDgmlDocLoaded);

            this.dgmlGenerator = new DgmlGenerator();
            this.dgmlGenerator.Dock = DockStyle.Fill;
            this.dgmlGenerator.SaveFileventHandler += new EventHandler<EventArgs>(this.OnDgmlGeneratorSave);
            this.dgmlGenerator.ViewFileEventHandler += new EventHandler<EventArgs>(this.OnDgmlGeneratorView);
        }

        /// <summary>
        /// Event receiver for the OnLoad event.
        /// </summary>
        /// <param name="e">The event payload.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.DgmlSelectorPanel.Controls.Add(this.dgmlSelector);
            this.DgmlFiltersPanel.Controls.Add(this.dgmlFilters);
            this.DgmlGeneratorPanel.Controls.Add(this.dgmlGenerator);
        }

        /// <summary>
        /// Event receiver for the <see cref="DgmlFileEventArgs"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event payload.</param>
        private void OnDgmlFileSelected(object sender, DgmlFileEventArgs e)
        {
            if (e.Type == DgmlFileEventEnum.Selected)
            {
                this.dgmlDoc = dgmlService.GetFromFile(e.Payload.FilePath);
                this.DgmlDocHandler?.Invoke(this, new DgmlDocEventArgs(DgmlDocEventEnum.Loaded, dgmlDoc));
            }
        }

        /// <summary>
        /// Event receiver for the <see cref="EventArgs"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event payload.</param>
        private void OnDgmlGeneratorSave(object sender, EventArgs e)
        {
            if (this.dgmlDoc != null)
            {
                dgmlService.HideAllCategories(this.dgmlDoc);
                dgmlService.ShowCategories(this.dgmlDoc, this.dgmlFilters.DgmlCategories);
                dgmlService.SaveFile(this.dgmlDoc, true);
            }
        }

        /// <summary>
        /// Event receiver for the <see cref="EventArgs"/> event.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event payload.</param>
        private void OnDgmlGeneratorView(object sender, EventArgs e)
        {
            if (this.dgmlDoc != null)
            {
                Process.Start(this.dgmlDoc.LoadedFilePath);
            }
        }
    }
}
