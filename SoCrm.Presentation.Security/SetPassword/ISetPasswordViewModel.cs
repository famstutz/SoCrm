// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISetPasswordViewModel.cs" company="Florian Amstutz">
//   Copyright (c) 2013 by Florian Amstutz.
// </copyright>
// <summary>
//   The set password view model.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SoCrm.Presentation.Security.SetPassword
{
    using System.Windows.Input;

    using SoCrm.Presentation.Core.Interfaces;
    using SoCrm.Services.Security.Contracts;

    /// <summary>
    /// The set password view model.
    /// </summary>
    public interface ISetPasswordViewModel : IViewModelBase
    {
        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>
        /// The user.
        /// </value>
        User User { get; set; }

        /// <summary>
        /// Gets or sets the old password.
        /// </summary>
        /// <value>
        /// The old password.
        /// </value>
        string OldPassword { get; set; }

        /// <summary>
        /// Gets or sets the new password.
        /// </summary>
        /// <value>
        /// The new password.
        /// </value>
        string NewPassword { get; set; }

        /// <summary>
        /// Gets the set password command.
        /// </summary>
        /// <value>
        /// The set password command.
        /// </value>
        ICommand SetPasswordCommand { get; }
    }
}
