using NUnit.Framework;
using System;
using System.Runtime.Caching;

namespace TestMVC.Tests
{
    public class ParameterizedTests
    {
        [TestCase("Cache1", 1)]
        [TestCase("Cache1", 2)]
        [TestCase("Cache1", 3)]
        public void CanCache(string key, int value)
        {
            // ARRANGE
            ObjectCache cache = MemoryCache.Default;
            var policy = new CacheItemPolicy
            {
                AbsoluteExpiration = new DateTimeOffset(DateTime.Now.AddMinutes(1))
            };

            // ACT
            cache.Remove(key);
            cache.Add(key, value, policy);
            int fetchedValue = (int)cache.Get(key);

            //ASSERT
            Assert.That(fetchedValue, Is.EqualTo(value), "Uh Oh!");
        }
    }
}
