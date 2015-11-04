using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace UamTTA.Tests
{
    [TestFixture]
    public class BudgetFactoryTests
    {
        private BudgetFactory _budgetFactory;

        [SetUp]
        public void SetUp()
        {
            _budgetFactory = new BudgetFactory();
        }

        [Test]
        public void Can_Create_Weekly_Budget_From_Template()
        {
            // Arrange
            var template = new BudgetTemplate(Duration.Weekly, "Weekly Budget");
            var expectedStartDate = new DateTime(2015, 10, 2);
            var expectedEndDate = new DateTime(2015, 10, 8);

            // Act
            Budget budget = _budgetFactory.CreateBudget(template, expectedStartDate);

            // Assert
            Assert.That(budget, Is.Not.Null);
            Assert.That(budget.ValidFrom, Is.EqualTo(expectedStartDate));
            Assert.That(budget.ValidTo, Is.EqualTo(expectedEndDate));
        }

        public IEnumerable<DateTime[]> MonthlyBudgetTestCases
        {
            get
            {
                yield return new[] { new DateTime(2015, 10, 2), new DateTime(2015, 11, 1) };
                yield return new[] { new DateTime(2015, 10, 31), new DateTime(2015, 11, 30) };
                yield return new[] { new DateTime(2016, 1, 31), new DateTime(2016, 2, 29) };
                yield return new[] { new DateTime(2015, 1, 31), new DateTime(2015, 2, 28) };
                yield return new[] { new DateTime(2015, 12, 1), new DateTime(2015, 12, 31) };
                yield return new[] { new DateTime(2015, 12, 15), new DateTime(2016, 1, 14) };
                yield return new[] { new DateTime(2015, 7, 31), new DateTime(2015, 8, 30) };
            }
        }

        [Test]
        [TestCaseSource(nameof(MonthlyBudgetTestCases))]
        public void Can_Create_Monthly_Budget_From_Template(DateTime expectedStartDate, DateTime expectedEndDate)
        {
            // Arrange
            var template = new BudgetTemplate(Duration.Monthly, "Monthly Budget");

            // Act
            Budget budget = _budgetFactory.CreateBudget(template, expectedStartDate);

            // Assert
            Assert.That(budget, Is.Not.Null);
            Assert.That(budget.ValidFrom, Is.EqualTo(expectedStartDate));
            Assert.That(budget.ValidTo, Is.EqualTo(expectedEndDate));
        }

        public IEnumerable<DateTime[]> QuarterlyBudgetTestCases
        {
            get
            {
                yield return new[] { new DateTime(2015, 10, 1), new DateTime(2015, 12, 31) };
                yield return new[] { new DateTime(2015, 1, 1), new DateTime(2015, 3, 31) };
                yield return new[] { new DateTime(2016, 4, 1), new DateTime(2016, 6, 30) };
                yield return new[] { new DateTime(2015, 7, 1), new DateTime(2015, 9, 30) };
                yield return new[] { new DateTime(2015, 10, 5), new DateTime(2016, 1, 4) };
                yield return new[] { new DateTime(2015, 11, 13), new DateTime(2016, 2, 12) };
                yield return new[] { new DateTime(2015, 12, 1), new DateTime(2016, 2, 29) };
                yield return new[] { new DateTime(2014, 12, 1), new DateTime(2015, 2, 28) };
                yield return new[] { new DateTime(2015, 4, 17), new DateTime(2015, 7, 16) };
                yield return new[] { new DateTime(2015, 11, 1), new DateTime(2016, 1, 31) };
                yield return new[] { new DateTime(2014, 11, 13), new DateTime(2015, 2, 12) };
                yield return new[] { new DateTime(2015, 1, 13), new DateTime(2015, 4, 12) };
                yield return new[] { new DateTime(2015, 2, 13), new DateTime(2015, 5, 12) };
                yield return new[] { new DateTime(2015, 3, 13), new DateTime(2015, 6, 12) };
                yield return new[] { new DateTime(2015, 4, 13), new DateTime(2015, 7, 12) };
                yield return new[] { new DateTime(2015, 5, 13), new DateTime(2015, 8, 12) };
                yield return new[] { new DateTime(2015, 6, 13), new DateTime(2015, 9, 12) };
                yield return new[] { new DateTime(2015, 7, 13), new DateTime(2015, 10, 12) };
                yield return new[] { new DateTime(2015, 8, 13), new DateTime(2015, 11, 12) };
                yield return new[] { new DateTime(2015, 9, 13), new DateTime(2015, 12, 12) };
                yield return new[] { new DateTime(2015, 10, 13), new DateTime(2016, 1, 12) };
                yield return new[] { new DateTime(2015, 11, 13), new DateTime(2016, 2, 12) };
                yield return new[] { new DateTime(2015, 12, 13), new DateTime(2016, 3, 12) };
            }
        }

        [Test]
        [TestCaseSource(nameof(QuarterlyBudgetTestCases))]
        public void Can_Create_Quarterly_Budget_From_Template(DateTime expectedStartDate, DateTime expectedEndDate)
        {
            // Arrange
            var template = new BudgetTemplate(Duration.Quarterly, "Quarterly Budget");

            // Act
            Budget budget = _budgetFactory.CreateBudget(template, expectedStartDate);

            // Assert
            Assert.That(budget, Is.Not.Null);
            Assert.That(budget.ValidFrom, Is.EqualTo(expectedStartDate));
            Assert.That(budget.ValidTo, Is.EqualTo(expectedEndDate));
        }

        public IEnumerable<DateTime[]> YearlyBudgetTestCases
        {
            get
            {
                yield return new[] { new DateTime(2014, 10, 1), new DateTime(2015, 9, 30) };
                yield return new[] { new DateTime(2015, 1, 1), new DateTime(2015, 12, 31) };
                yield return new[] { new DateTime(2014, 7, 12), new DateTime(2015, 7, 11) };
                yield return new[] { new DateTime(2015, 4, 1), new DateTime(2016, 3, 31) };
                yield return new[] { new DateTime(2015, 3, 11), new DateTime(2016, 3, 10) };
                yield return new[] { new DateTime(2016, 1, 1), new DateTime(2016, 12, 31) };
                yield return new[] { new DateTime(2016, 2, 1), new DateTime(2017, 1, 31) };
                yield return new[] { new DateTime(2016, 3, 1), new DateTime(2017, 2, 28) };
                yield return new[] { new DateTime(2015, 3, 1), new DateTime(2016, 2, 29) };
                yield return new[] { new DateTime(2014, 3, 1), new DateTime(2015, 2, 28) };
            }
        }

        [Test]
        [TestCaseSource(nameof(YearlyBudgetTestCases))]
        public void Can_Create_Yearly_Budget_From_Template(DateTime expectedStartDate, DateTime expectedEndDate)
        {
            // Arrange
            var template = new BudgetTemplate(Duration.Yearly, "Yearly Budget");

            // Act
            Budget budget = _budgetFactory.CreateBudget(template, expectedStartDate);

            // Assert
            Assert.That(budget, Is.Not.Null);
            Assert.That(budget.ValidFrom, Is.EqualTo(expectedStartDate));
            Assert.That(budget.ValidTo, Is.EqualTo(expectedEndDate));
        }
    }
}