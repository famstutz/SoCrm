// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatusBarService.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The status bar service.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Core.StatusBar
{
    using System;
    using System.Windows.Threading;

    using SoCrm.Presentation.Core;

    /// <summary>
    /// The status bar service.
    /// </summary>
    public class StatusBarService : ViewModelBase, IStatusBarService
    {
        /// <summary>
        /// The date time timer.
        /// </summary>
        private readonly DispatcherTimer dateTimeTimer;

        /// <summary>
        /// The last status timer.
        /// </summary>
        private readonly DispatcherTimer lastStatusTimer;

        /// <summary>
        /// The date time.
        /// </summary>
        private DateTime dateTime;

        /// <summary>
        /// The last status.
        /// </summary>
        private string lastStatus;

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusBarService"/> class.
        /// </summary>
        public StatusBarService()
        {
            this.dateTimeTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 1) };
            this.dateTimeTimer.Tick += (sender, args) => this.DateTime = DateTime.Now;
            this.dateTimeTimer.Start();

            this.lastStatusTimer = new DispatcherTimer { Interval = new TimeSpan(0, 0, 3) };
            this.lastStatusTimer.Tick += (sender, args) => this.LastStatus = string.Empty;
            
            this.DateTime = DateTime.Now;
        }

        /// <summary>
        /// Gets or sets the date time.
        /// </summary>
        /// <value>
        /// The date time.
        /// </value>
        public DateTime DateTime
        {
            get
            {
                return this.dateTime;
            }

            set
            {
                if (this.dateTime != value)
                {
                    this.dateTime = value;
                    this.OnPropertyChanged("DateTime");
                }
            }
        }

        /// <summary>
        /// Gets or sets the last status.
        /// </summary>
        /// <value>
        /// The last status.
        /// </value>
        public string LastStatus
        {
            get
            {
                return this.lastStatus;
            }

            set
            {
                if (this.lastStatus != value)
                {
                    if (string.IsNullOrWhiteSpace(value))
                    {
                        this.lastStatusTimer.Stop();
                    }
                    else
                    {
                        this.lastStatusTimer.Start();
                    }

                    this.lastStatus = value;
                    this.OnPropertyChanged("LastStatus");
                }
            }
        }
    }
}
