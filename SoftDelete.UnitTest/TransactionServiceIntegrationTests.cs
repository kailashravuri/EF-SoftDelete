using System.Collections.Generic;

using EfExtentions.SoftDelete.Interface;
using EfExtentions.SoftDelete.Models;
using EfExtentions.SoftDelete.StructureMap;

using FluentAssertions;

using NUnit.Framework;

using StructureMap;

namespace SoftDelete.UnitTest
{
    [TestFixture]
    class GivenATransactionService
    {
        private Container _container;
        private ITransactionService _transactionService;

        [SetUp]
        public void Setup()
        {
            _container = new Container(new TestHarnessRegistry());
            _transactionService = _container.GetInstance<ITransactionService>();
        }

        [Test]
        public void WhenIsDeletedPersonIsAccessed_ThenItShouldNotReturnRecords()
        {
            var personsList = new List<PersonDto>()
            {
                new PersonDto()
                {
                    Name = "name-1"
                },
                new PersonDto()
                {
                    Name = "name-2"
                },
                new PersonDto()
                {
                    Name = "name-3"
                },
                new PersonDto()
                {
                    Name = "name-4"
                }
            };
            // insert persons
            _transactionService.Create(personsList).Should().BeTrue();

            // Get the inserted person - before update
            _transactionService.Get("name-1").Should().NotBeNull();

            // Update the IsDeleted true for person name-1
            _transactionService.Update("name-1", isDelete: true).Should().BeTrue();

            // Fetching the name-1 after IsDelted is updated to true = returns nothing
            _transactionService.Get("name-1").Should().BeNull();

            _transactionService.GetIncludeSoftDelete("name-1").Should().NotBeNull();
        }


        [Test]
        public void WhenCreateIsInvoked_ItShoulfAddSucessfully()
        {
            var personsList = new List<PersonDto>()
            {
                new PersonDto()
                {
                    Name = "name-1"
                },
                new PersonDto()
                {
                    Name = "name-2"
                },
                new PersonDto()
                {
                    Name = "name-3"
                },
                new PersonDto()
                {
                    Name = "name-4"
                }
            };
            // insert persons
            _transactionService.Create(personsList).Should().BeTrue();
        }


        [Test]
        public void WhenUpdateInvokedWithIsDelete_ThenItShouldUpdateSuccessfully()
        {
            _transactionService.Update("name-1", isDelete: true).Should().BeTrue();
        }

        [Test]
        public void WhenGetInvokedWithIsDeleteAsFalse_ThenItShouldNotResturnSoftDeltedRowsAlso()
        {
            _transactionService.Get("name-1").Should().BeNull();
        }

        [Test]
        public void WhenGetIncludeSoftDeleteInvoked_ThenItShouldReturnSoftDeltedRowsAlso()
        {
            _transactionService.GetIncludeSoftDelete("name-1").Should().NotBeNull();
        }

    }


}
