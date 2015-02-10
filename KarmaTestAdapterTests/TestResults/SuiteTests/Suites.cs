﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace KarmaTestAdapterTests.TestResults.SuiteTests
{
    partial class TestResults
    {
        partial class Suite
        {
            partial class Empty
            {
                [Fact(DisplayName = "Suites should not be null")]
                public void SuitesShouldNotBeNull()
                {
                    Assert.NotNull(Item.Suites);
                }

                [Fact(DisplayName = "Suites should be empty")]
                public void SuitesShouldBeEmpty()
                {
                    Assert.Empty(Item.Suites);
                }
            }

            [Fact(DisplayName = "Suites should not be null")]
            public void SuitesShouldNotBeNull()
            {
                Assert.NotNull(Item.Suites);
            }

            [Fact(DisplayName = "Suites should be empty")]
            public void SuitesShouldBeEmpty()
            {
                Assert.Empty(Item.Suites);
            }
        }
    }
}