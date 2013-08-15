﻿namespace Headless
{
    using System;

    /// <summary>
    ///     The <see cref="BinaryPageWrapper" />
    ///     provides the wrapper logic around a dynamic binary page reference.
    /// </summary>
    internal class BinaryPageWrapper : BinaryPage
    {
        /// <summary>
        ///     The location.
        /// </summary>
        private readonly Uri _location;

        /// <summary>
        /// Initializes a new instance of the <see cref="BinaryPageWrapper"/> class.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        public BinaryPageWrapper(Uri location)
        {
            _location = location;
        }

        /// <inheritdoc />
        public override bool IsOn(Uri location)
        {
            // There is no verification of dynamic page locations because there is no model to define where the current location should be
            return true;
        }

        /// <inheritdoc />
        public override Uri Location
        {
            get
            {
                return _location;
            }
        }
    }
}