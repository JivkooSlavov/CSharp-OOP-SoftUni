namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void WarriorConstructorShouldWorkCorrectly()
        {
            string expectedName = "Pesho";
            int expectedDamage = 15;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            Assert.NotNull(warrior);
            Assert.AreEqual(expectedName, warrior.Name);
            Assert.AreEqual(expectedDamage, warrior.Damage);
            Assert.AreEqual(expectedHP, warrior.HP);
        }
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("      ")]
        public void CreateWarriorShouldThrowExceptionWhenNameIsWhiteSpaceOrNull(string name)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Warrior(name, 50, 100));

            Assert.AreEqual("Name should not be empty or whitespace!", ex.Message);
        }
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-20)]
        public void CreateWarriorShouldThrowExceptionWhenDamageIsZeroOrNegative(int damage)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Warrior("Pesho", damage, 100));

            Assert.AreEqual("Damage value should be positive!", ex.Message);
        }
        [TestCase(-1)]
        [TestCase(-20)]
        public void CreateWarriorShouldThrowExceptionWhenHPIsNegative(int hp)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(()
                => new Warrior("Pesho", 50, hp));

            Assert.AreEqual("HP should not be negative!", ex.Message); 
        }
        [Test]
        public void AttackMethodShouldWorkCorrectly()
        {
            int expectedAttackerHp = 95;
            int expectedDefenderHp = 80;

            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, 90);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);
        }
        [TestCase(29)]
        [TestCase(30)]
        public void WarriorShouldCannotAttackIfHisEqualOrLessThan30(int hp)
        {
            Warrior attacker = new("Pesho", 10, hp);
            Warrior defender = new("Gosho", 5, 90);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual("Your HP is too low in order to attack other warriors!", ex.Message);
        }
        [TestCase(29)]
        [TestCase(30)]
        public void WarriorAttackShouldCannotAttackIfHisEqualOrLessThan30(int hp)
        {
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", 5, hp);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual($"Enemy HP must be greater than 30 in order to attack him!", ex.Message);
        }
        [TestCase(110)]
        public void WarriorAttackShouldNotAttackEnemyWithBiggerDamageThanHisHealth(int damage)
        {
            Warrior attacker = new("Pesho", 10, 100);
            Warrior defender = new("Gosho", damage, 90);

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()
                => attacker.Attack(defender));

            Assert.AreEqual($"You are trying to attack too strong enemy", ex.Message);
        }
        [TestCase(110)]
        public void EnemyHpShouldBeSetZeroIfWarriorDamageIsGreaterThanHisHp(int damage)
        {
            Warrior attacker = new("Pesho", damage, 100);
            Warrior defender = new("Gosho", 15, 90);

            attacker.Attack(defender);

            int expectedAttackerHp = 85;
            int expectedDefenderHp = 0;

            Assert.AreEqual(expectedAttackerHp, attacker.HP);
            Assert.AreEqual(expectedDefenderHp, defender.HP);

        }
    }
}