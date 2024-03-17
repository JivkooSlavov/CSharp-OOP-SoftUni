namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class ArenaTests
    {
        private Arena arena;
        [SetUp]
        public void SetUp()
        {
            arena = new Arena();
        }

        [Test]
        public void ArenaConstructorWorkCorrectly()
        {
            Assert.IsNotNull(arena);
            Assert.IsNotNull(arena.Warriors);
        }
        [Test]
        public void ArenaCountShouldWorkCorrectly()
        {
            int expectedResult = 1;

            Warrior warrior = new Warrior("Gosho", 15, 25);
            arena.Enroll(warrior);

            Assert.IsNotEmpty(arena.Warriors);
            Assert.AreEqual(expectedResult, arena.Count);
        }
        [Test]
        public void ArenaWarriorCantEnrollWarriorWithTheSameNames()
        {
            Warrior warrior = new Warrior("Gosho", 15, 25);
            arena.Enroll(warrior);
            Warrior warrior2 = new Warrior("Gosho", 25, 30);


            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Enroll(warrior2));

            Assert.AreEqual($"Warrior is already enrolled for the fights!", ex.Message);
        }
        [Test]
        public void ArenaShouldEnrollCorrectlyWarrior()
        {
            int expectedCountOfWarrior = 2;

            Warrior warrior = new Warrior("Gosho", 15, 25);
            arena.Enroll(warrior);
            Warrior warrior2 = new Warrior("Pesho", 25, 30);
            arena.Enroll(warrior2);

            Assert.AreEqual(expectedCountOfWarrior, arena.Count);
        }
        [Test]
        public void ArenaFightShouldWorkCorrectly()
        {
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);
            arena.Enroll(attacker);
            arena.Enroll(defender);

            int expectedAttackerHp = 95;
            int expectedDefenderHp = 80;
            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
        [Test]
        public void ArenaFightShouldThrowExceptionIfAttackerNotFound()
        {
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            arena.Enroll(defender);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {attacker.Name} enrolled for the fights!", ex.Message);
        }
        [Test]
        public void ArenaFightShouldThrowExceptionIfDeffenderNotFound()
        {
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            arena.Enroll(attacker);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => arena.Fight(attacker.Name, defender.Name));

            Assert.AreEqual($"There is no fighter with name {defender.Name} enrolled for the fights!", ex.Message);
        }
    }
}
