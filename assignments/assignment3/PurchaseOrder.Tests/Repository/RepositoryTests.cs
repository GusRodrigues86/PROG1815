using NUnit.Framework;
using PurchaseOrder.Domain;
using PurchaseOrder.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurchaseOrder.Tests.Repository
{
    class RepositoryTests
    {
        private InMemoryRepository repository;
        private Purchase dummyItem;

        [SetUp]
        public void Init()
        {
            repository = new InMemoryRepository(
                new List<Purchase> {
                    new Purchase(1, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(2, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(3, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(4, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(5, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(7, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "")
                });
            dummyItem = new Purchase(1, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "");

        }
        [TearDown]
        public void Dispose() => repository = null;

        #region Create
        [Test]
        public void RepositoryThrowsExceptionForCreateDuplicates()
        {
            var dummy = new Purchase(2, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "");
            Assert.IsTrue(repository.HasItem(dummy));
            ArgumentException ex = Assert.Throws<ArgumentException>(() =>
            {
                repository.Create(dummy);
            });
            Assert.IsTrue(ex.Message.Equals("Database already contains this value."));
        }
        [Test]
        public void RepositoryReturnsCopyOfObject()
        {
            var before = repository.Size();
            var dummy = new Purchase(20, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "");
            var insertedItem = repository.Create(dummy);
            Assert.AreEqual(dummy, insertedItem);
            Assert.AreNotSame(dummy, insertedItem);
            Assert.IsTrue(repository.HasItem(dummy));
            Assert.IsTrue(before < repository.Size());
        }
        [Test]
        public void RepositoryIncreaseByOneAfterCreation()
        {
            var before = repository.Size();
            var dummy = new Purchase(20, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "");
            repository.Create(dummy);
            Assert.IsTrue(before < repository.Size());
        }
        #endregion
        #region Read
        [Test]
        public void SearchByIdRetrievesCopy()
        {
            var dummy = repository.GetById(1);
            Assert.AreEqual(dummyItem, dummy);
            Assert.AreNotSame(dummyItem, dummy);
        }
        [Test]
        public void GetAllBringsTheSameItems()
        {
            var copy = new List<Purchase> {
                    new Purchase(1, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(2, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(3, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(4, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(5, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, ""),
                    new Purchase(7, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "")
                };
            var allInMemory = repository.GetAll();
            for (int i = 0; i < copy.Count; i++)
            {
                Assert.AreEqual(copy[i],allInMemory[i]);
                Assert.AreNotSame(copy[i], allInMemory[i]);
            }
        }
        [Test]
        public void GetByIdRetrievesTheRightItem()
        {
            var reference = new Purchase(1, DateTime.Today, "dummy", "test", 1.0, "hours", 1.0, "");
            var fromMemory = repository.GetById(1);
            Assert.AreEqual(reference, fromMemory);
            Assert.AreNotSame(reference, fromMemory);
        }

        #endregion

        #region Update

        #endregion

        #region Delete
        #endregion

    }
}

