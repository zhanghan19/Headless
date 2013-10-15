﻿namespace Headless.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    ///     The <see cref="CompositeLocationValidatorTests" />
    ///     class tests the <see cref="CompositeLocationValidator" /> class.
    /// </summary>
    [TestClass]
    public class CompositeLocationValidatorTests
    {
        /// <summary>
        ///     Runs a test for matches expressions returns false when no expression matches location.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsReturnsFalseWhenNoExpressionMatchesLocationTest()
        {
            var actualLocation = new Uri("http://www.test.com/customers/1233/products");
            var expressions = new List<Regex>
            {
                new Regex("http://www\\.test\\.com/customers/\\D+/products(/)?$")
            };

            var target = new CompositeLocationValidator();

            var actual = target.Matches(actualLocation, expressions);

            actual.Should().BeFalse();
        }

        /// <summary>
        ///     Runs a test for matches expressions returns false when no expressions provided.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsReturnsFalseWhenNoExpressionsProvidedTest()
        {
            var actualLocation = new Uri("http://www.test.com/some/time/");
            var expressions = new List<Regex>();

            var target = new CompositeLocationValidator();

            var actual = target.Matches(actualLocation, expressions);

            actual.Should().BeFalse();
        }

        /// <summary>
        ///     Runs a test for matches expressions returns true when at least one expression matches location.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsReturnsTrueWhenAtLeastOneExpressionMatchesLocationTest()
        {
            var actualLocation = new Uri("http://www.test.com/customers/1233/products/index");
            var expressions = new List<Regex>
            {
                new Regex("http://www\\.test\\.com/customers/\\d+/products/index(/)?$"), 
                new Regex("http://www\\.test\\.com/customers/\\d+/products(/)?$")
            };

            var target = new CompositeLocationValidator();

            var actual = target.Matches(actualLocation, expressions);

            actual.Should().BeTrue();
        }

        /// <summary>
        ///     Runs a test for matches expressions returns true when single expression matches location.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsReturnsTrueWhenSingleExpressionMatchesLocationTest()
        {
            var actualLocation = new Uri("http://www.test.com/customers/1233/products");
            var expressions = new List<Regex>
            {
                new Regex("http://www\\.test\\.com/customers/\\d+/products(/)?$")
            };

            var target = new CompositeLocationValidator();

            var actual = target.Matches(actualLocation, expressions);

            actual.Should().BeTrue();
        }

        /// <summary>
        ///     Runs a test for matches expressions throws exception with null actual location.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsThrowsExceptionWithNullActualLocationTest()
        {
            var target = new CompositeLocationValidator();

            Action action = () => target.Matches(null, new List<Regex>());

            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        ///     Runs a test for matches expressions throws exception with null expressions.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsThrowsExceptionWithNullExpressionsTest()
        {
            var actualLocation = new Uri("http://www.test.com/some/time/");

            var target = new CompositeLocationValidator();

            Action action = () => target.Matches(actualLocation, (IEnumerable<Regex>)null);

            action.ShouldThrow<ArgumentNullException>();
        }

        /// <summary>
        ///     Runs a test for matches expressions throws exception with relative actual location.
        /// </summary>
        [TestMethod]
        public void MatchesExpressionsThrowsExceptionWithRelativeActualLocationTest()
        {
            var actualLocation = new Uri("/some/time/", UriKind.Relative);

            var target = new CompositeLocationValidator();

            Action action = () => target.Matches(actualLocation, new List<Regex>());

            action.ShouldThrow<ArgumentException>();
        }

        /// <summary>
        ///     Runs a test for validation type returns all.
        /// </summary>
        [TestMethod]
        public void ValidationTypeReturnsAllTest()
        {
            var target = new CompositeLocationValidator();

            target.ValidationType.Should().Be(LocationValidationType.All);
        }
    }
}