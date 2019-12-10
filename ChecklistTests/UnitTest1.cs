using Checklist.Entity;
using Checklist.Models;
using Checklist.Repository;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ChecklistTests
{
    public class Tests
    {
        private CreateChecklistRepository _sut;

        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChecklistContext>();
            optionsBuilder.UseInMemoryDatabase(DateTime.Now +"_Database" );
            var context = new ChecklistContext( optionsBuilder.Options);
            _sut = new CreateChecklistRepository(context);
        }

        [Test]
        public void It_should_create_a_shoping_list()
        {
            _sut.CreateShopingList(new List<Grocery>());
        }
    }
}