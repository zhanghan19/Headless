﻿namespace Headless
{
    using System.Xml.XPath;

    /// <summary>
    ///     The <see cref="IHtmlElement" />
    ///     interface defines the structure of an element in an <see cref="IHtmlPage" />.
    /// </summary>
    public interface IHtmlElement
    {
        /// <summary>
        ///     Gets the HTML of the element.
        /// </summary>
        /// <value>
        ///     The HTML of the element.
        /// </value>
        string Html
        {
            get;
        }

        /// <summary>
        ///     Gets the HTML node of the element.
        /// </summary>
        /// <value>
        ///     The HTML node of the element.
        /// </value>
        IXPathNavigable Node
        {
            get;
        }

        /// <summary>
        ///     Gets the page that contains the element.
        /// </summary>
        /// <value>
        ///     The page that contains the element.
        /// </value>
        IHtmlPage Page
        {
            get;
        }
    }
}