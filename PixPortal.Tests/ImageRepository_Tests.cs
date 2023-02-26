using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using PixPortal.Models;
using PixPortal.Services;
using System.Threading.Tasks;

namespace PixPortal.Tests
{
    public class ImageRepository_Tests
    {
        private ImageDbContext _imageDbContext;
        private Fixture _fixture = new Fixture();
        [SetUp]
        public void Setup()
        {
            DbContextOptions<ImageDbContext> dbContextOptions = new
                DbContextOptionsBuilder<ImageDbContext>()
                .UseInMemoryDatabase("ImageDbContext").Options;

            _imageDbContext = new ImageDbContext(dbContextOptions);
        }

        [Test]
        public async Task AddImage_Success()
        {
            //Arrange
            ImageRepository imageRepository = new ImageRepository(_imageDbContext);
            Image image = _fixture.Create<Image>();

            //Act
            Image imageResponse = await imageRepository.AddImage(image);

            //Assert
            string expected = JsonConvert.SerializeObject(image);
            string actual = JsonConvert.SerializeObject(imageResponse);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}