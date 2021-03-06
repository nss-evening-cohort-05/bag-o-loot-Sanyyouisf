using System;
using System.Collections.Generic;
using Xunit;

namespace BagOLoot.Tests
{
    public class ToyRegisterShould
    {
        private readonly ToyRegister _register;
        private readonly ChildRegister _book;

        public ToyRegisterShould()
        {
            _register = new ToyRegister();
            _book = new ChildRegister();
        }

        [Fact]
        public void AddToy()
        {
            // Create a child
            Child kid = _book.AddChild("Terell");

            // Add a toy for the child
            Toy toy = _register.Add("Silly Putty", kid);
            Assert.True(toy != null);
        }

        [Fact]
        public void RevokeToyFromChild()
        {
            Child kid = _book.AddChild("Terell");
            Toy toy = _register.Add("Silly Putty", kid);
            _register.RevokeToy(kid, toy);
            List<Toy> toysForTerell = _register.GetToysForChild(kid);

            Assert.DoesNotContain(toy, toysForTerell);

        }
    }
}
